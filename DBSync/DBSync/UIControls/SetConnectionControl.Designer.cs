namespace DBSync
{
    partial class SetConnectionControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetConnectionControl));
            this.lblBd = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.chbIntegratedSecuritySource = new System.Windows.Forms.CheckBox();
            this.cbDbSource = new System.Windows.Forms.ComboBox();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.chbSavePass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBd
            // 
            resources.ApplyResources(this.lblBd, "lblBd");
            this.lblBd.Name = "lblBd";
            this.lblBd.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblPass
            // 
            resources.ApplyResources(this.lblPass, "lblPass");
            this.lblPass.Name = "lblPass";
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // tbPass
            // 
            resources.ApplyResources(this.tbPass, "tbPass");
            this.tbPass.Name = "tbPass";
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbUser
            // 
            resources.ApplyResources(this.tbUser, "tbUser");
            this.tbUser.Name = "tbUser";
            // 
            // lblServer
            // 
            resources.ApplyResources(this.lblServer, "lblServer");
            this.lblServer.Name = "lblServer";
            // 
            // chbIntegratedSecuritySource
            // 
            resources.ApplyResources(this.chbIntegratedSecuritySource, "chbIntegratedSecuritySource");
            this.chbIntegratedSecuritySource.Name = "chbIntegratedSecuritySource";
            this.chbIntegratedSecuritySource.UseVisualStyleBackColor = true;
            this.chbIntegratedSecuritySource.CheckedChanged += new System.EventHandler(this.chbIntegratedSecuritySource_CheckedChanged);
            // 
            // cbDbSource
            // 
            resources.ApplyResources(this.cbDbSource, "cbDbSource");
            this.cbDbSource.FormattingEnabled = true;
            this.cbDbSource.Name = "cbDbSource";
            this.cbDbSource.DropDown += new System.EventHandler(this.cbDbSource_DropDown);
            this.cbDbSource.SelectedIndexChanged += new System.EventHandler(this.cbDbSource_SelectedIndexChanged);
            // 
            // cbServer
            // 
            resources.ApplyResources(this.cbServer, "cbServer");
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Name = "cbServer";
            this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // chbSavePass
            // 
            resources.ApplyResources(this.chbSavePass, "chbSavePass");
            this.chbSavePass.Name = "chbSavePass";
            this.chbSavePass.UseVisualStyleBackColor = true;
            // 
            // SetConnectionControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbSavePass);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.lblBd);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.chbIntegratedSecuritySource);
            this.Controls.Add(this.cbDbSource);
            this.Controls.Add(this.cbServer);
            this.Name = "SetConnectionControl";
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBd;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.CheckBox chbIntegratedSecuritySource;
        private System.Windows.Forms.ComboBox cbDbSource;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.CheckBox chbSavePass;
    }
}
