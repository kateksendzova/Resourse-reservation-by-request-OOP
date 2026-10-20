using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using КурсоваРобота_Ксендзова_ПЗ27.Properties;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private int selectedResourceID = 0;
        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
        }

        public AddRequestForm(string userInfo, int resourceID) : this(userInfo)
        {
            selectedResourceID = resourceID;

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

            monthCalendar.DateChanged += (s, args) =>
            {
                if (monthCalendar.SelectionStart.Date == DateTime.Today)
                {
                    int targetHour = Math.Max(8, DateTime.Now.Hour);
                    TimePicker_StartOfWork.Value = DateTime.Today.AddHours(targetHour);
                }
                else
                {
                    TimePicker_StartOfWork.Value = DateTime.Today.AddHours(8);
                }

                UpdateRequestPreview();
            };

            TimePicker_StartOfWork.ValueChanged += (s, args) => UpdateRequestPreview();
            dateTimePicker_Interval.ValueChanged += (s, args) => UpdateRequestPreview();

            UpdateRequestPreview();
            LoadNameAndRole();
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

        private void LoadNameAndRole()
        {
            label_RoleName.Text = currentName;

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


            if (monthCalendar.SelectionStart.Date == DateTime.Today)
            {
                int targetHour = Math.Max(8, DateTime.Now.Hour);
                TimePicker_StartOfWork.Value = DateTime.Today.AddHours(targetHour);
            }
            else
            {
                TimePicker_StartOfWork.Value = DateTime.Today.AddHours(8);
            }

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
            sb.AppendLine($"Роль: {RoleToText(currentRole)}\n\n");
            sb.AppendLine($"Обладнання: {resourse.NAME} \n\n");
            sb.AppendLine($"Дата: {date:dd.MM.yyyy} \n");
            sb.AppendLine($"Час: {start:hh\\:mm} - {end:hh\\:mm}\n");
            sb.AppendLine($"Тривалість: {(int)duration.TotalHours} год {duration.Minutes} хв\n\n");
            sb.AppendLine($"Тип роботи: {TypeOfWorkToText(type)} \n");

            richTextBox_request.Text = sb.ToString();
        }

        private string ValidateInput(DateTime date, TimeSpan start, TimeSpan duration)
        {
            if (duration <= TimeSpan.Zero)
                return "Тривалість роботи має бути більшою за 00:00";

            if (start < WorkDayStart || start + duration > WorkDayEnd)
                return "Лабораторія працює з 08:00 до 19:00. Оберіть час у цих межах";

            if (date == DateTime.Today && start < DateTime.Now.TimeOfDay)
                return "Цей час на сьогодні вже минув";

            return null;
        }

        private void button_AddRequest_Click(object sender, EventArgs e)
        {
            if (listBox_Resources.SelectedItem is not Resourse resource)
            {
                MessageBox.Show("Будь ласка, оберіть обладнання зі списку!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime reservDay = monthCalendar.SelectionStart.Date;
            TimeSpan startTime = GetTime(TimePicker_StartOfWork);
            TimeSpan interval = GetTime(dateTimePicker_Interval);

            if (listBox_Priority.SelectedItem == null)
            {
                MessageBox.Show("Оберіть тип роботи!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TypeOfWork typeOfWork = (TypeOfWork)listBox_Priority.SelectedItem;

            string validationError = ValidateInput(reservDay, startTime, interval);
            if (validationError != null)
            {
                MessageBox.Show(validationError, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Person person = scheduler.GetOrCreatePerson(currentName, currentRole);

            var result = scheduler.TryAddRequest(resource, person, reservDay, startTime, interval, typeOfWork);

            if (result.IsAvailable)
            {
                MessageBox.Show(result.Message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInputs();
            }
            else
            {
                MessageBox.Show(result.Message, "Помилка бронювання", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            ResetInputs();

            UpdateRequestPreview();
        }

        private void button_PanelMane_Click(object sender, EventArgs e)
        {
            MainForm_FirstWindow mainForm = new MainForm_FirstWindow(currentUserInfo);
            mainForm.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRequestForm delete = new DeleteRequestForm(currentUserInfo);
            delete.Show();
            this.Hide();
        }

        private void button_PanelMySchedule_Click(object sender, EventArgs e)
        {
            MySchedule_Form mySchedule_Form = new MySchedule_Form(currentUserInfo);
            mySchedule_Form.Show();
            this.Hide();
        }

        private void button_PanelSchedule_Click(object sender, EventArgs e)
        {
            Schedule_Form schedule_Form = new Schedule_Form(currentUserInfo);
            schedule_Form.Show();
            this.Hide();
        }
    }
}