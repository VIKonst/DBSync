using DBSync.SqlLiteDb;
using System;
using System.Windows.Forms;

namespace DBSync
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {  
            InitializeComponent();
            setDestConnection.Servers = SettingsRepository.Instance.GetServerNames();
            setSourceConnection.Servers = SettingsRepository.Instance.GetServerNames(); 

        }

        public Boolean IsNeedCompare { get; set; }

        public Boolean TestConnections()
        {
            return setSourceConnection.TestConnection(true)
                && setDestConnection.TestConnection(true);
        }

        public String SourceConnectionString
        {
            get
            {
                return setSourceConnection.ConnectionString;
            }
        }

        public String DestConnectionString
        {
            get
            {
                return setDestConnection.ConnectionString;
            }
        }

        private void StartWindow_Load(Object sender, EventArgs e)
        {

        }
        

       /* void UpdateDBSource(Task<List<String>> task)
        {
            if(task.IsFaulted)
            {
                MessageBox.Show(task.Exception.InnerException.Message);
                return;
            }        
        }*/

        private void setConnectionControl1_Load(Object sender, EventArgs e)
        {

        }

        private void setConnectionControl2_Load(Object sender, EventArgs e)
        {

        }

        private void btnCompare_Click(Object sender, EventArgs e)
        {
            if (TestConnections())
            {
                IsNeedCompare = true;
                SettingsRepository.Instance.AddConnectionIfNotExist(setSourceConnection.Server);
                if (!setSourceConnection.Server.Equals(setDestConnection.Server))
                {
                    SettingsRepository.Instance.AddConnectionIfNotExist(setDestConnection.Server);
                }
                Close();
            }
        }

        private void button1_Click(Object sender, EventArgs e)
        {
            RuntimeLocalizer.ChangeCulture(this, "uk");
        }
    }
}
