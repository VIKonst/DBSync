using System;
using System.Data.SqlClient;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace DBSync
{
    public partial class ScriptForm : Form
    {
        String _script;
        String _connectionString;
        ResourceManager resources = new ResourceManager("DBSync.Strings", typeof(ScriptForm).Assembly);

        private readonly String SCRIPT_COMPLETED_STR;
        public ScriptForm()
        {
            SCRIPT_COMPLETED_STR = resources.GetString("SCRIPT_COMPLETED");

            InitializeComponent();
        }
        public ScriptForm(String text, String connectionString)
            : this()
        {   
            
            scriptTextBox.Text = _script = text;
            _connectionString = connectionString;
        }



        private void ScriptForm_Load(Object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_Load(Object sender, EventArgs e)
        {

        }

        private void btnExecScript_Click(Object sender, EventArgs e)
        {
            String script = scriptTextBox.Text;
            String statement = Environment.NewLine + "GO" + Environment.NewLine;
            Int32 len = statement.Length;
            Int32 startIndex = 0;
            Int32  endIndex = script.IndexOf(statement);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                
                conn.InfoMessage += Conn_InfoMessage;
                conn.FireInfoMessageEventOnUserErrors = true;
                conn.Open();
                while (endIndex >= 0)
                {
                    String text = script.Substring(startIndex, endIndex - startIndex);
                    using (SqlCommand comm = conn.CreateCommand())
                    {
                        try
                        {
                            comm.CommandText = text;                           
                            comm.ExecuteNonQuery();                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                          
                        }
                    }
                    startIndex = endIndex+len;
                    if (startIndex >= script.Length)
                    {
                        endIndex = -1;
                    }
                    else
                    {
                        endIndex = script.IndexOf(statement, startIndex);
                    }
                }
                conn.Close();
            }
            resultTextBox.Text += SCRIPT_COMPLETED_STR;

        }

        private void Conn_InfoMessage(Object sender, SqlInfoMessageEventArgs e)
        {
             resultTextBox.Text += e.Message + Environment.NewLine;
        }

        private void saveBtn_Click(Object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Sql (*.sql)|*.sql";
            dialog.AddExtension = true;
            dialog.DefaultExt = ".sql";
            DialogResult result = dialog.ShowDialog();
            if(result==DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, scriptTextBox.Text);
            }
        }
    }
}
