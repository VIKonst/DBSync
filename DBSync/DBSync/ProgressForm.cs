using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIK.DBSync.CommonLib.DB;

namespace DBSync
{
    public partial class ProgressForm : Form
    {
        DataBase _db1;
        DataBase _db2;

        Thread thread;
        public Boolean IsLoaded { get; set; }

        public ProgressForm(DataBase db1, DataBase db2)
        {
            _db1 = db1;
            _db2 = db2;
            _db1.OnPogressUpdate += Db1_OnPogressUpdate;
            _db1.OnPogressUpdate += Db1_OnPogressUpdate;          
          
            InitializeComponent();
        }

        private void Db1_OnPogressUpdate(String obj)
        {
            try
            {
                label1.Invoke(new Action(( () => { label1.Text = obj; } )));
            }
            catch { }
        }

        private void ProgressForm_Load(Object sender, EventArgs e)
        {
           
        }

        private void ProgressForm_Shown(Object sender, EventArgs e)
        {
        }

        private void ProgressForm_Activated(Object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
            
               _db1.LoadObjects();
                _db2.LoadObjects();
                IsLoaded = true;
                this.Invoke(new Action(() => { this.Close(); }));
            });
            thread.IsBackground = true;
            thread.Start();
        }
       
    }
}
