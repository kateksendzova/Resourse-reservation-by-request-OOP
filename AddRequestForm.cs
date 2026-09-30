using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class AddRequestForm : Form
    {
        private static readonly TimeSpan WorkDayStart = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan WorkDayEnd = new TimeSpan(19, 0, 0);

        private Scheduler scheduler = new Scheduler();
        private string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private Action refreshCurrentView;

        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            button_ClearAll.Click += button_ClearAll_Click;
            button_LikeSchedule.Click += button_LikeSchedule_Click;
            button_ByComing.Click += button_ByComing_Click;
            button_MySchedule.Click += button_MySchedule_Click;
            dateTimePicker_Schedule.ValueChanged += (s, e) => LoadScheduleForDate();
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            LoadResourcesToComboBox();
            LoadTypeOfWorkToComboBox();

            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.MinDate = DateTime.Today;

            SetupGrid(dataGridView_Schedule);
            SetupGrid(dataGridView_ByComing);

            ResetInputs();

            comboBox_ResourseList.SelectedIndexChanged += (s, args) => UpdateRequestPreview();
            comboBox_Priority.SelectedIndexChanged += (s, args) => UpdateRequestPreview();
            monthCalendar.DateChanged += (s, args) => UpdateRequestPreview();
            TimePicker_StartOfWork.ValueChanged += (s, args) => UpdateRequestPreview();
            dateTimePicker_Interval.ValueChanged += (s, args) => UpdateRequestPreview();

            UpdateRequestPreview();
            ShowScheduleView();
        }

        private void LoadResourcesToComboBox()
        {
            List<Resourse> resources = scheduler.GetResourses();

            comboBox_ResourseList.DataSource = resources;
            comboBox_ResourseList.DisplayMember = "NAME";
            comboBox_ResourseList.ValueMember = "ID";
        }

        private void LoadTypeOfWorkToComboBox()
        {
            comboBox_Priority.Format += (s, e) =>
            {
                if (e.ListItem is TypeOfWork type)
                {
                    e.Value = TypeOfWorkToText(type);
                }
            };

            comboBox_Priority.DataSource = Enum.GetValues(typeof(TypeOfWork));
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private static string RoleToText(UserRole role)
        {
            return role switch
            {
                UserRole.Professor => "Викладач",
                UserRole.Assistant => "Аспірант",
                _ => "Студент"
            };
        }

        private static string TypeOfWorkToText(TypeOfWork type)
        {
            return type switch
            {
                TypeOfWork.IndependentWork => "Самостійна робота",
                TypeOfWork.LaboratoryWork => "Лабораторна робота",
                TypeOfWork.DiplomaThesis => "Дипломна робота",
                TypeOfWork.ScientificExperiment => "Науковий експеримент",
                _ => type.ToString()
            };
        }

        private static TimeSpan GetTime(DateTimePicker picker)
        {
            return new TimeSpan(picker.Value.Hour, picker.Value.Minute, 0);
        }

        private void ResetInputs()
        {
            if (comboBox_ResourseList.Items.Count > 0)
                comboBox_ResourseList.SelectedIndex = 0;

            if (comboBox_Priority.Items.Count > 0)
                comboBox_Priority.SelectedIndex = 0;

            monthCalendar.SetDate(DateTime.Today);
            TimePicker_StartOfWork.Value = DateTime.Today.AddHours(8);
            dateTimePicker_Interval.Value = DateTime.Today.AddHours(1);
        }

        private void UpdateRequestPreview()
        {
            var resourse = comboBox_ResourseList.SelectedItem as Resourse;
            if (resourse == null || comboBox_Priority.SelectedItem == null)
            {
                richTextBox_request.Clear();
                return;
            }

            var type = (TypeOfWork)comboBox_Priority.SelectedItem;
            DateTime date = monthCalendar.SelectionStart.Date;
            TimeSpan start = GetTime(TimePicker_StartOfWork);
            TimeSpan duration = GetTime(dateTimePicker_Interval);
            TimeSpan end = start + duration;

            var sb = new StringBuilder();
            sb.AppendLine($"Користувач: {currentName}");
            sb.AppendLine($"Роль: {RoleToText(currentRole)}");
            sb.AppendLine($"Обладнання: {resourse.NAME}");
            sb.AppendLine($"Дата: {date:dd.MM.yyyy}");
            sb.AppendLine($"Час: {start:hh\\:mm} - {end:hh\\:mm}");
            sb.AppendLine($"Тривалість: {(int)duration.TotalHours} год {duration.Minutes} хв");
            sb.AppendLine($"Тип роботи: {TypeOfWorkToText(type)}");

            richTextBox_request.Text = sb.ToString();
        }

        private string ValidateInput(DateTime date, TimeSpan start, TimeSpan duration)
        {
            if (duration <= TimeSpan.Zero)
                return "Тривалість роботи має бути більшою за 00:00.";

            if (start < WorkDayStart || start + duration > WorkDayEnd)
                return "Лабораторія працює з 08:00 до 19:00. Оберіть час у цих межах.";

            if (date == DateTime.Today && start < DateTime.Now.TimeOfDay)
                return "Цей час на сьогодні вже минув.";

            return null;
        }


        private void button_AddRequest_Click(object sender, EventArgs e)
        {
            var resourse = comboBox_ResourseList.SelectedItem as Resourse;
            if (resourse == null || comboBox_Priority.SelectedItem == null)
            {
                MessageBox.Show("Оберіть обладнання та тип роботи.", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var type = (TypeOfWork)comboBox_Priority.SelectedItem;
            DateTime date = monthCalendar.SelectionStart.Date;
            TimeSpan start = GetTime(TimePicker_StartOfWork);
            TimeSpan duration = GetTime(dateTimePicker_Interval);

            string error = ValidateInput(date, start, duration);
            if (error != null)
            {
                MessageBox.Show(error, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Person person = scheduler.GetOrCreatePerson(currentName, currentRole);
                var result = scheduler.TryAddRequest(resourse, person, date, start, duration, type);

                if (result.IsAvailable)
                {
                    MessageBox.Show(result.Message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshCurrentView?.Invoke();
                }
                else
                {
                    MessageBox.Show(result.Message, "Накладка по часу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при роботі з базою даних:\n" + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            ResetInputs();
            richTextBox_request.Clear();
        }

        private void button_LikeSchedule_Click(object sender, EventArgs e)
        {
            ShowScheduleView();
        }

        private void button_ByComing_Click(object sender, EventArgs e)
        {
            SetView(true);
            refreshCurrentView = LoadByComing;
            LoadByComing();
        }

        private void button_MySchedule_Click(object sender, EventArgs e)
        {
            SetView(true);
            refreshCurrentView = LoadMySchedule;
            LoadMySchedule();
        }

        private void SetView(bool byComing)
        {
            dataGridView_ByComing.Visible = byComing;
            dataGridView_Schedule.Visible = !byComing;
            dateTimePicker_Schedule.Visible = !byComing;
        }

        private void ShowScheduleView()
        {
            SetView(false);
            refreshCurrentView = LoadScheduleForDate;
            LoadScheduleForDate();
        }

        private void LoadScheduleForDate()
        {
            dataGridView_Schedule.Rows.Clear();

            var requests = scheduler.GetRequestsByDate(dateTimePicker_Schedule.Value);
            foreach (var r in requests)
            {
                dataGridView_Schedule.Rows.Add(
                    $"{r.Interval.Start:hh\\:mm} - {r.Interval.End:hh\\:mm}",
                    r.Resourse.NAME,
                    r.Person.Name,
                    RoleToText(r.Person.Role),
                    TypeOfWorkToText(r.TypeOfWork));
            }
        }

        private void LoadByComing()
        {
            FillByComingGrid(scheduler.GetRequestsByArrival());
        }

        private void LoadMySchedule()
        {
            var myRequests = scheduler.GetRequestsByPerson(currentName, currentRole);
            FillByComingGrid(myRequests);

            if (myRequests.Count == 0)
            {
                MessageBox.Show("У вас ще немає запитів.", "Мій розклад",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillByComingGrid(IEnumerable<Request> requests)
        {
            dataGridView_ByComing.Rows.Clear();

            foreach (var r in requests)
            {
                dataGridView_ByComing.Rows.Add(
                    r.CreationTime.ToString("dd.MM.yyyy HH:mm:ss"),
                    r.DayOfReservation.ToString("dd.MM.yyyy"),
                    $"{r.Interval.Start:hh\\:mm} - {r.Interval.End:hh\\:mm}",
                    r.Person.Name,
                    r.Resourse.NAME);
            }
        }
    }
}