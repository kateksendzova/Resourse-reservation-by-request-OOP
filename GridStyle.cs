using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public static class GridStyle
    {
        public static readonly Color HeaderColor = Color.DarkCyan;
        public static readonly Color OwnRowColor = Color.LightCyan;
        public static readonly Color SelectedColor = Color.PaleTurquoise;
        public static readonly Color StripeColor = Color.FromArgb(246, 251, 251);

        public static void Apply(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.Gainsboro;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 42;
            grid.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            grid.RowTemplate.Height = 38;
            grid.DefaultCellStyle.Font = new Font("Century Gothic", 9.5F);
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            grid.DefaultCellStyle.SelectionBackColor = SelectedColor;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = StripeColor;

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public static Label CreateEmptyHint(Control panel, DataGridView grid, string text)
        {
            var hint = new Label
            {
                Text = text,
                Font = new Font("Century Gothic", 10.5F),
                ForeColor = Color.Gray,
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(grid.Left, grid.Top + grid.ColumnHeadersHeight + 20, grid.Width, 40),
                Visible = false
            };
            panel.Controls.Add(hint);
            hint.BringToFront();
            return hint;
        }
    }
}
