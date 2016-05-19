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
            this.ribon = new System.Windows.Forms.Ribbon();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.syncRibbonButton = new System.Windows.Forms.RibbonButton();
            this.changeRibbonButton = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonHost1 = new System.Windows.Forms.RibbonHost();
            this.ribbonTextBox1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.diffControl = new DBSync.UIControls.DiffControl();
            this.SuspendLayout();
            // 
            // ribon
            // 
            this.ribon.BorderMode = System.Windows.Forms.RibbonWindowMode.NonClientAreaCustomDrawn;
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
            this.ribon.Tabs.Add(this.ribbonTab2);
            this.ribon.Tabs.Add(this.ribbonTab3);
            this.ribon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            resources.ApplyResources(this.ribbonTab2, "ribbonTab2");
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.syncRibbonButton);
            this.ribbonPanel3.Items.Add(this.changeRibbonButton);
            resources.ApplyResources(this.ribbonPanel3, "ribbonPanel3");
            // 
            // syncRibbonButton
            // 
            this.syncRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("syncRibbonButton.Image")));
            this.syncRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("syncRibbonButton.SmallImage")));
            resources.ApplyResources(this.syncRibbonButton, "syncRibbonButton");
            this.syncRibbonButton.Click += new System.EventHandler(this.syncRibbonButton_Click);
            // 
            // changeRibbonButton
            // 
            this.changeRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("changeRibbonButton.Image")));
            this.changeRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("changeRibbonButton.SmallImage")));
            resources.ApplyResources(this.changeRibbonButton, "changeRibbonButton");
            this.changeRibbonButton.Click += new System.EventHandler(this.changeRibbonButton_Click);
            // 
            // ribbonPanel5
            // 
            resources.ApplyResources(this.ribbonPanel5, "ribbonPanel5");
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            resources.ApplyResources(this.ribbonTab3, "ribbonTab3");
            // 
            // ribbonPanel4
            // 
            resources.ApplyResources(this.ribbonPanel4, "ribbonPanel4");
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.CheckBoxes = true;
            this.listView1.GridLines = true;
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
            // diffControl
            // 
            resources.ApplyResources(this.diffControl, "diffControl");
            this.diffControl.Name = "diffControl";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diffControl);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ribon);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }
        
        #endregion
        private System.Windows.Forms.Ribbon ribon;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private UIControls.DiffControl diffControl;
        private System.Windows.Forms.RibbonHost ribbonHost1;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox1;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup1;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton syncRibbonButton;
        private System.Windows.Forms.RibbonButton changeRibbonButton;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
    }
}

