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

        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            button_ClearAll.Click += button_ClearAll_Click;
            button_AddRequest.Click += button_AddRequest_Click;


            this.FormClosed += (s, e) => Application.Exit();
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            LoadResourcesToListBox();
            LoadTypeOfWorkToListBox();

            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.MinDate = DateTime.Today;

            ResetInputs();

            listBox_Resources.SelectedIndexChanged += (s, args) => UpdateRequestPreview();
            listBox_Priority.SelectedIndexChanged += (s, args) => UpdateRequestPreview();
            monthCalendar.DateChanged += (s, args) => UpdateRequestPreview();
            TimePicker_StartOfWork.ValueChanged += (s, args) => UpdateRequestPreview();
            dateTimePicker_Interval.ValueChanged += (s, args) => UpdateRequestPreview();

            UpdateRequestPreview();
        }

        private void LoadResourcesToListBox()
        {
            List<Resourse> resources = scheduler.GetResourses();

            listBox_Resources.DataSource = resources;
            listBox_Resources.DisplayMember = "NAME";
            listBox_Resources.ValueMember = "ID";
        }

        private void LoadTypeOfWorkToListBox()
        {
            listBox_Priority.Format += (s, e) =>
            {
                if (e.ListItem is TypeOfWork type)
                {
                    e.Value = TypeOfWorkToText(type);
                }
            };

            listBox_Priority.DataSource = Enum.GetValues(typeof(TypeOfWork));
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
            if (listBox_Resources.Items.Count > 0)
                listBox_Resources.SelectedIndex = 0;

            if (listBox_Priority.Items.Count > 0)
                listBox_Priority.SelectedIndex = 0;

            monthCalendar.SetDate(DateTime.Today);
            TimePicker_StartOfWork.Value = DateTime.Today.AddHours(8);
            dateTimePicker_Interval.Value = DateTime.Today.AddHours(1);
        }

        private void UpdateRequestPreview()
        {
            var resourse = listBox_Resources.SelectedItem as Resourse;
            if (resourse == null || listBox_Priority.SelectedItem == null)
            {
                richTextBox_request.Clear();
                return;
            }

            TypeOfWork type = (TypeOfWork)listBox_Priority.SelectedItem;
            DateTime date = monthCalendar.SelectionStart.Date;
            TimeSpan start = GetTime(TimePicker_StartOfWork);
            TimeSpan duration = GetTime(dateTimePicker_Interval);
            TimeSpan end = start + duration;

            var sb = new StringBuilder();
            sb.AppendLine($"Користувач: {currentName}\n");
            sb.AppendLine($"Роль: {RoleToText(currentRole)}\n");
            sb.AppendLine($"Обладнання: {resourse.NAME} \n");
            sb.AppendLine($"Дата: {date:dd.MM.yyyy} \n");
            sb.AppendLine($"Час: {start:hh\\:mm} - {end:hh\\:mm}\n");
            sb.AppendLine($"Тривалість: {(int)duration.TotalHours} год {duration.Minutes} хв\n");
            sb.AppendLine($"Тип роботи: {TypeOfWorkToText(type)} \n");

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
            var resourse = listBox_Resources.SelectedItem as Resourse;
            if (resourse == null || listBox_Priority.SelectedItem == null)
            {
                MessageBox.Show("Оберіть обладнання та тип роботи.", "Попередження",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TypeOfWork type = (TypeOfWork)listBox_Priority.SelectedItem;
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
    }
}