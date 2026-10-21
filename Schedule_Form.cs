using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class Schedule_Form : Form
    {
        private readonly Scheduler scheduler = new Scheduler();
        private readonly string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private bool showingByBookingTime = true;
        private Label emptyHintBooking;
        private Label emptyHintComing;
        private Font ownRowFont;

        public Schedule_Form(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
        }


        private void Schedule_Form_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();

            ownRowFont = new Font("Century Gothic", 9.5F, FontStyle.Bold);

            StyleGrid(dataGridView_ScheduleTimeOfBooking);
            StyleGrid(dataGridView_ScheduleByComing);

            emptyHintBooking = CreateEmptyHint(roundedPanel_ScheduleTimeOfBooking, dataGridView_ScheduleTimeOfBooking,
                "На цю дату бронювань немає");
            emptyHintComing = CreateEmptyHint(roundedPanel_ByComing, dataGridView_ScheduleByComing,
                "Для обраного обладнання на цю дату бронювань немає");

            foreach (var picker in new[] { dateTimePicker_ScheduleTimeOfBooking, dateTimePicker_ScheduleByComing })
            {
                picker.Value = DateTime.Today;
                picker.ValueChanged += (s, ev) => LoadActiveSchedule();
            }

            LoadResourceComboBox();
            comboBox_Resource.SelectedIndexChanged += (s, ev) => LoadActiveSchedule();

            roundedButton_TimeOfBooking.Click += (s, ev) => ShowView(true);
            roundedButton_Resource.Click += (s, ev) => ShowView(false);

            ShowView(true);

            this.VisibleChanged += (s, ev) => { if (this.Visible) LoadActiveSchedule(); };
        }



        private void LoadResourceComboBox()
        {
            comboBox_Resource.Items.Clear();
            List<Resourse> resources = scheduler.GetResourses();

            comboBox_Resource.DisplayMember = "NAME";
            comboBox_Resource.ValueMember = "ID";
            comboBox_Resource.DataSource = resources;

            if (comboBox_Resource.Items.Count > 0)
                comboBox_Resource.SelectedIndex = 0;
        }


        private void ShowView(bool byBookingTime)
        {
            showingByBookingTime = byBookingTime;

            roundedButton_TimeOfBooking.IsSelected = byBookingTime;
            roundedButton_Resource.IsSelected = !byBookingTime;

            roundedPanel_ScheduleTimeOfBooking.Visible = byBookingTime;
            roundedPanel_ByComing.Visible = !byBookingTime;

            LoadActiveSchedule();
        }

        private void LoadActiveSchedule()
        {
            if (showingByBookingTime) FillByBookingTime();
            else FillByResource();
        }


        private void FillByBookingTime()
        {
            var grid = dataGridView_ScheduleTimeOfBooking;
            grid.Rows.Clear();

            DateTime date = dateTimePicker_ScheduleTimeOfBooking.Value.Date;

            foreach (Request r in scheduler.GetRequestsByDate(date))
            {
                int i = grid.Rows.Add(
                    FormatInterval(r.Interval),
                    r.Person.Name,
                    r.Resourse.NAME,
                    GetWorkTypeName(r.TypeOfWork));

            }

            emptyHintBooking.Visible = grid.Rows.Count == 0;
        }

        private void FillByResource()
        {
            var grid = dataGridView_ScheduleByComing;
            grid.Rows.Clear();

            if (comboBox_Resource.SelectedItem is not Resourse selectedResource)
            {
                emptyHintComing.Visible = true;
                return;
            }

            DateTime date = dateTimePicker_ScheduleByComing.Value.Date;

            var requests = scheduler.GetRequestsByDate(date)
                .Where(r => r.Resourse.ID == selectedResource.ID)
                .ToList();

            foreach (Request r in requests)
            {
                int i = grid.Rows.Add(
                    FormatInterval(r.Interval),
                    r.Person.Name,
                    GetWorkTypeName(r.TypeOfWork));
            }

            emptyHintComing.Visible = grid.Rows.Count == 0;
        }

        private static string FormatInterval(TimeInterval interval)
        {
            return $"{interval.Start:hh\\:mm} – {interval.End:hh\\:mm}";
        }

        private static string GetWorkTypeName(TypeOfWork type) => type switch
        {
            TypeOfWork.LaboratoryWork => "Лабораторна",
            TypeOfWork.DiplomaThesis => "Дипломна",
            TypeOfWork.ScientificExperiment => "Експеримент",
            _ => "Самостійна робота"
        };



        private void StyleGrid(DataGridView grid)
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
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            grid.RowTemplate.Height = 38;
            grid.DefaultCellStyle.Font = new Font("Century Gothic", 9.5F);
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            grid.DefaultCellStyle.SelectionBackColor = Color.PaleTurquoise;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 251, 251);

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private Label CreateEmptyHint(Control panel, DataGridView grid, string text)
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


        private void ParseUserInfo(string userInfo)
        {
            int open = userInfo.LastIndexOf('(');
            int close = userInfo.LastIndexOf(')');

            string namePart = open >= 0 ? userInfo.Substring(0, open) : userInfo;
            string rolePart = (open >= 0 && close > open)
                ? userInfo.Substring(open + 1, close - open - 1).Trim()
                : "Студент";

            currentName = string.Join(" ", namePart.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            currentRole = rolePart switch
            {
                "Викладач" => UserRole.Professor,
                "Аспірант" => UserRole.Assistant,
                _ => UserRole.Student
            };
        }

        private void LoadNameAndRole()
        {
            label_RoleNameSch.Text = currentName;
            label_infoRole.Text = currentRole switch
            {
                UserRole.Professor => "Викладач",
                UserRole.Assistant => "Аспірант",
                _ => "Студент"
            };


            if (currentRole == UserRole.Student)
            {
                pictureBox_AvatarStudent.Visible = true;
                pictureBox_AvatarAssistant.Visible = false;
                pictureBox_AvatarProfesor.Visible = false;
            }
            else if (currentRole == UserRole.Assistant)
            {
                pictureBox_AvatarStudent.Visible = false;
                pictureBox_AvatarAssistant.Visible = true;
                pictureBox_AvatarProfesor.Visible = false;
            }
            else if (currentRole == UserRole.Professor)
            {
                pictureBox_AvatarStudent.Visible = false;
                pictureBox_AvatarAssistant.Visible = false;
                pictureBox_AvatarProfesor.Visible = true;
            }
        }

        private void button_PanelMainForm_Click(object sender, EventArgs e)
        {
            new MainForm_FirstWindow(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelAddReq_Click(object sender, EventArgs e)
        {
            new AddRequestForm(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelMySchedule_Click(object sender, EventArgs e)
        {
            new MySchedule_Form(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelDelReq_Click(object sender, EventArgs e)
        {
            new DeleteRequestForm(currentUserInfo).Show();
            this.Hide();
        }
    }
}