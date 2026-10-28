using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class Schedule_Form : BaseForm
    {
        private bool showingByBookingTime = true;
        private Label emptyHintBooking;
        private Label emptyHintComing;
        private Font ownRowFont;

        public Schedule_Form(UserContext user) : base(user)
        {
            InitializeComponent();

            this.FormClosed += (s, e) => Application.Exit();

            this.Resize += Schedule_Form_Resize;
        }

        public Schedule_Form(string userInfo) : this(new UserContext(userInfo)) { }

        private void Schedule_Form_Load(object sender, EventArgs e)
        {
            ShowUserInfo(label_RoleNameSch, label_infoRole, pictureBox_AvatarStudent, pictureBox_AvatarAssistant, pictureBox_AvatarProfesor);

            ownRowFont = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            GridStyle.Apply(dataGridView_ScheduleTimeOfBooking);
            GridStyle.Apply(dataGridView_ScheduleByComing);

            emptyHintBooking = GridStyle.CreateEmptyHint(roundedPanel_ScheduleTimeOfBooking, dataGridView_ScheduleTimeOfBooking,
                "На цю дату бронювань немає");
            emptyHintComing = GridStyle.CreateEmptyHint(roundedPanel_ByComing, dataGridView_ScheduleByComing,
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

            dateTimePicker_ScheduleByComing.MinDate = DateTime.Today;
            dateTimePicker_ScheduleTimeOfBooking.MinDate = DateTime.Today;

            this.VisibleChanged += (s, ev) => { if (this.Visible) LoadActiveSchedule(); };

            this.MinimumSize = new Size(1050, 795);
        }

        private void Schedule_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            bool isCompactMode = this.ClientSize.Width < 1700;

            if (isCompactMode)
            {
                panel_Menu.Width = 100;

                if (button_PanelMainForm != null) button_PanelMainForm.Visible = false;
                if (button_PanelAddReq != null) button_PanelAddReq.Visible = false;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = false;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = false;
                if (button_PanelDelReq != null) button_PanelDelReq.Visible = false;

                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = false;
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = false;
                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = false;
                if (label_RoleNameSch != null) label_RoleNameSch.Visible = false;
                if (label_infoRole != null) label_infoRole.Visible = false;

                if (pictureBox_Logo != null) pictureBox_Logo.Left = (100 - pictureBox_Logo.Width) / 2;
                if (pictureBox_LogoMakeReq != null) pictureBox_LogoMakeReq.Left = (100 - pictureBox_LogoMakeReq.Width) / 2;
                if (pictureBox_LogoMySchedule != null) pictureBox_LogoMySchedule.Left = (100 - pictureBox_LogoMySchedule.Width) / 2;
                if (pictureBox_LogoSchedule != null) pictureBox_LogoSchedule.Left = (100 - pictureBox_LogoSchedule.Width) / 2;
                if (pictureBox_LogoDel != null) pictureBox_LogoDel.Left = (100 - pictureBox_LogoDel.Width) / 2;
            }
            else
            {
                panel_Menu.Width = 382;

                if (button_PanelMainForm != null) button_PanelMainForm.Visible = true;
                if (button_PanelAddReq != null) button_PanelAddReq.Visible = true;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = true;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = true;
                if (button_PanelDelReq != null) button_PanelDelReq.Visible = true;
                if (label_RoleNameSch != null) label_RoleNameSch.Visible = true;
                if (label_infoRole != null) label_infoRole.Visible = true;

                if (currentUser != null)
                {
                    pictureBox_AvatarStudent.Visible = (currentUser.Role == UserRole.Student);
                    pictureBox_AvatarAssistant.Visible = (currentUser.Role == UserRole.Assistant);
                    pictureBox_AvatarProfesor.Visible = (currentUser.Role == UserRole.Professor);
                }

                if (pictureBox_Logo != null) pictureBox_Logo.Left = 43;
                if (pictureBox_LogoMakeReq != null) pictureBox_LogoMakeReq.Left = 44;
                if (pictureBox_LogoMySchedule != null) pictureBox_LogoMySchedule.Left = 47;
                if (pictureBox_LogoSchedule != null) pictureBox_LogoSchedule.Left = 47;
                if (pictureBox_LogoDel != null) pictureBox_LogoDel.Left = 44;
            }

            if (panel_AllElements != null)
            {
                if (isCompactMode)
                {
                    panel_AllElements.Left = 115;
                    panel_AllElements.Width = Math.Max(800, this.ClientSize.Width - panel_AllElements.Left - 15);
                    panel_AllElements.Height = Math.Max(600, this.ClientSize.Height - 40);
                }
                else
                {
                    panel_AllElements.Left = 560;
                    panel_AllElements.Width = Math.Max(1000, this.ClientSize.Width - panel_AllElements.Left - 40);
                    panel_AllElements.Height = Math.Max(700, this.ClientSize.Height - 40);
                }

                int innerWidth = panel_AllElements.Width - 40;

                if (roundedPanel_ScheduleTimeOfBooking != null)
                {
                    roundedPanel_ScheduleTimeOfBooking.Width = innerWidth;
                    roundedPanel_ScheduleTimeOfBooking.Height = panel_AllElements.Height - roundedPanel_ScheduleTimeOfBooking.Top - 30;
                }

                if (roundedPanel_ByComing != null)
                {
                    roundedPanel_ByComing.Width = innerWidth;
                    roundedPanel_ByComing.Height = panel_AllElements.Height - roundedPanel_ByComing.Top - 30;
                }

                if (dataGridView_ScheduleTimeOfBooking != null)
                {
                    dataGridView_ScheduleTimeOfBooking.Width = roundedPanel_ScheduleTimeOfBooking.Width - 50;
                    dataGridView_ScheduleTimeOfBooking.Height = roundedPanel_ScheduleTimeOfBooking.Height - dataGridView_ScheduleTimeOfBooking.Top - 30;
                }

                if (dataGridView_ScheduleByComing != null)
                {
                    dataGridView_ScheduleByComing.Width = roundedPanel_ByComing.Width - 50;
                    dataGridView_ScheduleByComing.Height = roundedPanel_ByComing.Height - dataGridView_ScheduleByComing.Top - 30;
                }
            }
        }

        private void LoadResourceComboBox()
        {
            comboBox_Resource.Items.Clear();
            List<Resourse> resources = AppServices.Scheduler.GetResourses();

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

            foreach (Request r in AppServices.Scheduler.GetRequestsByDate(date))
            {
                int i = grid.Rows.Add(
                    FormatInterval(r.Interval),
                    r.Person.Name,
                    r.Resourse.NAME,
                    r.TypeOfWork.ToDisplayName());
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

            var requests = AppServices.Scheduler.GetRequestsByDate(date)
                .Where(r => r.Resourse.ID == selectedResource.ID)
                .ToList();

            foreach (Request r in requests)
            {
                int i = grid.Rows.Add(
                    FormatInterval(r.Interval),
                    r.Person.Name,
                    r.TypeOfWork.ToDisplayName());
            }

            emptyHintComing.Visible = grid.Rows.Count == 0;
        }

        private static string FormatInterval(TimeInterval interval)
        {
            return $"{interval.Start:hh\\:mm} – {interval.End:hh\\:mm}";
        }

        private void button_PanelMainForm_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void button_PanelAddReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void button_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void button_PanelDelReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);

        private void pictureBox_Logo_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
        private void pictureBox1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
    }
}