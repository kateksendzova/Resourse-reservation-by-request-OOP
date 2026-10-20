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

            roundedButton_All.Click += roundedButton_All_Click;
            roundedButton_Available.Click += roundedButton_Available_Click;
            roundedButton_All.IsSelected = true;
            roundedButton_Available.IsSelected = false;

            LoadResources("All");
        }



        private void roundedButton_All_Click(object sender, EventArgs e)
        {
            roundedButton_All.IsSelected = true;
            roundedButton_Available.IsSelected = false;
            LoadResources("All");
        }

        private void roundedButton_Available_Click(object sender, EventArgs e)
        {
            roundedButton_Available.IsSelected = true;
            roundedButton_All.IsSelected = false;
            LoadResources("Available");
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

        private RoundedPanel CreateEquipmentCard(string title, string statusText, bool isAvailable)
        {
            RoundedPanel card = new RoundedPanel
            {
                Size = new Size(380, 130),
                BackColor = Color.White,
                BorderColor = Color.LightGray,
                CornerRadius = 12,
                Margin = new Padding(10)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Century Gothic", 10.5F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = statusText,
                Font = new Font("Century Gothic", 9F, FontStyle.Regular),
                ForeColor = isAvailable ? Color.ForestGreen : Color.DarkOrange,
                Location = new Point(20, 45),
                AutoSize = true
            };

            RoundedButton btnBook = new RoundedButton
            {
                Text = "Забронювати",
                Size = new Size(130, 32),
                Location = new Point(20, 80),
                BorderRadius = 15,
                BorderSize = 1,
                BorderColor = Color.DarkCyan,
                BackColor = Color.AliceBlue,
                ForeColor = Color.DarkCyan,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold)
            };

            btnBook.Click += (s, e) =>
            {
                MessageBox.Show($"Ви вибрали бронювання: {title}");
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnBook);

            return card;
        }

        private void LoadResources(string filterType)
        {
            flowLayoutPanel_Resources.Controls.Clear();
            List<Resourse> allResources = scheduler.GetResourses();

            IEnumerable<Resourse> filteredList = allResources;

            if (filterType == "Available")
            {
                filteredList = allResources.Where(r => scheduler.IsResourceAvailableForAtLeastOneHour(r.ID, DateTime.Today));
            }

            foreach (var res in filteredList)
            {
                bool isAvail = scheduler.IsResourceAvailableForAtLeastOneHour(res.ID, DateTime.Today);
                string statusText = isAvail ? "Вільно зараз" : "Зайнято";

                var card = CreateEquipmentCard(res.NAME, statusText, isAvail);
                flowLayoutPanel_Resources.Controls.Add(card);
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
