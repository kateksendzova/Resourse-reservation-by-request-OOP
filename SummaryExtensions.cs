using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public static class SummaryExtensions
    {
        private static readonly Font CaptionFont = new Font("Century Gothic", 9F, FontStyle.Regular);
        private static readonly Font ValueFont = new Font("Century Gothic", 10.5F, FontStyle.Bold);

        public static void AddField(this RichTextBox box, string caption, string value, bool isPlaceholder = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionFont = CaptionFont;
            box.SelectionColor = Color.DimGray;
            box.AppendText(caption + "\n");

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionFont = ValueFont;
            box.SelectionColor = isPlaceholder ? Color.Gray : Color.Black;
            box.AppendText(value + "\n\n");
        }
    }
}