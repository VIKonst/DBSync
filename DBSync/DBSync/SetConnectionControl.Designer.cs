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
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbIntegratedSecuritySource = new System.Windows.Forms.CheckBox();
            this.cbDbSource = new System.Windows.Forms.ComboBox();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "User:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(81, 121);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(158, 20);
            this.tbPass.TabIndex = 22;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(81, 92);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(158, 20);
            this.tbUser.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Server:";
            // 
            // chbIntegratedSecuritySource
            // 
            this.chbIntegratedSecuritySource.AutoSize = true;
            this.chbIntegratedSecuritySource.Location = new System.Drawing.Point(81, 67);
            this.chbIntegratedSecuritySource.Name = "chbIntegratedSecuritySource";
            this.chbIntegratedSecuritySource.Size = new System.Drawing.Size(139, 17);
            this.chbIntegratedSecuritySource.TabIndex = 19;
            this.chbIntegratedSecuritySource.Text = "Windows autentification";
            this.chbIntegratedSecuritySource.UseVisualStyleBackColor = true;
            this.chbIntegratedSecuritySource.CheckedChanged += new System.EventHandler(this.chbIntegratedSecuritySource_CheckedChanged);
            // 
            // cbDbSource
            // 
            this.cbDbSource.FormattingEnabled = true;
            this.cbDbSource.Location = new System.Drawing.Point(81, 164);
            this.cbDbSource.Name = "cbDbSource";
            this.cbDbSource.Size = new System.Drawing.Size(158, 21);
            this.cbDbSource.TabIndex = 18;
            this.cbDbSource.DropDown += new System.EventHandler(this.cbDbSource_DropDown);
            this.cbDbSource.SelectedIndexChanged += new System.EventHandler(this.cbDbSource_SelectedIndexChanged);
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(81, 38);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(158, 21);
            this.cbServer.TabIndex = 17;
            this.cbServer.Text = "(local)";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(36, 11);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(32, 13);
            this.titleLabel.TabIndex = 26;
            this.titleLabel.Text = "Title";
            // 
            // SetConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbIntegratedSecuritySource);
            this.Controls.Add(this.cbDbSource);
            this.Controls.Add(this.cbServer);
            this.Name = "SetConnectionControl";
            this.Size = new System.Drawing.Size(263, 203);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbIntegratedSecuritySource;
        private System.Windows.Forms.ComboBox cbDbSource;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Label titleLabel;
    }
}
