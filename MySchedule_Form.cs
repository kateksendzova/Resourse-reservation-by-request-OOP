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
    public partial class MySchedule_Form : Form
    {
        private Scheduler scheduler = new Scheduler();
        private string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private FlowLayoutPanel flowLayout_MyRequests;

        private int? selectedRequestID = null;
        private Request selectedRequestObject = null;

        private Font summaryCaptionFont;
        private Font summaryValueFont;

        public MySchedule_Form(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
            this.Resize += MySchedule_Form_Resize;
        }

        private void MySchedule_Form_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();

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
                if (pictureBox1 != null) pictureBox1.Left = (100 - pictureBox1.Width) / 2;
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

                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = (currentRole == UserRole.Student);
                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = (currentRole == UserRole.Assistant);
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = (currentRole == UserRole.Professor);

                if (pictureBox_Logo != null) pictureBox_Logo.Left = 43;
                if (pictureBox_PanelMakeReq != null) pictureBox_PanelMakeReq.Left = 44;
                if (pictureBox_PanelMySchedule != null) pictureBox_PanelMySchedule.Left = 47;
                if (pictureBox_PanelSchedule != null) pictureBox_PanelSchedule.Left = 47;
                if (pictureBox1 != null) pictureBox1.Left = 44;
            }

            if (panel_AllElements != null)
            {
                if (isCompactMode)
                {
                    // У компактному режимі панель йде одразу за вузьким меню (100 + 15 = 115) 
                    // і динамічно звужується за розміром вікна
                    panel_AllElements.Left = 115;
                    panel_AllElements.Width = this.ClientSize.Width - panel_AllElements.Left - 15;
                    panel_AllElements.Height = this.ClientSize.Height - 40;
                }
                else
                {
                    // На великому екрані стає чітко на твою координату 560
                    panel_AllElements.Left = 560;
                    panel_AllElements.Width = 1273; // Твій бажаний розмір для великого екрана
                    panel_AllElements.Height = 963;
                }

                // Пропорційне зменшення/масштабування внутрішніх елементів під поточну ширину panel_AllElements
                int innerWidth = panel_AllElements.Width - 40;
                int spacing = 20;

                // --- 1. ВЕРХНІ ПЛАШКИ ---
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

                // --- 2. НИЖНІ ПАНЕЛІ ---
                int leftPanelWidth = (int)((innerWidth - spacing) * 0.52);
                int rightPanelWidth = (innerWidth - spacing) - leftPanelWidth;

                if (roundedPanel_MySchedule != null)
                {
                    roundedPanel_MySchedule.Width = leftPanelWidth;

                    if (flowLayout_MyRequests != null)
                    {
                        flowLayout_MyRequests.Width = roundedPanel_MySchedule.Width - 50;
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
            label_RoleNameMySch.Text = currentName;

            label_infoRole.Text = currentRole switch
            {
                UserRole.Professor => "Викладач",
                UserRole.Assistant => "Аспірант",
                _ => "Студент"
            };

            pictureBox_AvatarStudent.Visible = (currentRole == UserRole.Student);
            pictureBox_AvatarAssistant.Visible = (currentRole == UserRole.Assistant);
            pictureBox_AvatarProfesor.Visible = (currentRole == UserRole.Professor);
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

            var allUserRequests = scheduler.GetRequestsByPerson(currentName, currentRole);

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

            var myRequests = scheduler.GetRequestsByPerson(currentName, currentRole)
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
                string btnText = $"{req.Resourse.NAME} ({timeStr})";

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

        private void AppendField(string caption, string value)
        {
            var box = richTextBox_YourRequest;

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionFont = summaryCaptionFont;
            box.SelectionColor = Color.DimGray;
            box.AppendText(caption + "\n");

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionFont = summaryValueFont;
            box.SelectionColor = Color.Black;
            box.AppendText(value + "\n\n");
        }

        private static string GetWorkTypeName(TypeOfWork type) => type switch
        {
            TypeOfWork.LaboratoryWork => "Лабораторна",
            TypeOfWork.DiplomaThesis => "Дипломна",
            TypeOfWork.ScientificExperiment => "Експеримент",
            _ => "Самостійна робота"
        };

        private void UpdateSelectedRequestPreview()
        {
            richTextBox_YourRequest.Clear();

            if (selectedRequestObject == null)
            {
                AppendField("Інформація", "Бронювання не вибрано");
                return;
            }

            var r = selectedRequestObject;
            AppendField("Обладнання", r.Resourse.NAME);
            AppendField("Дата", r.DayOfReservation.ToString("dd.MM.yyyy"));
            AppendField("Час", $"{r.Interval.Start:hh\\:mm} – {r.Interval.End:hh\\:mm}");
            AppendField("Тип роботи", GetWorkTypeName(r.TypeOfWork));
            AppendField("Дата створення запиту", r.CreationTime.ToString("dd.MM.yyyy HH:mm"));
        }

        private void button_PanelMain_Click(object sender, EventArgs e)
        {
            new MainForm_FirstWindow(currentUserInfo).Show();
            this.Hide();
        }

        private void button_MakeReq_Click(object sender, EventArgs e)
        {
            new AddRequestForm(currentUserInfo).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DeleteRequestForm(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelSchedule_Click(object sender, EventArgs e)
        {
            new Schedule_Form(currentUserInfo).Show();
            this.Hide();
        }

        private void pictureBox_Logo_Click(object sender, EventArgs e)
        {
            button_PanelMain_Click(sender, e);
        }

        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e)
        {
            button_MakeReq_Click(sender, e);
        }

        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e)
        {
            button_PanelSchedule_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}