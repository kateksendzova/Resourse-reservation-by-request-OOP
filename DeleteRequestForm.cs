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
        private static readonly TimeSpan WorkDayStart = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan WorkDayEnd = new TimeSpan(19, 0, 0);

        private Scheduler scheduler = new Scheduler();
        private string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        public DeleteRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);
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

        private void button_DeleteReq_Click(object sender, EventArgs e)
        {

        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            richTextBox_request.Clear();
        }

        private void LoadNameAndRole()
        {
            label_RoleNameDel.Text = currentName;

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

        private void UpdateRequestPreview()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                richTextBox_request.Clear();
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];

            string timeRange = selectedRow.Cells["ColumnTime"].Value?.ToString() ?? "";
            string resourceName = selectedRow.Cells["ColumnRes"].Value?.ToString() ?? "";
            string workType = selectedRow.Cells["ColumnType"].Value?.ToString() ?? "";
            string date = dateTimePicker_DeleteReq.Value.ToString("dd.MM.yyyy");

            var sb = new StringBuilder();
            sb.AppendLine($"Користувач: {currentName}\n");
            sb.AppendLine($"Роль: {RoleToText(currentRole)}\n\n");
            sb.AppendLine($"Обладнання: {resourceName}\n\n");
            sb.AppendLine($"Дата: {date}\n");
            sb.AppendLine($"Час: {timeRange}\n\n");
            sb.AppendLine($"Тип роботи: {workType}\n");

            richTextBox_request.Text = sb.ToString();
        }

        private void DeleteRequestForm_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();
            UpdateRequestPreview();
        }

        private void button_MakeReq_Click(object sender, EventArgs e)
        {
            AddRequestForm addReq = new AddRequestForm(currentUserInfo);
            addReq.Show();
            this.Hide();
        }

        private void button_PanelMain_Click(object sender, EventArgs e)
        {
            MainForm_FirstWindow main = new MainForm_FirstWindow(currentUserInfo);
            main.Show();
            this.Hide();
        }
    }
}
