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
            this.sourceConnectPanel = new System.Windows.Forms.Panel();
            this.setSourceConnection = new DBSync.SetConnectionControl();
            this.setDestConnection = new DBSync.SetConnectionControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCompare = new System.Windows.Forms.Button();
            this.sourceConnectPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceConnectPanel
            // 
            this.sourceConnectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceConnectPanel.Controls.Add(this.setSourceConnection);
            this.sourceConnectPanel.Location = new System.Drawing.Point(12, 12);
            this.sourceConnectPanel.Name = "sourceConnectPanel";
            this.sourceConnectPanel.Size = new System.Drawing.Size(294, 227);
            this.sourceConnectPanel.TabIndex = 17;
            // 
            // setSourceConnection
            // 
            this.setSourceConnection.Location = new System.Drawing.Point(3, 3);
            this.setSourceConnection.Name = "setSourceConnection";
            this.setSourceConnection.Size = new System.Drawing.Size(286, 216);
            this.setSourceConnection.TabIndex = 18;
            this.setSourceConnection.Title = "Source";
            this.setSourceConnection.Load += new System.EventHandler(this.setConnectionControl1_Load);
            // 
            // setDestConnection
            // 
            this.setDestConnection.Location = new System.Drawing.Point(3, 3);
            this.setDestConnection.Name = "setDestConnection";
            this.setDestConnection.Size = new System.Drawing.Size(290, 223);
            this.setDestConnection.TabIndex = 19;
            this.setDestConnection.Title = "Destination";
            this.setDestConnection.Load += new System.EventHandler(this.setConnectionControl2_Load);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.setDestConnection);
            this.panel1.Location = new System.Drawing.Point(337, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 227);
            this.panel1.TabIndex = 20;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(561, 245);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(81, 34);
            this.btnCompare.TabIndex = 21;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(664, 291);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sourceConnectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartWindow";
            this.Text = "ConfigureConnections";
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
    }
}