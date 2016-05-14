using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIK.DBSync.CommonLib.DB;

namespace VIK.DBSync.UITest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnShowScript_Click(Object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = tbServer.Text;
                builder.Add("Integrated Security", cbIntegrated.Checked);
                builder.Password = tbPass.Text;
                builder.UserID = tbLogin.Text;
                builder.InitialCatalog = tbDB.Text;
                SqlConnection connection = new SqlConnection(builder.ToString());
                connection.Open();
                DataBase db = new DataBase(connection);
               // db.LoadTables();
               // db.LoadProcedures();
                connection.Close();
                MessageBox.Show("Metadata loaded");
                StreamWriter writer = new StreamWriter("script.sql");
                foreach (var obj in db.Objects.Tables)
                {
                    writer.WriteLine(obj.CreateScript());
                }

                foreach (var obj in db.Objects.Procedures)
                {
                    writer.WriteLine(obj.CreateScript());
                }
                writer.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.InnerException.Message);
                    MessageBox.Show(ex.InnerException.StackTrace);
                }
            }
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {

        }
    }
}
