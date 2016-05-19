namespace DBSync
{
    partial class StartWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.sourceConnectPanel = new System.Windows.Forms.Panel();
            this.setSourceConnection = new DBSync.SetConnectionControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setDestConnection = new DBSync.SetConnectionControl();
            this.btnCompare = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sourceConnectPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceConnectPanel
            // 
            this.sourceConnectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceConnectPanel.Controls.Add(this.setSourceConnection);
            resources.ApplyResources(this.sourceConnectPanel, "sourceConnectPanel");
            this.sourceConnectPanel.Name = "sourceConnectPanel";
            // 
            // setSourceConnection
            // 
            resources.ApplyResources(this.setSourceConnection, "setSourceConnection");
            this.setSourceConnection.Name = "setSourceConnection";
            this.setSourceConnection.Load += new System.EventHandler(this.setConnectionControl1_Load);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.setDestConnection);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // setDestConnection
            // 
            resources.ApplyResources(this.setDestConnection, "setDestConnection");
            this.setDestConnection.Name = "setDestConnection";
            this.setDestConnection.Load += new System.EventHandler(this.setConnectionControl2_Load);
            // 
            // btnCompare
            // 
            resources.ApplyResources(this.btnCompare, "btnCompare");
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sourceConnectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartWindow";
            this.Load += new System.EventHandler(this.StartWindow_Load);
            this.sourceConnectPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sourceConnectPanel;
        private SetConnectionControl setSourceConnection;
        private SetConnectionControl setDestConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button button1;
    }
}