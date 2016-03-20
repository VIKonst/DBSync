namespace VIK.DBSync.UITest
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
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDB = new System.Windows.Forms.TextBox();
            this.btnShowScript = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.cbIntegrated = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(12, 12);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(217, 20);
            this.tbServer.TabIndex = 0;
            // 
            // tbDB
            // 
            this.tbDB.Location = new System.Drawing.Point(235, 12);
            this.tbDB.Name = "tbDB";
            this.tbDB.Size = new System.Drawing.Size(217, 20);
            this.tbDB.TabIndex = 1;
            // 
            // btnShowScript
            // 
            this.btnShowScript.Location = new System.Drawing.Point(12, 47);
            this.btnShowScript.Name = "btnShowScript";
            this.btnShowScript.Size = new System.Drawing.Size(75, 23);
            this.btnShowScript.TabIndex = 2;
            this.btnShowScript.Text = "ShowScript";
            this.btnShowScript.UseVisualStyleBackColor = true;
            this.btnShowScript.Click += new System.EventHandler(this.btnShowScript_Click);
            // 
            // tbScript
            // 
            this.tbScript.Location = new System.Drawing.Point(12, 76);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(490, 196);
            this.tbScript.TabIndex = 3;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(272, 47);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(141, 20);
            this.tbPass.TabIndex = 4;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(109, 47);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(141, 20);
            this.tbLogin.TabIndex = 5;
            // 
            // cbIntegrated
            // 
            this.cbIntegrated.AutoSize = true;
            this.cbIntegrated.Location = new System.Drawing.Point(422, 47);
            this.cbIntegrated.Name = "cbIntegrated";
            this.cbIntegrated.Size = new System.Drawing.Size(53, 17);
            this.cbIntegrated.TabIndex = 6;
            this.cbIntegrated.Text = "Integr";
            this.cbIntegrated.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 284);
            this.Controls.Add(this.cbIntegrated);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbScript);
            this.Controls.Add(this.btnShowScript);
            this.Controls.Add(this.tbDB);
            this.Controls.Add(this.tbServer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDB;
        private System.Windows.Forms.Button btnShowScript;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.CheckBox cbIntegrated;
    }
}

