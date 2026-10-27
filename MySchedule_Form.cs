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
    public partial class MySchedule_Form : BaseForm
    {
        private string currentName;
        private UserRole currentRole;

        private FlowLayoutPanel flowLayout_MyRequests;

        private int? selectedRequestID = null;
        private Request selectedRequestObject = null;

        private Font summaryCaptionFont;
        private Font summaryValueFont;

        public MySchedule_Form(UserContext user) : base(user)
        {
            InitializeComponent();

            if (currentUser != null)
            {
                currentName = currentUser.Name;
                currentRole = currentUser.Role;
            }

            this.FormClosed += (s, e) => Application.Exit();
            this.Resize += MySchedule_Form_Resize;
        }

        public MySchedule_Form(string userInfo) : this(new UserContext(userInfo)) { }

        private void MySchedule_Form_Load(object sender, EventArgs e)
        {
            ShowUserInfo(label_RoleNameMySch, label_infoRole, pictureBox_AvatarStudent, pictureBox_AvatarAssistant, pictureBox_AvatarProfesor);

            summaryCaptionFont = new Font("Century Gothic", 9F, FontStyle.Regular);
            summaryValueFont = new Font("Century Gothic", 10.5F, FontStyle.Bold);

            richTextBox_YourRequest.ReadOnly = true;
            richTextBox_YourRequest.TabStop = false;
            richTextBox_YourRequest.BackColor = Color.White;
            richTextBox_YourRequest.Cursor = Cursors.Default;

            if (dateTimePicker_MySchedule != null)
            {
                dateTimePicker_MySchedule.Format = DateTimePickerFormat.Short;
                dateTimePicker_MySchedule.Value = DateTime.Today;
                dateTimePicker_MySchedule.MinDate = DateTime.Today;
                dateTimePicker_MySchedule.ValueChanged += (s, e) => LoadMyRequestsForDate(dateTimePicker_MySchedule.Value.Date);
            }

            SetupRequestsPanel();
            SetupTopPanelsInfo();

            DateTime initialDate = dateTimePicker_MySchedule != null ? dateTimePicker_MySchedule.Value.Date : DateTime.Today;
            LoadMyRequestsForDate(initialDate);
            UpdateSelectedRequestPreview();

            this.VisibleChanged += (s, ev) =>
            {
                if (this.Visible && dateTimePicker_MySchedule != null)
                    LoadMyRequestsForDate(dateTimePicker_MySchedule.Value.Date);
            };

            this.MinimumSize = new Size(1244, 795);
        }

        private void MySchedule_Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            bool isCompactMode = this.ClientSize.Width < 1900;

            if (isCompactMode)
            {
                panel_Menu.Width = 100;

                if (button_PanelMain != null) button_PanelMain.Visible = false;
                if (button_MakeReq != null) button_MakeReq.Visible = false;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = false;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = false;
                if (button_DelReq != null) button_DelReq.Visible = false;

                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = false;
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = false;
                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = false;
                if (label_RoleNameMySch != null) label_RoleNameMySch.Visible = false;
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

                if (button_PanelMain != null) button_PanelMain.Visible = true;
                if (button_MakeReq != null) button_MakeReq.Visible = true;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = true;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = true;
                if (button_DelReq != null) button_DelReq.Visible = true;
                if (label_RoleNameMySch != null) label_RoleNameMySch.Visible = true;
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
                    panel_AllElements.Width = 1273;
                    panel_AllElements.Height = 963;
                }

                int innerWidth = panel_AllElements.Width - 40;
                int spacing = 20;

                int topPanelWidth = (innerWidth - spacing) / 2;

                if (roundedPanel_NextBooking != null)
                {
                    roundedPanel_NextBooking.Width = topPanelWidth;
                }
                if (roundedPanel_CountOfMineRequest != null)
                {
                    roundedPanel_CountOfMineRequest.Width = topPanelWidth;
                    roundedPanel_CountOfMineRequest.Left = roundedPanel_NextBooking.Right + spacing;
                }

                int leftPanelWidth = (int)((innerWidth - spacing) * 0.52);
                int rightPanelWidth = (innerWidth - spacing) - leftPanelWidth;

                if (roundedPanel_MySchedule != null)
                {
                    roundedPanel_MySchedule.Width = leftPanelWidth;

                    if (flowLayout_MyRequests != null)
                    {
                        flowLayout_MyRequests.Width = roundedPanel_MySchedule.Width - 50;

                        int newItemWidth = flowLayout_MyRequests.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;

                        foreach (Control ctrl in flowLayout_MyRequests.Controls)
                        {
                            ctrl.Width = newItemWidth > 0 ? newItemWidth : 100;
                        }
                    }
                }

                if (roundedPanel_ShowRequest != null)
                {
                    roundedPanel_ShowRequest.Width = rightPanelWidth;
                    roundedPanel_ShowRequest.Left = roundedPanel_MySchedule.Right + spacing;

                    if (richTextBox_YourRequest != null)
                    {
                        richTextBox_YourRequest.Width = roundedPanel_ShowRequest.Width - 100;
                    }
                }
            }
        }

        private void SetupRequestsPanel()
        {
            int topOffset = dateTimePicker_MySchedule != null ? dateTimePicker_MySchedule.Bottom + 15 : 70;

            flowLayout_MyRequests = new FlowLayoutPanel
            {
                Location = new Point(25, topOffset),
                Size = new Size(roundedPanel_MySchedule.Width - 50, roundedPanel_MySchedule.Height - topOffset - 20),
                BackColor = Color.White,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            roundedPanel_MySchedule.Controls.Add(flowLayout_MyRequests);
        }

        private void SetupTopPanelsInfo()
        {
            roundedPanel_NextBooking.Controls.Clear();
            roundedPanel_CountOfMineRequest.Controls.Clear();

            var allUserRequests = AppServices.Scheduler.GetRequestsByPerson(currentName, currentRole);

            var lblTitle1 = new Label
            {
                Text = "Найближче бронювання",
                Font = new Font("Century Gothic", 9F, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(20, 15),
                AutoSize = true
            };

            var lblValue1 = new Label
            {
                Font = new Font("Century Gothic", 9.5F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(20, 42),
                AutoSize = true
            };

            var now = DateTime.Now;
            var nextReq = allUserRequests
                .Where(r => r.DayOfReservation.Date > now.Date || (r.DayOfReservation.Date == now.Date && r.Interval.End > now.TimeOfDay))
                .OrderBy(r => r.DayOfReservation)
                .ThenBy(r => r.Interval.Start)
                .FirstOrDefault();

            if (nextReq != null)
            {
                string dateStr = nextReq.DayOfReservation.ToString("dd.MM.yyyy");
                string timeStr = $"{nextReq.Interval.Start:hh\\:mm} – {nextReq.Interval.End:hh\\:mm}";
                lblValue1.Text = $"{nextReq.Resourse.NAME}\n\n{dateStr}\n{timeStr}";
            }
            else
            {
                lblValue1.Text = "Немає запланованих";
                lblValue1.Font = new Font("Century Gothic", 10.5F, FontStyle.Bold);
            }

            roundedPanel_NextBooking.Controls.Add(lblTitle1);
            roundedPanel_NextBooking.Controls.Add(lblValue1);

            var lblTitle2 = new Label
            {
                Text = "Мої бронювання сьогодні",
                Font = new Font("Century Gothic", 9F, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(20, 15),
                AutoSize = true
            };

            int todayCount = allUserRequests.Count(r => r.DayOfReservation.Date == DateTime.Today);

            var lblValue2 = new Label
            {
                Text = todayCount.ToString(),
                Font = new Font("Century Gothic", 22F, FontStyle.Bold),
                ForeColor = Color.DarkCyan,
                Location = new Point(20, 42),
                AutoSize = true
            };

            roundedPanel_CountOfMineRequest.Controls.Add(lblTitle2);
            roundedPanel_CountOfMineRequest.Controls.Add(lblValue2);
        }

        private void LoadMyRequestsForDate(DateTime date)
        {
            if (flowLayout_MyRequests == null) return;

            flowLayout_MyRequests.SuspendLayout();
            flowLayout_MyRequests.Controls.Clear();

            var myRequests = AppServices.Scheduler.GetRequestsByPerson(currentName, currentRole)
                .Where(r => r.DayOfReservation.Date == date.Date)
                .ToList();

            if (!myRequests.Any())
            {
                var lblEmpty = new Label
                {
                    Text = "На цю дату у вас немає бронювань",
                    Font = new Font("Century Gothic", 9.5F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flowLayout_MyRequests.Controls.Add(lblEmpty);
                selectedRequestID = null;
                selectedRequestObject = null;
                UpdateSelectedRequestPreview();
                flowLayout_MyRequests.ResumeLayout();
                return;
            }

            int btnWidth = flowLayout_MyRequests.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;
            RoundedButton firstButton = null;

            foreach (var req in myRequests)
            {
                string timeStr = $"{req.Interval.Start:hh\\:mm} - {req.Interval.End:hh\\:mm}";
                string btnText = $"{timeStr}    {req.Resourse.NAME}";

                var btnReq = new RoundedButton
                {
                    Text = btnText,
                    Size = new Size(btnWidth, 45),
                    BorderRadius = 12,
                    BorderSize = 1,
                    BorderColor = Color.DarkCyan,
                    Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                    Tag = req.IdRequest,
                    IsSelected = (selectedRequestID == req.IdRequest)
                };

                btnReq.Click += (s, e) =>
                {
                    selectedRequestID = req.IdRequest;
                    selectedRequestObject = req;
                    HighlightSelectedRequest(req.IdRequest);
                    UpdateSelectedRequestPreview();
                };

                flowLayout_MyRequests.Controls.Add(btnReq);
                if (firstButton == null && !selectedRequestID.HasValue)
                {
                    firstButton = btnReq;
                }
            }

            flowLayout_MyRequests.ResumeLayout();

            if (!selectedRequestID.HasValue && firstButton != null)
            {
                firstButton.PerformClick();
            }
            else if (selectedRequestID.HasValue)
            {
                var existing = myRequests.FirstOrDefault(r => r.IdRequest == selectedRequestID.Value);
                if (existing == null)
                {
                    selectedRequestID = null;
                    selectedRequestObject = null;
                    UpdateSelectedRequestPreview();
                }
            }
        }

        private void HighlightSelectedRequest(int requestId)
        {
            foreach (Control ctrl in flowLayout_MyRequests.Controls)
            {
                if (ctrl is RoundedButton rb)
                {
                    rb.IsSelected = (int)rb.Tag == requestId;
                }
            }
        }

        private void UpdateSelectedRequestPreview()
        {
            richTextBox_YourRequest.Clear();

            if (selectedRequestObject == null)
            {
                richTextBox_YourRequest.AddField("Інформація", "Бронювання не вибрано");
                return;
            }

            var r = selectedRequestObject;
            richTextBox_YourRequest.AddField("Обладнання", r.Resourse.NAME);
            richTextBox_YourRequest.AddField("Дата", r.DayOfReservation.ToString("dd.MM.yyyy"));
            richTextBox_YourRequest.AddField("Час", $"{r.Interval.Start:hh\\:mm} – {r.Interval.End:hh\\:mm}");
            richTextBox_YourRequest.AddField("Тип роботи", r.TypeOfWork.ToDisplayName());
            richTextBox_YourRequest.AddField("Дата створення запиту", r.CreationTime.ToString("dd.MM.yyyy HH:mm"));
        }

        private void button_PanelMain_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void button_MakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void button1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
        private void button_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);

        private void pictureBox_Logo_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
        private void pictureBox1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
    }
}