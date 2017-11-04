using DBSync.SqlLiteDb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
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
        String sourceConnectionString;
        String destConnectionString;
        ListViewGroup NEGroup;
        ListViewGroup NGroup;
        ListViewGroup RGroup;
        ListViewGroup EGroup;
        ResourceManager resources = new ResourceManager("DBSync.Strings", typeof(ScriptForm).Assembly);

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
            FilSqlTypeNames();
            InitList();          

            btnLangEn.Click += BtnLangClick;
            btnLangUk.Click += BtnLangClick;
            btnLangRu.Click += BtnLangClick;

            safeTransactionChb.Checked = SettingsManager.Instance.SafeTransaction;
        }

        private void BtnLangClick(Object sender, EventArgs e)
        {
            RibbonButton btn = sender as RibbonButton;
            ChangeLanguage(btn.Value);
        }

        private void ChangeLanguage(String lang)
        {           
            RuntimeLocalizer.ChangeCulture(this,lang);
            RuntimeLocalizer.ChangeCulture(window, lang);
            SettingsManager.Instance.Lang = lang;
            FilGroupNames();
            FilSqlTypeNames();
            foreach (ListViewItem item in listView1.Items)
            {
                item.SubItems[1].Text = _typeNames[(item.Tag as ComparePair).Type.GetHashCode()];
            }
        }

        private void ListView1_ItemChecked(Object sender, ItemCheckedEventArgs e)
        {
           if(e.Item.Group == EGroup)
           {
                e.Item.Checked = false;
           }
        }

        private void InitList()
        {
            NEGroup = listView1.Groups.Add("NE", "Not equals");
            NGroup = listView1.Groups.Add("N", "New");
            RGroup = listView1.Groups.Add("R", "Removed");
            EGroup = listView1.Groups.Add("E", "Equals");

            FilGroupNames();
            listView1.ItemChecked += ListView1_ItemChecked;
            listView1.ListViewItemSorter = new ComparerItem();
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
          
        }

        private void StartCompare()
        {
            listView1.Items.Clear();
            sourceDatabase = new DataBase(sourceConnectionString);
            destDatabase = new DataBase(destConnectionString);

            ProgressForm form = new ProgressForm(sourceDatabase, destDatabase);
            form.ShowDialog();
            if (form.Result == null)
            {
                sourceDatabase = null;
                destDatabase = null;
                return;
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
                        item.BackColor = Color.LightGray;
                        break;
                    case Comparsion.CompareResult.New:
                        group = NGroup;
                        break;
                    case Comparsion.CompareResult.Removed:
                        group = RGroup;
                        break;
                }
                item.Group = group;                             
              
                item.Tag = pair;
                item.SubItems.Add(_typeNames[pair.Type.GetHashCode()]);
                item.UseItemStyleForSubItems = true;
                
                listView1.Items.Add(item);                
            }

            listView1.Sort();
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
            SyncGenerator genrator = new SyncGenerator(GetOptions());
            
            List<ComparePair> selectedItems = new List<ComparePair>();
            foreach(ListViewItem item in listView1.CheckedItems)
            {
                selectedItems.Add((ComparePair)item.Tag);
            }
            if (selectedItems.Count == 0)
                return;
                            
            ScriptForm form = new ScriptForm(genrator.GenerateScript(selectedItems),destDatabase.ConnectionString);
            form.ShowDialog();
        }

        StartWindow window = new StartWindow();
        private void changeRibbonButton_Click(Object sender, EventArgs e)
        {
            window.IsNeedCompare = false;
            window.ShowDialog();

            if (window.IsNeedCompare)
            {
                sourceConnectionString = window.SourceConnectionString;
                destConnectionString = window.DestConnectionString;
                StartCompare();
            }
           
        }

        private void diffControl_Load(Object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(Object sender, EventArgs e)
        {
            if (sourceDatabase != null && destDatabase != null)
            {
                StartCompare();
            }
        }

        private void inverseAllBtn_Click(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void checkAllBtn_Click(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = item.Group != EGroup;
            }
        }

        private void InverseBtn_Click(Object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        String[] _typeNames;

        private void FilSqlTypeNames()
        {
            _typeNames = new String[6];
            _typeNames[SqlObjectType.Table.GetHashCode()] = resources.GetString("TABLE");
            _typeNames[SqlObjectType.StoredProcedure.GetHashCode()] = resources.GetString("SP");
            _typeNames[SqlObjectType.Schema.GetHashCode()] = resources.GetString("SCHEMA");
            _typeNames[SqlObjectType.Type.GetHashCode()] = resources.GetString("TYPE");
            _typeNames[SqlObjectType.XmlSchema.GetHashCode()] = resources.GetString("XML_SCHEMA");
        }

        private void FilGroupNames()
        {
            NEGroup.Header = resources.GetString("NOT_EQ");
            NGroup.Header = resources.GetString("NEW");
            RGroup.Header = resources.GetString("REMOVED");
            EGroup.Header = resources.GetString("EQUAL");
        }


        private SyncOptions GetOptions()
        {
            SyncOptions options = new SyncOptions
            {
                SafeTransaction = SettingsManager.Instance.SafeTransaction
            };
            return options;
        }

        private void safeTransactionChb_CheckBoxCheckChanged(Object sender, EventArgs e)
        {
            SettingsManager.Instance.SafeTransaction = safeTransactionChb.Checked;
        }
    }
}
