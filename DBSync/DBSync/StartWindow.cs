using DBSync.SqlLiteDb;
using DBSync.SqlLiteDb.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSync
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {  
            InitializeComponent();
            setDestConnection.Servers = ConnectionsRepository.Instance.GetConnections();
            setSourceConnection.Servers = ConnectionsRepository.Instance.GetConnections(); 

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
                
                StoreConnections();
                Close();
            }
        }

        private void StoreConnections()
        {
            try
            {
                Connection conn1 = GetConnection(setSourceConnection);
                Connection conn2 = null;
                if (!setSourceConnection.Server.Equals(setDestConnection.Server))
                {
                    conn2 = GetConnection(setDestConnection);
                }
                Task.Run(() =>
                {
                    ConnectionsRepository.Instance.AddOrUpdateConnection(conn1);
                    if(conn2!=null)
                        ConnectionsRepository.Instance.AddOrUpdateConnection(conn2);
                });
            }
            catch { }
        }

        private Connection GetConnection(SetConnectionControl control)
        {
            Connection connection = new Connection();
            connection.Server = control.Server;
            connection.IsWindowsAuth = control.IsWindowsAuthentificatiion;

            if (!connection.IsWindowsAuth)
            {
                connection.UserName = control.User;
                if(control.IsNeedSavePasswor)
                {
                    connection.Pass = control.EnctyptedPassword;
                }
                else
                {
                    connection.Pass = String.Empty;
                }
            }
            return connection;           
        }



    }
}
