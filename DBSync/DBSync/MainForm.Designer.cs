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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribon = new System.Windows.Forms.Ribbon();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
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
            this.syncRibbonButton = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribon
            // 
            this.ribon.BorderMode = System.Windows.Forms.RibbonWindowMode.NonClientAreaCustomDrawn;
            this.ribon.CaptionBarVisible = false;
            this.ribon.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ribon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribon.Location = new System.Drawing.Point(0, 0);
            this.ribon.Minimized = false;
            this.ribon.Name = "ribon";
            // 
            // 
            // 
            this.ribon.OrbDropDown.BorderRoundness = 8;
            this.ribon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribon.OrbDropDown.Name = "";
            this.ribon.OrbDropDown.Size = new System.Drawing.Size(0, 72);
            this.ribon.OrbDropDown.TabIndex = 0;
            this.ribon.OrbImage = null;
            this.ribon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribon.OrbText = "Orb";
            this.ribon.OrbVisible = false;
            // 
            // 
            // 
            this.ribon.QuickAcessToolbar.Visible = false;
            this.ribon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribon.Size = new System.Drawing.Size(692, 134);
            this.ribon.TabIndex = 6;
            this.ribon.Tabs.Add(this.ribbonTab2);
            this.ribon.Tabs.Add(this.ribbonTab3);
            this.ribon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Text = "ribbonTab2";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.syncRibbonButton);
            this.ribbonPanel3.Text = "ribbonPanel3";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel4);
            this.ribbonTab3.Text = "ribbonTab3";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Text = "ribbonPanel4";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 140);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(663, 152);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Text = "ribbonPanel2";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Text = "ribbonPanel1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonHost1
            // 
            this.ribbonHost1.HostedControl = null;
            this.ribbonHost1.Text = "ribbonHost1";
            // 
            // ribbonTextBox1
            // 
            this.ribbonTextBox1.Text = "ribbonTextBox1";
            this.ribbonTextBox1.TextBoxText = "";
            // 
            // ribbonItemGroup1
            // 
            this.ribbonItemGroup1.Text = "ribbonItemGroup1";
            // 
            // diffControl
            // 
            this.diffControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diffControl.Location = new System.Drawing.Point(12, 307);
            this.diffControl.Name = "diffControl";
            this.diffControl.Size = new System.Drawing.Size(663, 120);
            this.diffControl.TabIndex = 5;
            // 
            // syncRibbonButton
            // 
            this.syncRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("syncRibbonButton.Image")));
            this.syncRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("syncRibbonButton.SmallImage")));
            this.syncRibbonButton.Text = "Sync";
            this.syncRibbonButton.Click += new System.EventHandler(this.syncRibbonButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 439);
            this.Controls.Add(this.diffControl);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ribon);
            this.Name = "MainForm";
            this.Text = "Main";
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
    }
}

