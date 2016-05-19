using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using VIK.DBSync.CommonLib.DB;
using DBSync.UIControls;

namespace DBSync
{
    public partial class SetConnectionControl : UserControl, ILocalizeControl
    {
        public SetConnectionControl()
        {
            InitializeComponent();
        }

        public String ConnectionString 
        {
            get 
            {
                SqlConnectionStringBuilder connectionStr = new SqlConnectionStringBuilder();
                connectionStr.IntegratedSecurity = chbIntegratedSecuritySource.Checked;
                connectionStr.DataSource = cbServer.Text;
                connectionStr.InitialCatalog = cbDbSource.Text;
                if(!connectionStr.IntegratedSecurity)
                {
                    connectionStr.UserID = tbUser.Text;
                    connectionStr.Password = tbPass.Text;
                }
                return connectionStr.ToString();
            }
        }

        public List<string> Servers
        {
            set
            {
                cbServer.DataSource = value;
            }
        }

        public String Server
        {
            get
            {
                return cbServer.Text;
            }
        }


        [Localizable(true)]
        public String Title
        {
            get
            {
                return titleLabel.Text;                
            }

            set
            {
                 titleLabel.Text = value;               
            }
        }

        public override String Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }


        public Boolean TestConnection(Boolean showErrorBox = false)
        {
            try
            {
                DBHelper.TestConnection(this.ConnectionString);
                return true;
            }
            catch (Exception ex)
            {
                if(showErrorBox)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                return false;
            }
        }

        private void UserControl1_Load(Object sender, EventArgs e)
        {

        }

        private void cbDbSource_DropDown(Object sender, EventArgs e)
        {
            cbDbSource.DataSource = null;           
            try
            {
                cbDbSource.DataSource = DBHelper.GetDBsNames(this.ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbDbSource_SelectedIndexChanged(Object sender, EventArgs e)
        {

        }

        private void chbIntegratedSecuritySource_CheckedChanged(Object sender, EventArgs e)
        {
            Boolean isNeedUser = !chbIntegratedSecuritySource.Checked;
            tbPass.Enabled = tbUser.Enabled = isNeedUser;
        }

        private void label7_Click(Object sender, EventArgs e)
        {

        }

        public void UpdateLocalization()
        {
            ComponentResourceManager res = new ComponentResourceManager(this.GetType());
            res.ApplyResources(lblServer, lblServer.Name);
            res.ApplyResources(lblBd, lblBd.Name);
            res.ApplyResources(lblPass, lblPass.Name);
            res.ApplyResources(lblUser, lblUser.Name);
            res.ApplyResources(chbIntegratedSecuritySource, chbIntegratedSecuritySource.Name);

        }
    }
}
