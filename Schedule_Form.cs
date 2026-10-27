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

            this.VisibleChanged += (s, ev) => { if (this.Visible) LoadActiveSchedule(); };
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