using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 12;
        public Color BorderColor { get; set; } = Color.LightGray;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                int arcSize = CornerRadius * 2;
                path.AddArc(rect.X, rect.Y, arcSize, arcSize, 180, 90);
                path.AddArc(rect.Right - arcSize, rect.Y, arcSize, arcSize, 270, 90);
                path.AddArc(rect.Right - arcSize, rect.Bottom - arcSize, arcSize, arcSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - arcSize, arcSize, arcSize, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(BorderColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}