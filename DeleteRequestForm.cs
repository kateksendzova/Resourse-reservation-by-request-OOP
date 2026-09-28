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
    public partial class DeleteRequestForm : Form
    {
        private bool isInitialized = false;
        private Schedule mainSchedule = new Schedule();
        private string currentUserInfo;
        public DeleteRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;

            mainSchedule.LoadFromJson();

            comboBox_TypeOfWorkDelete.Items.Add("Дипломна робота");
            comboBox_TypeOfWorkDelete.Items.Add("Науковий експеримент");
            comboBox_TypeOfWorkDelete.Items.Add("Лабораторна робота");
            comboBox_TypeOfWorkDelete.Items.Add("Самостійна робота");

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

            comboBox_Resourse.DataSource = resourcesList;
            comboBox_Resourse.DisplayMember = "NAME";
            comboBox_Resourse.ValueMember = "ID";

            comboBox_Resourse.SelectedIndex = -1;
            comboBox_TypeOfWorkDelete.SelectedIndex = -1;

            monthCalendar_DeleteReq.MinDate = DateTime.Today;

            isInitialized = true;

            ColTimeDel.DataPropertyName = "TimeOfComing";
            ColResourse.DataPropertyName = "ResourceName";
            ColPibDell.DataPropertyName = "PIB";
            ColRoleDel.DataPropertyName = "Role";
            ColTypeWorkDel.DataPropertyName = "TypeOfWork";

            ColTimeOfComing.DataPropertyName = "TimeOfComing";
            ColDayOfRes.DataPropertyName = "DayOfReservation";
            ColIntervalDel.DataPropertyName = "IntervalString";
            ColPib.DataPropertyName = "PIB";
            ColResourseDel.DataPropertyName = "ResourceName";

            this.FormClosed += new FormClosedEventHandler(this.DeleteRequestForm_FormClosed);
            mainSchedule.LoadFromJson();
        }
        private void DeleteRequestForm_Load(object sender, EventArgs e)
        {

        }



        private void DeleteRequestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_DeleteReq_Click(object sender, EventArgs e)
        {

        }

        public void UpdateRequestPreview()
        {
            if (!isInitialized)
                return;

            richTextBox_CheckReqDel.Clear();

            if (comboBox_Resourse.SelectedItem is Resourse selectedResourse)
            {
                richTextBox_CheckReqDel.AppendText($"Обладнання: {selectedResourse.NAME}\n");
            }

            DateTime selectedDate = monthCalendar_DeleteReq.SelectionStart;
            richTextBox_CheckReqDel.AppendText($"Дата: {selectedDate.ToShortDateString()}\n");

            richTextBox_CheckReqDel.AppendText($"Час початку: {dateTimePicker_StartDelete.Value.ToString("HH:mm")}\n");
            richTextBox_CheckReqDel.AppendText($"Час кінця: {dateTimePicker_EndDelete.Value.ToString("HH:mm")}\n");

            if (comboBox_TypeOfWorkDelete.SelectedIndex >= 0)
            {
                richTextBox_CheckReqDel.AppendText($"Тип роботи: {comboBox_TypeOfWorkDelete.SelectedItem}\n");
            }
        }

        private void button_ClearDel_Click(object sender, EventArgs e)
        {
            comboBox_Resourse.SelectedIndex = -1;
            comboBox_TypeOfWorkDelete.SelectedIndex = -1;
            monthCalendar_DeleteReq.MinDate = DateTime.Today;
            dateTimePicker_StartDelete.MinDate = DateTime.Today;
            dateTimePicker_EndDelete.MinDate = DateTime.Today;
            richTextBox_CheckReqDel.Clear();
        }

        private void button_ByComingDel_Click(object sender, EventArgs e)
        {
            dataGridView_ScheduleForDel.Visible = false;
            dataGridView1.Visible = true;
            dateTimePicker_ScheduleDel.Visible = false;
        }

        private void button_ScheduleDel_Click(object sender, EventArgs e)
        {
            dataGridView_ScheduleForDel.Visible = true;
            dataGridView1.Visible = false;
            dateTimePicker_ScheduleDel.Visible = true;
        }

        private void button_MyScheduleDel_Click(object sender, EventArgs e)
        {
            dataGridView_ScheduleForDel.Visible = true;
            dataGridView1.Visible = false;
            dateTimePicker_ScheduleDel.Visible = true;
        }

        private void comboBox_Resourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRequestPreview();
        }

        private void comboBox_TypeOfWorkDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRequestPreview();
        }

        private void monthCalendar_DeleteReq_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateRequestPreview();
        }

        private void dateTimePicker_EndDelete_ValueChanged(object sender, EventArgs e)
        {
            UpdateRequestPreview();
        }
    }
}
