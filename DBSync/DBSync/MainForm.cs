using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using FastColoredTextBoxNS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.DB.Comparison;
using VIK.DBSync.CommonLib.DB.Sync;
using VIK.DBSync.CommonLib.SqlObjects;
using Comparsion = VIK.DBSync.CommonLib.DB.Comparison;

namespace DBSync
{
    public partial class MainForm : Form
    {
        DataBase sourceDatabase;
        DataBase destDatabase;

        ListViewGroup NEGroup;
        ListViewGroup NGroup;
        ListViewGroup RGroup;
        ListViewGroup EGroup;

        class ComparerItem : IComparer
        {
            public Int32 Compare(Object x, Object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;
                Int32 result = item1.SubItems[1].Text.CompareTo(item2.SubItems[1].Text);
                if (result != 0) return result;
                return item1.Text.CompareTo(item2.Text);
            }
        }

        public MainForm()
        {   
            InitializeComponent();
            InitList();
            listView1.ItemChecked += ListView1_ItemChecked;
            listView1.ListViewItemSorter = new  ComparerItem();
        }

        private void ListView1_ItemChecked(Object sender, ItemCheckedEventArgs e)
        {
           if(e.Item.BackColor == Color.LightSlateGray)
           {
                e.Item.Checked = false;
           }
        }

        private void InitList()
        {
            listView1.Columns.Add("Name").Width = 400;
            listView1.Columns.Add("Type");
            NEGroup = listView1.Groups.Add("NE", "Not equals");
            NGroup = listView1.Groups.Add("N", "New");
            RGroup = listView1.Groups.Add("R", "Removed");
            EGroup = listView1.Groups.Add("E", "Equals");
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
          /*  StartWindow window = new StartWindow();
            window.ShowDialog();
           
            if(window.IsNeedCompare)
            {
                sourceDatabase = new DataBase(window.SourceConnectionString);
                destDatabase = new DataBase(window.DestConnectionString);
                StartCompare();   
            }
            else
            {
                Close();
            }*/
        }

        private void StartCompare()
        {          
            ProgressForm form = new ProgressForm(sourceDatabase, destDatabase);
            form.ShowDialog();
            if(form.Result==null)
            {
                Close();
            }            

            foreach (ComparePair pair in form.Result)
            {
                ListViewGroup group = null;
                ListViewItem item = new ListViewItem(pair.Name);
                switch (pair.Result)
                {
                    case Comparsion.CompareResult.Different:
                        group = NEGroup;
                        item.BackColor = Color.LightBlue;
                        break;
                    case Comparsion.CompareResult.Equals:
                        group = EGroup;
                        item.BackColor = Color.LightSlateGray;
                        break;
                    case Comparsion.CompareResult.New:
                        group = NGroup;
                        break;
                    case Comparsion.CompareResult.Removed:
                        group = RGroup;
                        break;
                }
                item.Group = group;

               
                SqlObject existedObject = pair.SourceObject ?? pair.DestinationObject;
                item.Tag = pair;
                item.SubItems.Add(existedObject.TypeName);
                item.UseItemStyleForSubItems = true;
                listView1.Items.Add(item);
                
            }
            listView1.Sort();
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
            if(listView1.FocusedItem!=null)
            {
                ListViewItem item = listView1.FocusedItem;
                
                ComparePair pair = (ComparePair) item.Tag;              

                String script1 = pair.DestinationObject?.CreateScript();
                String script2 = pair.SourceObject?.CreateScript();

                diffControl.SetText(script1, script2);
            }
        }

        private void syncRibbonButton_Click(Object sender, EventArgs e)
        {
            SyncGenerator genrator = new SyncGenerator();
            
            List<ComparePair> selectedItems = new List<ComparePair>();
            foreach(ListViewItem item in listView1.CheckedItems)
            {
                selectedItems.Add((ComparePair)item.Tag);
            }

            genrator.GenerateScript(selectedItems);
            ScriptForm form = new ScriptForm(genrator.GenerateScript(selectedItems));
            form.Show();
        }

        StartWindow window = new StartWindow();
        private void changeRibbonButton_Click(Object sender, EventArgs e)
        {
            window.IsNeedCompare = false;
            window.ShowDialog();

            if (window.IsNeedCompare)
            {
                sourceDatabase = new DataBase(window.SourceConnectionString);
                destDatabase = new DataBase(window.DestConnectionString);
                listView1.Items.Clear();
                StartCompare();
            }
        }
    }
}
