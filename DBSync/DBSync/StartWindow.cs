using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VIK.DBSync.CommonLib.DB;
using WindowsFormsAero.Dwm.Helpers;

namespace DBSync
{
    public partial class StartWindow : GlassForm
    {
        public StartWindow()
        {          
            InitializeComponent();
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
                Close();
            }
        }
    }
}
