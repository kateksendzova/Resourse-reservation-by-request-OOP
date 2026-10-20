using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 30;
        public Color BorderColor { get; set; } = Color.DarkCyan;
        public int BorderSize { get; set; } = 1;

        private bool isSelected = false;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                UpdateColors();
                this.Invalidate();
            }
        }

        private bool isHovered = false;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(110, 37);
            this.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;

            UpdateColors();

            this.MouseEnter += (s, e) => { isHovered = true; UpdateColors(); this.Invalidate(); };
            this.MouseLeave += (s, e) => { isHovered = false; UpdateColors(); this.Invalidate(); };
        }

        private void UpdateColors()
        {
            // Якщо кнопка обрана АБО під курсором миші -> темний фон, світлий текст
            if (IsSelected || isHovered)
            {
                this.BackColor = Color.DarkCyan;
                this.ForeColor = Color.AliceBlue;
            }
            else
            {
                this.BackColor = Color.AliceBlue;
                this.ForeColor = Color.DarkCyan;
            }
        }

        private GraphicsPath GetItemPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = (radius <= 0 || radius > rect.Height / 2) ? rect.Height / 2 : radius;
            int diameter = r * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);
            int smoothSize = BorderSize > 0 ? BorderSize : 2;

            using (GraphicsPath pathSurface = GetItemPath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetItemPath(rectBorder, BorderRadius - BorderSize))
            using (Pen penSurface = new Pen(this.Parent?.BackColor ?? Color.AliceBlue, smoothSize))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                this.Region = new Region(pathSurface);

                // 1. Малюємо фон
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillPath(brush, pathSurface);
                }

                // 2. Згладжуємо краї
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                // 3. Малюємо рамку
                if (BorderSize >= 1)
                {
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }

            // 4. МАКСИМАЛЬНО ВАЖЛИВО: Малюємо текст по центру вручну, щоб його було чітко видно
            TextRenderer.DrawText(
                pevent.Graphics,
                this.Text,
                this.Font,
                this.ClientRectangle,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
    }
}