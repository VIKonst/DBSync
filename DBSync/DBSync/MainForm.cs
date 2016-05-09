using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.DB.Comparison;
using VIK.DBSync.CommonLib.SqlObjects;
using Comparsion =VIK.DBSync.CommonLib.DB.Comparison;

namespace DBSync
{
    public partial class MainForm : Form
    {
        DataBase sourceDatabase;
        DataBase destDatabase;

        public MainForm()
        {
            InitializeComponent();
            fastColoredTextBox1.Scroll += Text_ScrollbarsUpdated;
            fastColoredTextBox2.Scroll += Text_ScrollbarsUpdated;
        }

        private void Text_ScrollbarsUpdated(Object sender, EventArgs e)
        {
            FastColoredTextBox textBox = (FastColoredTextBox)sender;
            Int32 horizontalValue = textBox.HorizontalScroll.Value;
            Int32 verticalValue = textBox.VerticalScroll.Value;

            fastColoredTextBox1.HorizontalScroll.Value = Math.Min(fastColoredTextBox1.HorizontalScroll.Maximum, horizontalValue);
            fastColoredTextBox2.HorizontalScroll.Value = Math.Min(fastColoredTextBox2.HorizontalScroll.Maximum, horizontalValue);

            fastColoredTextBox1.VerticalScroll.Value = Math.Min(fastColoredTextBox1.VerticalScroll.Maximum, verticalValue);
            fastColoredTextBox2.VerticalScroll.Value = Math.Min(fastColoredTextBox2.VerticalScroll.Maximum, verticalValue);
           
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            StartWindow window = new StartWindow();
            window.ShowDialog();

            if(window.IsNeedCompare)
            {
                sourceDatabase = new DataBase(window.SourceConnectionString);
                destDatabase = new DataBase(window.DestConnectionString);
                StartCompare();

               
               
                
                


                // checkedListBox1.M
                
            }
            else
            {
                Close();
            }
        }

        private void StartCompare()
        {
            sourceDatabase.LoadObjects();
            destDatabase.LoadObjects();


            var result = DBComparer.CompareDatabase(sourceDatabase, destDatabase);

            listView1.CheckBoxes = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Type");
            ListViewGroup NEGroup =  listView1.Groups.Add("NE","Not equals");
            ListViewGroup NGroup =  listView1.Groups.Add("N", "New");
            ListViewGroup RGroup = listView1.Groups.Add("R", "Removed");
            ListViewGroup EGroup = listView1.Groups.Add("E", "Equals");

            foreach (ComparePair pair in result)
            {
                ListViewGroup group = null;
                switch(pair.Result)
                {
                    case Comparsion.CompareResult.Different:
                        group = NEGroup;
                        break;
                    case Comparsion.CompareResult.Equals:
                        group = EGroup;
                        break;
                    case Comparsion.CompareResult.New:
                        group = NGroup;
                        break;
                    case Comparsion.CompareResult.Removed:
                        group = RGroup;
                        break;
                }


                ListViewItem item = new ListViewItem(pair.Name, group);
                SqlObject existedObject = pair.SourceObject ?? pair.DestinationObject;
                item.Tag = pair;
                item.SubItems.Add(existedObject.TypeName);
                listView1.Items.Add(item);
            }
            /*listBox1.DataSource = sourceDatabase.Objects.AllObjects();
            listBox1.ValueMember = "Name";

            listBox2.DataSource = destDatabase.Objects.AllObjects();
            listBox2.ValueMember = "Name";*/
        }

        private void Compare()
        {
          

        }

        private void FillText(FastColoredTextBox tb, DiffPaneModel text )
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Lines.Count; i++)
            {
                sb.AppendLine(text.Lines[i].Text);
            }
            tb.Text = sb.ToString();

            for (int i=0; i<text.Lines.Count; i++)
            {
                switch (text.Lines[i].Type)
                {
                    case ChangeType.Deleted:
                        tb[i].BackgroundBrush = Brushes.LightPink;
                        break;
                    case ChangeType.Imaginary:
                        tb[i].BackgroundBrush = Brushes.Gray;
                        break;
                    case ChangeType.Inserted:
                        tb[i].BackgroundBrush = Brushes.LightGreen;
                        break;
                    case ChangeType.Modified:
                        tb[i].BackgroundBrush = Brushes.LightCoral;
                        break;
                    case ChangeType.Unchanged:
                        tb[i].BackgroundBrush = Brushes.White;
                        break;
                }
              
            }
        }
       

        private void listView1_SelectedIndexChanged(Object sender, EventArgs e)
        {           
            if(listView1.SelectedItems.Count>0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                ComparePair pair = (ComparePair) item.Tag;
                SqlObject obj1 = pair.DestinationObject;
                SqlObject obj2 = pair.SourceObject; 

                String script1 = obj1?.CreateScript() ?? String.Empty;
                String script2 = obj2?.CreateScript() ?? String.Empty;

                var diff = ( new SideBySideDiffBuilder(new Differ()) ).BuildDiffModel(script1, script2);
                DiffPaneModel Text1 = diff.NewText;
                DiffPaneModel Text2 = diff.OldText;

                FillText(fastColoredTextBox1, Text1);
                FillText(fastColoredTextBox2, Text2);
            }
        }
    }
}
