using System.Drawing;

namespace DBSync
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.diffControl = new DBSync.UIControls.DiffControl();
            this.ribon = new System.Windows.Forms.Ribbon();
            this.mainTab = new System.Windows.Forms.RibbonTab();
            this.rPanel1 = new System.Windows.Forms.RibbonPanel();
            this.syncBtn = new System.Windows.Forms.RibbonButton();
            this.connectionsBtn = new System.Windows.Forms.RibbonButton();
            this.updateBtn = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.inverseAllBtn = new System.Windows.Forms.RibbonButton();
            this.checkAllBtn = new System.Windows.Forms.RibbonButton();
            this.InverseBtn = new System.Windows.Forms.RibbonButton();
            this.settingsTab = new System.Windows.Forms.RibbonTab();
            this.langPanel = new System.Windows.Forms.RibbonPanel();
            this.ribbonItemGroup2 = new System.Windows.Forms.RibbonItemGroup();
            this.btnLangRu = new System.Windows.Forms.RibbonButton();
            this.btnLangEn = new System.Windows.Forms.RibbonButton();
            this.btnLangUk = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonHost1 = new System.Windows.Forms.RibbonHost();
            this.ribbonTextBox1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.diffControl);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType});
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.FullRowSelect = true;
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups1")))});
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Name = "colName";
            resources.ApplyResources(this.colName, "colName");
            // 
            // colType
            // 
            this.colType.Name = "colType";
            resources.ApplyResources(this.colType, "colType");
            // 
            // diffControl
            // 
            resources.ApplyResources(this.diffControl, "diffControl");
            this.diffControl.Name = "diffControl";
            this.diffControl.Load += new System.EventHandler(this.diffControl_Load);
            // 
            // ribon
            // 
            this.ribon.BorderMode = System.Windows.Forms.RibbonWindowMode.InsideWindow;
            this.ribon.CaptionBarVisible = false;
            this.ribon.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.ribon, "ribon");
            this.ribon.Minimized = false;
            this.ribon.Name = "ribon";
            // 
            // 
            // 
            this.ribon.OrbDropDown.BorderRoundness = 8;
            this.ribon.OrbDropDown.Location = ((System.Drawing.Point)(resources.GetObject("ribon.OrbDropDown.Location")));
            this.ribon.OrbDropDown.Name = "";
            this.ribon.OrbDropDown.Size = ((System.Drawing.Size)(resources.GetObject("ribon.OrbDropDown.Size")));
            this.ribon.OrbDropDown.TabIndex = ((int)(resources.GetObject("ribon.OrbDropDown.TabIndex")));
            this.ribon.OrbImage = null;
            this.ribon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribon.OrbText = "Orb";
            this.ribon.OrbVisible = false;
            // 
            // 
            // 
            this.ribon.QuickAcessToolbar.Visible = false;
            this.ribon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribon.Tabs.Add(this.mainTab);
            this.ribon.Tabs.Add(this.settingsTab);
            this.ribon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribon.TabSpacing = 9;
            this.ribon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // mainTab
            // 
            this.mainTab.Panels.Add(this.rPanel1);
            this.mainTab.Panels.Add(this.ribbonPanel3);
            resources.ApplyResources(this.mainTab, "mainTab");
            this.mainTab.Value = "mainTab";
            // 
            // rPanel1
            // 
            this.rPanel1.ButtonMoreVisible = false;
            this.rPanel1.Items.Add(this.syncBtn);
            this.rPanel1.Items.Add(this.connectionsBtn);
            this.rPanel1.Items.Add(this.updateBtn);
            resources.ApplyResources(this.rPanel1, "rPanel1");
            // 
            // syncBtn
            // 
            this.syncBtn.Image = ((System.Drawing.Image)(resources.GetObject("syncBtn.Image")));
            this.syncBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("syncBtn.SmallImage")));
            resources.ApplyResources(this.syncBtn, "syncBtn");
            this.syncBtn.Value = "syncBtn";
            this.syncBtn.Click += new System.EventHandler(this.syncRibbonButton_Click);
            // 
            // connectionsBtn
            // 
            this.connectionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectionsBtn.Image")));
            this.connectionsBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("connectionsBtn.SmallImage")));
            resources.ApplyResources(this.connectionsBtn, "connectionsBtn");
            this.connectionsBtn.Value = "connectionsBtn";
            this.connectionsBtn.Click += new System.EventHandler(this.changeRibbonButton_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Image = ((System.Drawing.Image)(resources.GetObject("updateBtn.Image")));
            this.updateBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("updateBtn.SmallImage")));
            resources.ApplyResources(this.updateBtn, "updateBtn");
            this.updateBtn.Value = "updateBtn";
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.inverseAllBtn);
            this.ribbonPanel3.Items.Add(this.checkAllBtn);
            this.ribbonPanel3.Items.Add(this.InverseBtn);
            resources.ApplyResources(this.ribbonPanel3, "ribbonPanel3");
            // 
            // inverseAllBtn
            // 
            this.inverseAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("inverseAllBtn.Image")));
            this.inverseAllBtn.MaximumSize = new System.Drawing.Size(0, 5);
            this.inverseAllBtn.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.inverseAllBtn.MinimumSize = new System.Drawing.Size(200, 0);
            this.inverseAllBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("inverseAllBtn.SmallImage")));
            resources.ApplyResources(this.inverseAllBtn, "inverseAllBtn");
            this.inverseAllBtn.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            this.inverseAllBtn.Value = "inverseAllBtn";
            this.inverseAllBtn.Click += new System.EventHandler(this.inverseAllBtn_Click);
            // 
            // checkAllBtn
            // 
            this.checkAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("checkAllBtn.Image")));
            this.checkAllBtn.MaximumSize = new System.Drawing.Size(0, 5);
            this.checkAllBtn.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.checkAllBtn.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.checkAllBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("checkAllBtn.SmallImage")));
            resources.ApplyResources(this.checkAllBtn, "checkAllBtn");
            this.checkAllBtn.Value = "checkAllBtn";
            this.checkAllBtn.Click += new System.EventHandler(this.checkAllBtn_Click);
            // 
            // InverseBtn
            // 
            this.InverseBtn.Image = ((System.Drawing.Image)(resources.GetObject("InverseBtn.Image")));
            this.InverseBtn.MaximumSize = new System.Drawing.Size(0, 5);
            this.InverseBtn.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.InverseBtn.MinimumSize = new System.Drawing.Size(200, 0);
            this.InverseBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("InverseBtn.SmallImage")));
            resources.ApplyResources(this.InverseBtn, "InverseBtn");
            this.InverseBtn.Value = "InverseBtn";
            this.InverseBtn.Click += new System.EventHandler(this.InverseBtn_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.Panels.Add(this.langPanel);
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.Value = "settingsTab";
            // 
            // langPanel
            // 
            this.langPanel.ButtonMoreEnabled = false;
            this.langPanel.ButtonMoreVisible = false;
            this.langPanel.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Right;
            this.langPanel.Items.Add(this.ribbonItemGroup2);
            this.langPanel.Tag = "langPanel";
            resources.ApplyResources(this.langPanel, "langPanel");
            // 
            // ribbonItemGroup2
            // 
            this.ribbonItemGroup2.Items.Add(this.btnLangRu);
            this.ribbonItemGroup2.Items.Add(this.btnLangEn);
            this.ribbonItemGroup2.Items.Add(this.btnLangUk);
            resources.ApplyResources(this.ribbonItemGroup2, "ribbonItemGroup2");
            this.ribbonItemGroup2.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // btnLangRu
            // 
            this.btnLangRu.Image = ((System.Drawing.Image)(resources.GetObject("btnLangRu.Image")));
            this.btnLangRu.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnLangRu.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLangRu.SmallImage")));
            resources.ApplyResources(this.btnLangRu, "btnLangRu");
            this.btnLangRu.Value = "ru";
            // 
            // btnLangEn
            // 
            this.btnLangEn.Image = ((System.Drawing.Image)(resources.GetObject("btnLangEn.Image")));
            this.btnLangEn.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnLangEn.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLangEn.SmallImage")));
            resources.ApplyResources(this.btnLangEn, "btnLangEn");
            this.btnLangEn.Value = "en";
            // 
            // btnLangUk
            // 
            this.btnLangUk.DropDownItems.Add(this.btnLangEn);
            this.btnLangUk.Image = ((System.Drawing.Image)(resources.GetObject("btnLangUk.Image")));
            this.btnLangUk.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnLangUk.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLangUk.SmallImage")));
            resources.ApplyResources(this.btnLangUk, "btnLangUk");
            this.btnLangUk.Value = "uk";
            // 
            // ribbonPanel2
            // 
            resources.ApplyResources(this.ribbonPanel2, "ribbonPanel2");
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonPanel1
            // 
            resources.ApplyResources(this.ribbonPanel1, "ribbonPanel1");
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            resources.ApplyResources(this.ribbonTab1, "ribbonTab1");
            // 
            // ribbonHost1
            // 
            this.ribbonHost1.HostedControl = null;
            resources.ApplyResources(this.ribbonHost1, "ribbonHost1");
            // 
            // ribbonTextBox1
            // 
            resources.ApplyResources(this.ribbonTextBox1, "ribbonTextBox1");
            this.ribbonTextBox1.TextBoxText = "";
            // 
            // ribbonItemGroup1
            // 
            resources.ApplyResources(this.ribbonItemGroup1, "ribbonItemGroup1");
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.MaximumSize = new System.Drawing.Size(0, 5);
            this.ribbonButton4.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            resources.ApplyResources(this.ribbonButton4, "ribbonButton4");
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.MaximumSize = new System.Drawing.Size(0, 5);
            this.ribbonButton5.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            resources.ApplyResources(this.ribbonButton5, "ribbonButton5");
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.DropDownItems.Add(this.ribbonButton5);
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.MaximumSize = new System.Drawing.Size(0, 5);
            this.ribbonButton8.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            resources.ApplyResources(this.ribbonButton8, "ribbonButton8");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ribon);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        private System.Windows.Forms.Ribbon ribon;
        private System.Windows.Forms.RibbonTab mainTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonHost ribbonHost1;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox1;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup1;
        private System.Windows.Forms.RibbonTab settingsTab;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup2;
        private System.Windows.Forms.RibbonButton btnLangRu;
        private System.Windows.Forms.RibbonButton btnLangEn;
        private System.Windows.Forms.RibbonButton btnLangUk;
        private UIControls.DiffControl diffControl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RibbonPanel langPanel;
        private System.Windows.Forms.RibbonPanel rPanel1;
        private System.Windows.Forms.RibbonButton syncBtn;
        private System.Windows.Forms.RibbonButton connectionsBtn;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton inverseAllBtn;
        private System.Windows.Forms.RibbonButton checkAllBtn;
        private System.Windows.Forms.RibbonButton InverseBtn;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton updateBtn;
    }
}

