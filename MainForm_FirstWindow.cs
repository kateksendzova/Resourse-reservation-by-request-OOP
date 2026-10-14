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
    public partial class MainForm_FirstWindow : Form
    {
        private string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private Scheduler scheduler = new Scheduler();


        public MainForm_FirstWindow(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
        }

        private void MainForm_FirstWindow_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();
            LoadResourcesToListBox();
        }

        private void LoadResourcesToListBox()
        {
            List<Resourse> resources = scheduler.GetResourses();

            listBox_Resources.DataSource = resources;
            listBox_Resources.DisplayMember = "NAME";
            listBox_Resources.ValueMember = "ID";
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

        private void LoadNameAndRole()
        {
            label_PanelRoleName.Text = currentName;
            label_infoName.Text = currentName;
            label_Role.Text = RoleToText(currentRole);

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

        private void button_MakeRequest_Click(object sender, EventArgs e)
        {
            AddRequestForm mainForm = new AddRequestForm(currentUserInfo);

            mainForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRequestForm deleteForm = new DeleteRequestForm(currentUserInfo);
            deleteForm.Show();
            this.Hide();
        }

        private void button_PanelMySchedule_Click(object sender, EventArgs e)
        {
            MySchedule_Form myScheduleForm = new MySchedule_Form(currentUserInfo);
            myScheduleForm.Show();
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
