namespace DBSync
{
    partial class ScriptForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.scriptTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnExecScript = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scriptTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.scriptTextBox.AutoIndentCharsPatterns = "";
            this.scriptTextBox.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.scriptTextBox.BackBrush = null;
            this.scriptTextBox.CharHeight = 14;
            this.scriptTextBox.CharWidth = 8;
            this.scriptTextBox.CommentPrefix = "--";
            this.scriptTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scriptTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.scriptTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.scriptTextBox.IsReplaceMode = false;
            this.scriptTextBox.Language = FastColoredTextBoxNS.Language.SQL;
            this.scriptTextBox.LeftBracket = '(';
            this.scriptTextBox.Location = new System.Drawing.Point(12, 12);
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.scriptTextBox.RightBracket = ')';
            this.scriptTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.scriptTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("scriptTextBox.ServiceColors")));
            this.scriptTextBox.Size = new System.Drawing.Size(557, 242);
            this.scriptTextBox.TabIndex = 0;
            this.scriptTextBox.Text = "fastColoredTextBox1";
            this.scriptTextBox.Zoom = 100;
            this.scriptTextBox.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            // 
            // btnExecScript
            // 
            this.btnExecScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecScript.Location = new System.Drawing.Point(12, 260);
            this.btnExecScript.Name = "btnExecScript";
            this.btnExecScript.Size = new System.Drawing.Size(89, 38);
            this.btnExecScript.TabIndex = 1;
            this.btnExecScript.Text = "Execute";
            this.btnExecScript.UseVisualStyleBackColor = true;
            this.btnExecScript.Click += new System.EventHandler(this.btnExecScript_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(480, 260);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(89, 38);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 306);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 112);
            this.textBox1.TabIndex = 3;
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 428);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.btnExecScript);
            this.Controls.Add(this.scriptTextBox);
            this.Name = "ScriptForm";
            this.Text = "ScriptForm";
            this.Load += new System.EventHandler(this.ScriptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scriptTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox scriptTextBox;
        private System.Windows.Forms.Button btnExecScript;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}