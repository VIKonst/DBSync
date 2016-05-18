using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSync
{
    public partial class ScriptForm : Form
    {
        public ScriptForm()
        {
            InitializeComponent();
        }
        public ScriptForm(String text)
        {
            InitializeComponent();
            fastColoredTextBox1.Text = text;
        }


        private void ScriptForm_Load(Object sender, EventArgs e)
        {

        }
    }
}
