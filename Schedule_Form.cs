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
    public partial class Schedule_Form : Form
    {
        private static readonly TimeSpan WorkDayStart = new TimeSpan(8, 0, 0);
        private static readonly TimeSpan WorkDayEnd = new TimeSpan(19, 0, 0);

        private Scheduler scheduler = new Scheduler();
        private string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        public Schedule_Form(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);


            this.FormClosed += (s, e) => Application.Exit();
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

        private void Schedule_Form_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();
        }

        private void button_PanelMainForm_Click(object sender, EventArgs e)
        {
            MainForm_FirstWindow mainForm_First = new MainForm_FirstWindow(currentUserInfo);
            mainForm_First.Show();
            this.Hide();
        }

        private void button_PanelAddReq_Click(object sender, EventArgs e)
        {
            AddRequestForm addRequestForm = new AddRequestForm(currentUserInfo);
            addRequestForm.Show();
            this.Hide();
        }

        private void button_PanelMySchedule_Click(object sender, EventArgs e)
        {
            MySchedule_Form schedule_Form = new MySchedule_Form(currentUserInfo);
            schedule_Form.Show();
            this.Hide();
        }

        private void button_PanelDelReq_Click(object sender, EventArgs e)
        {
            DeleteRequestForm deleteRequestForm = new DeleteRequestForm(currentUserInfo);
            deleteRequestForm.Show();
            this.Hide();
        }
    }
}
