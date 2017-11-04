using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using FastColoredTextBoxNS;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBSync.UIControls
{
    public partial class DiffControl : UserControl, ILocalizeControl
    {
        private readonly Brush greenStyle = new SolidBrush(Color.FromArgb(70, Color.Green));
        private readonly Brush redStyle = new SolidBrush(Color.FromArgb(50, Color.Red));
        private readonly Brush grayStyle = new SolidBrush(Color.FromArgb(50, Color.Gray));

        private Int32 updating = 0;
        public DiffControl()
        {
            InitializeComponent();
            textBox1.Scroll += ScrollbarsUpdated;
            textBox2.Scroll += ScrollbarsUpdated;
        }

        private void ScrollbarsUpdated(Object sender, EventArgs e)
        {
            if (updating > 0) return;

            FastColoredTextBox textBox = (FastColoredTextBox)sender;
            Int32 horizontalValue = textBox.HorizontalScroll.Value;
            Int32 verticalValue = textBox.VerticalScroll.Value;
            if (textBox == textBox1)
            {
                UpdateScroll(textBox2, horizontalValue, verticalValue);
            }
            else if (textBox == textBox2)
            {
                UpdateScroll(textBox1, horizontalValue, verticalValue);
            }

            textBox.Refresh();            
        }

        private void UpdateScroll(FastColoredTextBox tb, Int32 horizontalValue, Int32 verticalValue)
        {
            if (updating > 0) return;
            updating++;
            Boolean updated = false;
            if (tb.HorizontalScroll.Visible && tb.HorizontalScroll.Value != horizontalValue)
            {
                horizontalValue = Math.Min(tb.HorizontalScroll.Maximum, horizontalValue);
                tb.HorizontalScroll.Value = horizontalValue;                
                updated = true;
            }

            if (tb.VerticalScroll.Visible && tb.VerticalScroll.Value != verticalValue)
            {
                verticalValue = Math.Min(tb.VerticalScroll.Maximum, verticalValue);
                tb.VerticalScroll.Value = verticalValue;                
                updated = true;
            }

            if (updated)
            {
                tb.UpdateScrollbars();
                tb.Refresh();
            }
            updating--;
        }

        public void SetText(String oldText, String newText)
        {
            oldText = oldText ?? String.Empty;
            newText = newText ?? String.Empty;

            SideBySideDiffModel diff = ( new SideBySideDiffBuilder(new Differ()) ).BuildDiffModel(oldText, newText);
            DiffPaneModel Text1 = diff.NewText;
            DiffPaneModel Text2 = diff.OldText;

            FillText(textBox1, Text1);
            FillText(textBox2, Text2);
        }

        private void FillText(FastColoredTextBox tb, DiffPaneModel text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Lines.Count; i++)
            {
                sb.AppendLine(text.Lines[i].Text);
            }
            tb.Text = sb.ToString();

            for (int i = 0; i < text.Lines.Count; i++)
            {
                switch (text.Lines[i].Type)
                {
                    case ChangeType.Deleted:
                        tb[i].BackgroundBrush = redStyle;
                        break;
                    case ChangeType.Imaginary:
                        tb[i].BackgroundBrush = grayStyle;
                        break;
                    case ChangeType.Inserted:
                        tb[i].BackgroundBrush = greenStyle;
                        break;
                    case ChangeType.Modified:
                       tb[i].BackgroundBrush = redStyle;
                        break;
                    case ChangeType.Unchanged:
                        tb[i].BackgroundBrush = Brushes.White;
                        break;
                }
            }
        }

       

        ~DiffControl()
        {
            Dispose(false);
        }

        public void UpdateLocalization()
        {
           
        }
    }
}
