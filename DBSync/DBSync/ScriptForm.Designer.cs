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
            this.resultTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scriptTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // scriptTextBox
            // 
            resources.ApplyResources(this.scriptTextBox, "scriptTextBox");
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
            this.scriptTextBox.BackBrush = null;
            this.scriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scriptTextBox.CharHeight = 14;
            this.scriptTextBox.CharWidth = 8;
            this.scriptTextBox.CommentPrefix = "--";
            this.scriptTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scriptTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.scriptTextBox.IsReplaceMode = false;
            this.scriptTextBox.Language = FastColoredTextBoxNS.Language.SQL;
            this.scriptTextBox.LeftBracket = '(';
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.scriptTextBox.RightBracket = ')';
            this.scriptTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.scriptTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("scriptTextBox.ServiceColors")));
            this.scriptTextBox.Zoom = 100;
            this.scriptTextBox.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            // 
            // btnExecScript
            // 
            resources.ApplyResources(this.btnExecScript, "btnExecScript");
            this.btnExecScript.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnExecScript.Name = "btnExecScript";
            this.btnExecScript.UseVisualStyleBackColor = false;
            this.btnExecScript.Click += new System.EventHandler(this.btnExecScript_Click);
            // 
            // saveBtn
            // 
            resources.ApplyResources(this.saveBtn, "saveBtn");
            this.saveBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // resultTextBox
            // 
            resources.ApplyResources(this.resultTextBox, "resultTextBox");
            this.resultTextBox.AutoCompleteBracketsList = new char[] {
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
            this.resultTextBox.BackBrush = null;
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.CharHeight = 14;
            this.resultTextBox.CharWidth = 8;
            this.resultTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.resultTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.resultTextBox.IsReplaceMode = false;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.resultTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("resultTextBox.ServiceColors")));
            this.resultTextBox.ShowLineNumbers = false;
            this.resultTextBox.Zoom = 100;
            // 
            // ScriptForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.btnExecScript);
            this.Controls.Add(this.scriptTextBox);
            this.Name = "ScriptForm";
            this.Load += new System.EventHandler(this.ScriptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scriptTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox scriptTextBox;
        private System.Windows.Forms.Button btnExecScript;
        private System.Windows.Forms.Button saveBtn;
        private FastColoredTextBoxNS.FastColoredTextBox resultTextBox;
    }
}