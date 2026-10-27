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
    public partial class MainForm_FirstWindow : BaseForm
    {
        private const string PlaceholderText = "Пошук обладнання на сьогодні";

        public MainForm_FirstWindow(UserContext user) : base(user)
        {
            InitializeComponent();

            this.FormClosed += (s, e) => Application.Exit();
            this.Resize += MainForm_FirstWindow_Resize;
        }

        public MainForm_FirstWindow(string userInfo) : this(new UserContext(userInfo)) { }

        private void MainForm_FirstWindow_Load(object sender, EventArgs e)
        {
            ShowUserInfo(label_PanelRoleName, label_infoRole, pictureBox_AvatarStudent, pictureBox_AvatarAssistant, pictureBox_AvatarProfesor);

            roundedButton_All.Click += roundedButton_All_Click;
            roundedButton_Available.Click += roundedButton_Available_Click;
            roundedButton_All.IsSelected = true;
            roundedButton_Available.IsSelected = false;

            SetupSearchBox();
            LoadResources("All", "");

            this.MinimumSize = new Size(1050, 795);
        }

        private void MainForm_FirstWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            bool isCompactMode = this.ClientSize.Width < 1900;

            if (isCompactMode)
            {
                panel_Menu.Width = 100;

                if (button_PanelMane != null) button_PanelMane.Visible = false;
                if (button_MakeRequest != null) button_MakeRequest.Visible = false;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = false;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = false;
                if (button_DelReq != null) button_DelReq.Visible = false;

                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = false;
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = false;
                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = false;
                if (label_PanelRoleName != null) label_PanelRoleName.Visible = false;
                if (label_infoRole != null) label_infoRole.Visible = false;

                if (pictureBox_Logo != null) pictureBox_Logo.Left = (100 - pictureBox_Logo.Width) / 2;
                if (pictureBox_PanelMakeReq != null) pictureBox_PanelMakeReq.Left = (100 - pictureBox_PanelMakeReq.Width) / 2;
                if (pictureBox_PanelMySchedule != null) pictureBox_PanelMySchedule.Left = (100 - pictureBox_PanelMySchedule.Width) / 2;
                if (pictureBox_PanelSchedule != null) pictureBox_PanelSchedule.Left = (100 - pictureBox_PanelSchedule.Width) / 2;
                if (pictureBox_PanelDelete != null) pictureBox_PanelDelete.Left = (100 - pictureBox_PanelDelete.Width) / 2;
            }
            else
            {
                panel_Menu.Width = 382;

                if (button_PanelMane != null) button_PanelMane.Visible = true;
                if (button_MakeRequest != null) button_MakeRequest.Visible = true;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = true;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = true;
                if (button_DelReq != null) button_DelReq.Visible = true;
                if (label_PanelRoleName != null) label_PanelRoleName.Visible = true;
                if (label_infoRole != null) label_infoRole.Visible = true;

                if (currentUser != null)
                {
                    pictureBox_AvatarStudent.Visible = (currentUser.Role == UserRole.Student);
                    pictureBox_AvatarAssistant.Visible = (currentUser.Role == UserRole.Assistant);
                    pictureBox_AvatarProfesor.Visible = (currentUser.Role == UserRole.Professor);
                }

                if (pictureBox_Logo != null) pictureBox_Logo.Left = 43;
                if (pictureBox_PanelMakeReq != null) pictureBox_PanelMakeReq.Left = 44;
                if (pictureBox_PanelMySchedule != null) pictureBox_PanelMySchedule.Left = 47;
                if (pictureBox_PanelSchedule != null) pictureBox_PanelSchedule.Left = 47;
                if (pictureBox_PanelDelete != null) pictureBox_PanelDelete.Left = 44;
            }

            if (panel_AllElements != null)
            {
                if (isCompactMode)
                {
                    panel_AllElements.Left = 115;
                    panel_AllElements.Width = this.ClientSize.Width - panel_AllElements.Left - 15;
                    panel_AllElements.Height = this.ClientSize.Height - 40;
                }
                else
                {
                    panel_AllElements.Left = 560;
                    panel_AllElements.Width = 1244;
                    panel_AllElements.Height = 944;
                }

                if (textBox_Search != null)
                {
                    textBox_Search.Left = 9;
                    textBox_Search.Top = 139;
                    textBox_Search.Width = 467;
                }

                if (roundedButton_All != null)
                {
                    roundedButton_All.Left = 515;
                    roundedButton_All.Top = 135;
                }

                if (roundedButton_Available != null)
                {
                    roundedButton_Available.Left = 626;
                    roundedButton_Available.Top = 135;
                }

                if (flowLayoutPanel_Resources != null)
                {
                    flowLayoutPanel_Resources.Left = 0;
                    flowLayoutPanel_Resources.Top = 191;
                    flowLayoutPanel_Resources.Width = panel_AllElements.Width;
                    flowLayoutPanel_Resources.Height = Math.Max(400, panel_AllElements.Height - flowLayoutPanel_Resources.Top - 20);
                }
            }
        }

        private void SetupSearchBox()
        {
            if (string.IsNullOrWhiteSpace(textBox_Search.Text) || textBox_Search.Text == PlaceholderText)
            {
                textBox_Search.Text = PlaceholderText;
                textBox_Search.ForeColor = SystemColors.ControlDark;
            }

            textBox_Search.Enter += (s, e) =>
            {
                if (textBox_Search.Text == PlaceholderText)
                {
                    textBox_Search.Text = "";
                    textBox_Search.ForeColor = Color.Black;
                }
            };

            textBox_Search.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox_Search.Text))
                {
                    textBox_Search.Text = PlaceholderText;
                    textBox_Search.ForeColor = SystemColors.ControlDark;
                    string currentFilter = roundedButton_Available.IsSelected ? "Available" : "All";
                    LoadResources(currentFilter, "");
                }
            };

            textBox_Search.TextChanged += (s, e) =>
            {
                if (textBox_Search.Text != PlaceholderText)
                {
                    string searchText = textBox_Search.Text.Trim();
                    string currentFilter = roundedButton_Available.IsSelected ? "Available" : "All";
                    LoadResources(currentFilter, searchText);
                }
            };
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

        private RoundedPanel CreateEquipmentCard(int resourceID, string title, string statusText, bool isAvailable)
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
                Text = statusText,
                Size = new Size(130, 32),
                Location = new Point(20, 80),
                BorderRadius = 15,
                BorderSize = 1,
                BorderColor = isAvailable ? Color.DarkCyan : Color.Gray,
                BackColor = isAvailable ? Color.AliceBlue : Color.WhiteSmoke,
                ForeColor = isAvailable ? Color.DarkCyan : Color.Gray,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Enabled = isAvailable
            };

            btnBook.Click += (s, e) =>
            {
                var addRequestForm = new AddRequestForm(currentUser, resourceID);
                NavigateTo(addRequestForm);
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnBook);

            return card;
        }

        private void LoadResources(string filterType, string searchQuery = "")
        {
            flowLayoutPanel_Resources.Controls.Clear();
            List<Resourse> allResources = AppServices.Scheduler.GetResourses();

            IEnumerable<Resourse> filteredList = allResources;

            if (filterType == "Available")
            {
                filteredList = filteredList.Where(r => AppServices.Scheduler.IsResourceAvailableForAtLeastOneHour(r.ID, DateTime.Today));
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                filteredList = filteredList.Where(r => r.NAME.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            foreach (var res in filteredList)
            {
                bool isAvail = AppServices.Scheduler.IsResourceAvailableForAtLeastOneHour(res.ID, DateTime.Today);
                string statusText = isAvail ? "Вільно" : "Зайнято";

                var card = CreateEquipmentCard(res.ID, res.NAME, statusText, isAvail);
                flowLayoutPanel_Resources.Controls.Add(card);
            }
        }
        private void button_MakeRequest_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void button1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
        private void button_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void button_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);

        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
        private void pictureBox1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
    }
}