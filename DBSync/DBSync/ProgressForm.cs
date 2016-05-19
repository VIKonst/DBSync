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
using VIK.DBSync.CommonLib.DB.Comparison;

namespace DBSync
{
    public partial class ProgressForm : Form
    {
        DataBase _db1;
        DataBase _db2;

        Thread thread;
        public List<ComparePair> Result { get; set; }

        public ProgressForm(DataBase db1, DataBase db2)
        {
            _db1 = db1;
            _db2 = db2;
            _db1.OnPogressUpdate += OnPogressUpdate;
            _db2.OnPogressUpdate += OnPogressUpdate;

            InitializeComponent();
        }

        private void OnPogressUpdate(String obj)
        {
            try
            {
                label1.Invoke(new Action(( () => { label1.Text = obj; } )));
            }
            catch { }
        }

        private void ProgressForm_Load(Object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    Parallel.Invoke(_db1.LoadObjects, _db2.LoadObjects);

                    OnPogressUpdate("Databases are compared");
                    Result = DBComparer.CompareDatabase(_db1, _db2);
                    this.Invoke(new Action(() => { this.Close(); }));
                    //throw new Exception("test");
                }
                catch(Exception ex)
                {
                    Program.LogException(ex);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void ProgressForm_Shown(Object sender, EventArgs e)
        {
        }

        private void ProgressForm_Activated(Object sender, EventArgs e)
        {

           
        }

    }
}
