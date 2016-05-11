﻿using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using FastColoredTextBoxNS;
using ScintillaNET;
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

        public MainForm()
        {
            InitializeComponent();        
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
            StartWindow window = new StartWindow();
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
            }
        }

        private void StartCompare()
        {          
            ProgressForm form = new ProgressForm(sourceDatabase, destDatabase);
            form.ShowDialog();
            if(!form.IsLoaded)
            {
                Close();
            }
            var result = DBComparer.CompareDatabase(sourceDatabase, destDatabase);
            
            
            InitList();

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

    }
}
