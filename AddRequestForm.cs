using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class AddRequestForm : Form
    {
        private bool isInitialized = false;
        private Schedule mainSchedule = new Schedule();
        private string currentUserInfo;
        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;

            mainSchedule.LoadFromJson();

            comboBox_Priority.Items.Add("Дипломна робота");
            comboBox_Priority.Items.Add("Науковий експеримент");
            comboBox_Priority.Items.Add("Лабораторна робота");
            comboBox_Priority.Items.Add("Самостійна робота");

            List<Resourse> resourcesList = new List<Resourse>()
            {
                new Resourse(1, "Осцилограф цифровий", true),
                new Resourse(2, "Лазерний станок ЧПК", true),
                new Resourse(3, "3D-принтер", true),
                new Resourse(4, "Спектрометр оптичний", true),
                new Resourse(5, "Паяльна станція термоповітряна", true),
                new Resourse(6, "Генератор сигналів спеціальної форми", true),
                new Resourse(7, "Випробувальний стенд мікроконтролерів", true),
                new Resourse(8, "Фрезерний верстат з ЧПК", true),
                new Resourse(9, "Тепловізор лабораторний", true),
                new Resourse(10, "Аналізатор спектра частот", true)
            };

            comboBox_ResourseList.DataSource = resourcesList;
            comboBox_ResourseList.DisplayMember = "NAME";
            comboBox_ResourseList.ValueMember = "ID";

            comboBox_ResourseList.SelectedIndex = -1;
            comboBox_Priority.SelectedIndex = -1;

            monthCalendar.MinDate = DateTime.Today;

            dateTimePicker_TimeOfWork.Format = DateTimePickerFormat.Custom;
            dateTimePicker_TimeOfWork.CustomFormat = "HH:mm";

            TimePickerStartManual.Format = DateTimePickerFormat.Custom;
            TimePickerStartManual.CustomFormat = "HH:mm";

            checkBox_ManualChoose.Checked = false;
            TimePickerStartManual.Enabled = false;

            checkBox_ManualChoose.CheckedChanged += checkBox_ManualChoose_CheckedChanged;

            isInitialized = true;

            colTime.DataPropertyName = "TimeString";
            colResource.DataPropertyName = "ResourceName";
            ColNameOfPerson.DataPropertyName = "NameOfPerson";
            ColRole.DataPropertyName = "Role";
            ColTypeOfWork.DataPropertyName = "TypeOfWork";

            Col_TimeOfComing.DataPropertyName = "TimeOfComing";
            Col_DayOdReserv.DataPropertyName = "DayOfReservation";
            Col_Interval.DataPropertyName = "IntervalString";
            Col_PIB.DataPropertyName = "PIB";
            Col_Resourse.DataPropertyName = "ResourceName";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainSchedule.SaveToJson();
            Application.Exit();
        }

        private void checkBox_ManualChoose_CheckedChanged(object sender, EventArgs e)
        {
            TimePickerStartManual.Enabled = checkBox_ManualChoose.Checked;
            dateTimePicker_TimeOfWork.Enabled = !checkBox_ManualChoose.Checked;

            if (isInitialized) UpdateRequestPreview();
        }

        public void UpdateRequestPreview()
        {
            if (!isInitialized)
                return;

            richTextBox_request.Clear();

            if (comboBox_ResourseList.SelectedItem is Resourse selectedResourse)
            {
                richTextBox_request.AppendText($"Обладнання: {selectedResourse.NAME}\n");
            }

            DateTime selectedDate = monthCalendar.SelectionStart;
            richTextBox_request.AppendText($"Дата: {selectedDate.ToShortDateString()}\n");

            if (checkBox_ManualChoose.Checked)
            {
                richTextBox_request.AppendText($"Режим: Ручний вибір часу\n");
                richTextBox_request.AppendText($"Час початку: {TimePickerStartManual.Value.ToShortTimeString()}\n");
            }
            else
            {
                richTextBox_request.AppendText($"Режим: Автоматичний підбір вільного часу\n");
                richTextBox_request.AppendText($"Запланована тривалість: {dateTimePicker_TimeOfWork.Value.ToString("HH:mm")} год.\n");
            }

            if (comboBox_Priority.SelectedIndex >= 0)
            {
                richTextBox_request.AppendText($"Тип роботи: {comboBox_Priority.SelectedItem}\n");
            }
        }
        private void DisplayRequests(List<Request> requests)
        {
            var tableData = requests.Select(r => new
            {
                TimeString = $"{r.Interval.Start:hh\\:mm} - {r.Interval.End:hh\\:mm}",
                ResourceName = r.Resourse.NAME,
                NameOfPerson = r.NameOfPerson,
                Role = r.Role,
                TypeOfWork = r.TypeOfWork
            }).ToList();

            dataGridView_Schedule.AutoGenerateColumns = false;
            dataGridView_Schedule.DataSource = null;
            dataGridView_Schedule.DataSource = tableData;
        }
        private void comboBox_ResourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialized) UpdateRequestPreview();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (isInitialized) UpdateRequestPreview();
        }

        private void TimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialized) UpdateRequestPreview();
        }

        private void comboBox_Priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialized) UpdateRequestPreview();
        }

        private void dateTimePicker_TimeOfWork_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialized) UpdateRequestPreview();
        }

        private void dataGridView_Schedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void button_AddRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_ResourseList.SelectedItem is not Resourse selectedRecourse)
                {
                    MessageBox.Show("Оберіть обладнання з списку!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_Priority.SelectedItem == null)
                {
                    MessageBox.Show("Оберіть тип роботи!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime selectedDate = monthCalendar.SelectionStart;
                TimeInterval interval = null;
                Scheduler scheduler = new Scheduler(mainSchedule);
                DateTime finalDate = selectedDate;

                if (checkBox_ManualChoose.Checked)
                {
                    TimeSpan timeStart = TimePickerStartManual.Value.TimeOfDay;
                    TimeSpan duration = dateTimePicker_TimeOfWork.Value.TimeOfDay;
                    TimeSpan timeEnd = timeStart + duration;

                    interval = new TimeInterval(timeStart, timeEnd);
                    finalDate = selectedDate;
                }
                else
                {
                    TimeSpan duration = dateTimePicker_TimeOfWork.Value.TimeOfDay;
                    interval = scheduler.FindAvailableSpot(selectedRecourse.ID, selectedDate, duration);
                    finalDate = selectedDate;

                    if (interval == null)
                    {
                        var nextAvailable = scheduler.FindNextAvailableSpotRecursive(selectedRecourse.ID, selectedDate, duration);

                        if (nextAvailable != null)
                        {
                            interval = nextAvailable.Value.Interval;
                            finalDate = nextAvailable.Value.FoundDate;

                            monthCalendar.SetDate(finalDate);
                        }
                    }

                    if (interval == null)
                    {
                        MessageBox.Show("Немає вікна заданої тривалості ні на цей день, ні найближчим часом для вибраного обладнання!", "Автопідбір", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string infoMessage = $"Знайдено вільний час!\n\nПропонується такий запит, вам підходить?\n" +
                                         $"Обладнання: {selectedRecourse.NAME}\n" +
                                         $"Дата: {finalDate:dd.MM.yyyy}\n" +
                                         $"Інтервал: {interval.Start:hh\\:mm} - {interval.End:hh\\:mm}";

                    MessageBox.Show(infoMessage, "Результат автопідбору", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string selectedWorkType = comboBox_Priority.SelectedItem.ToString();

                string personName = currentUserInfo;
                string personRole = "Студент";

                int bracketIndex = currentUserInfo.LastIndexOf('(');
                if (bracketIndex != -1)
                {
                    personName = currentUserInfo.Substring(0, bracketIndex).Trim();
                    personRole = currentUserInfo.Substring(bracketIndex).Replace("(", "").Replace(")", "").Trim();
                }

                Request newRequest = new Request(selectedRecourse, interval, selectedWorkType, personName, personRole, finalDate);

                Conflictcs conf = scheduler.CheckConflict(newRequest);
                if (conf != null)
                {
                    MessageBox.Show("Цей час вже зайнятий іншою заявкою!", "Помилка броні", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mainSchedule.AddRequest(newRequest);
                mainSchedule.SaveToJson();

                UpdateRequestPreview();

                DisplayRequests(mainSchedule.GetAllRequest());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка:\n{ex.ToString()}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            comboBox_ResourseList.SelectedIndex = -1;
            comboBox_Priority.SelectedIndex = -1;
            monthCalendar.SelectionStart = DateTime.Today;
            monthCalendar.SelectionEnd = DateTime.Today;
            dateTimePicker_TimeOfWork.Value = DateTime.Today;
            checkBox_ManualChoose.Checked = false;
            TimePickerStartManual.Enabled = false;
        }

        private void dateTimePicker_Schedule_ValueChanged(object sender, EventArgs e)
        {
            DateTime targetDate = dateTimePicker_Schedule.Value.Date;

            var filteredRequests = mainSchedule.GetAllRequest()
                .Where(r => r.DayOfReservation == targetDate)
                .ToList();

            DisplayRequests(filteredRequests);
        }

        private void DisplayRequestsByArrival(List<Request> requests)
        {
            var tableData = requests.Select(r => new
            {
                TimeOfComing = r.CreationTime.ToString("dd.MM.yyyy HH:mm"),
                DayOfReservation = r.DayOfReservation.ToShortDateString(),
                IntervalString = $"{r.Interval.Start:hh\\:mm} - {r.Interval.End:hh\\:mm}",
                PIB = r.NameOfPerson,
                ResourceName = r.Resourse.NAME
            }).ToList();

            dataGridView_ByComing.AutoGenerateColumns = false;
            dataGridView_ByComing.DataSource = null;
            dataGridView_ByComing.DataSource = tableData;
        }

        private void button_LikeSchedule_Click(object sender, EventArgs e)
        {
            dataGridView_Schedule.Visible = true;
            dataGridView_ByComing.Visible = false;
            dateTimePicker_Schedule.Visible = true;

            DateTime targetDate = dateTimePicker_Schedule.Value.Date;

            var filteredRequests = mainSchedule.GetAllRequest()
                .Where(r => r.DayOfReservation == targetDate)
                .OrderBy(r => r.Interval.Start)
                .ToList();

            DisplayRequests(filteredRequests);
        }

        private void button_ByComing_Click(object sender, EventArgs e)
        {
            dataGridView_Schedule.Visible = false;
            dataGridView_ByComing.Visible = true;
            dateTimePicker_Schedule.Visible = false;

            var sortedRequests = mainSchedule.GetAllRequest()
                .OrderBy(r => r.CreationTime)
                .ToList();

            DisplayRequestsByArrival(sortedRequests);
        }

        private void button_MySchedule_Click(object sender, EventArgs e)
        {
            dataGridView_Schedule.Visible = true;
            dataGridView_ByComing.Visible = false;
            dateTimePicker_Schedule.Visible = true;

            DateTime targetDate = dateTimePicker_Schedule.Value.Date;

            string personName = currentUserInfo;
            string personRole = "Студент";

            int bracketIndex = currentUserInfo.LastIndexOf('(');
            if (bracketIndex != -1)
            {
                personName = currentUserInfo.Substring(0, bracketIndex).Trim();
                personRole = currentUserInfo.Substring(bracketIndex).Replace("(", "").Replace(")", "").Trim();
            }

            var filteredRequests = mainSchedule.GetAllRequest()
                .Where(r => r.DayOfReservation == targetDate && r.NameOfPerson == personName && r.Role == personRole)
                .OrderBy(r => r.Interval.Start)
                .ToList();

            DisplayRequests(filteredRequests);
        }
    }
}