using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class AddRequestForm : BaseForm
    {
        private const int WorkStartHour = 8;
        private const int WorkEndHour = 19;

        private readonly ToolTip toolTip = new ToolTip();

        private FlowLayoutPanel flowLayout_SelectResources;
        private FlowLayoutPanel flowLayout_TypeOfWork;

        private int? selectedResID = null;
        private string selectedResName = "";
        private TypeOfWork selectedTypeOfWork = TypeOfWork.IndependentWork;

        public AddRequestForm(UserContext user) : base(user)
        {
            InitializeComponent();
            this.FormClosed += (s, e) => Application.Exit();
            this.Resize += AddRequestForm_Resize; // Додаємо обробник зміни розміру
        }

        public AddRequestForm(UserContext user, int resourceID) : this(user)
        {
            selectedResID = resourceID;
        }

        public AddRequestForm(string userInfo) : this(new UserContext(userInfo)) { }
        public AddRequestForm(string userInfo, int resourceID) : this(new UserContext(userInfo), resourceID) { }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            ShowUserInfo(label_RoleName, label_infoRole,
                pictureBox_AvatarStudent, pictureBox_AvatarAssistant, pictureBox_AvatarProfesor);

            richTextBox_YourRequest.ReadOnly = true;
            richTextBox_YourRequest.TabStop = false;
            richTextBox_YourRequest.BackColor = Color.White;
            richTextBox_YourRequest.Cursor = Cursors.Default;

            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.MinDate = DateTime.Today;
            SetDefaultTime();

            SetupResourceSelectionPanel();
            SetupTypeOfWorkPanel();
            LoadSelectableResources("");

            if (selectedResID.HasValue)
            {
                var res = AppServices.Scheduler.GetResourses().FirstOrDefault(r => r.ID == selectedResID.Value);
                if (res != null) selectedResName = res.NAME;
            }

            monthCalendar.DateChanged += (s, ev) => UpdateSummaryText();
            TimePicker_StartOfWork.ValueChanged += (s, ev) => UpdateSummaryText();
            dateTimePicker_Interval.ValueChanged += (s, ev) => UpdateSummaryText();
            button_ClearAll.Click += button_ClearAll_Click;

            UpdateSummaryText();

            this.MinimumSize = new Size(1050, 795);
        }

        // Логіка адаптивності (Resize) для AddRequestForm (панель меню та адаптація елементів)
        private void AddRequestForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            bool isCompactMode = this.ClientSize.Width < 1900;

            if (isCompactMode)
            {
                panel_Menu.Width = 100;

                if (button_PanelMane != null) button_PanelMane.Visible = false;
                if (button_AddRequest != null) button_AddRequest.Visible = false;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = false;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = false;
                if (button1 != null) button1.Visible = false;

                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = false;
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = false;
                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = false;
                if (label_RoleName != null) label_RoleName.Visible = false;
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

                if (button_PanelMane != null) button_PanelMane.Visible = true;
                if (button_AddRequest != null) button_AddRequest.Visible = true;
                if (button_PanelMySchedule != null) button_PanelMySchedule.Visible = true;
                if (button_PanelSchedule != null) button_PanelSchedule.Visible = true;
                if (button1 != null) button1.Visible = true;
                if (label_RoleName != null) label_RoleName.Visible = true;
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
                if (pictureBox1 != null) pictureBox1.Left = 44;
            }
        }

        private void SetDefaultTime()
        {
            TimePicker_StartOfWork.Value = DateTime.Today.AddHours(8);
            dateTimePicker_Interval.Value = DateTime.Today.AddHours(1);
        }

        private FlowLayoutPanel CreateFlowPanel(Control parent, int top, bool scroll)
        {
            return new FlowLayoutPanel
            {
                Location = new Point(25, top),
                Size = new Size(parent.Width - 50, parent.Height - top - 24),
                BackColor = Color.White,
                AutoScroll = scroll,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
        }

        private void SetupResourceSelectionPanel()
        {
            textBox_SearchRes.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_SearchRes.PlaceholderText = "Пошук обладнання";
            textBox_SearchRes.TextChanged += (s, e) => LoadSelectableResources(textBox_SearchRes.Text.Trim());

            flowLayout_SelectResources = CreateFlowPanel(roundedPanel_Resources, textBox_SearchRes.Bottom + 12, true);
            roundedPanel_Resources.Controls.Add(flowLayout_SelectResources);
        }

        private void LoadSelectableResources(string searchQuery)
        {
            flowLayout_SelectResources.SuspendLayout();
            flowLayout_SelectResources.Controls.Clear();

            IEnumerable<Resourse> filtered = AppServices.Scheduler.GetResourses();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                filtered = filtered.Where(r => r.NAME.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            int btnWidth = flowLayout_SelectResources.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;
            RoundedButton selectedButton = null;

            foreach (var res in filtered)
            {
                var btnRes = new RoundedButton
                {
                    Text = res.NAME,
                    Size = new Size(btnWidth, 40),
                    BorderRadius = 12,
                    BorderSize = 1,
                    BorderColor = Color.DarkCyan,
                    Font = new Font("Century Gothic", 9.5F, FontStyle.Bold),
                    Tag = res.ID,
                    IsSelected = (selectedResID == res.ID)
                };
                toolTip.SetToolTip(btnRes, res.NAME);

                btnRes.Click += (s, e) =>
                {
                    selectedResID = res.ID;
                    selectedResName = res.NAME;
                    HighlightSelected(flowLayout_SelectResources, res.ID);
                    UpdateSummaryText();
                };

                flowLayout_SelectResources.Controls.Add(btnRes);
                if (btnRes.IsSelected) selectedButton = btnRes;
            }

            flowLayout_SelectResources.ResumeLayout();
            if (selectedButton != null) flowLayout_SelectResources.ScrollControlIntoView(selectedButton);
        }

        private void HighlightSelected(FlowLayoutPanel flow, object selectedTag)
        {
            foreach (Control ctrl in flow.Controls)
            {
                if (ctrl is RoundedButton rb)
                    rb.IsSelected = Equals(rb.Tag, selectedTag);
            }
        }

        private void SetupTypeOfWorkPanel()
        {
            flowLayout_TypeOfWork = CreateFlowPanel(roundedPanel_TypeOfWork, label1.Bottom + 12, false);
            roundedPanel_TypeOfWork.Controls.Add(flowLayout_TypeOfWork);

            var workTypes = new (string Text, TypeOfWork Type)[]
            {
                ("Самостійна робота", TypeOfWork.IndependentWork),
                ("Лабораторна", TypeOfWork.LaboratoryWork),
                ("Дипломна", TypeOfWork.DiplomaThesis),
                ("Експеримент", TypeOfWork.ScientificExperiment)
            };

            int btnWidth = flowLayout_TypeOfWork.ClientSize.Width - 6;

            foreach (var item in workTypes)
            {
                var btnWork = new RoundedButton
                {
                    Text = item.Text,
                    Size = new Size(btnWidth, 32),
                    BorderRadius = 10,
                    BorderSize = 1,
                    BorderColor = Color.DarkCyan,
                    Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                    Tag = item.Type,
                    IsSelected = (selectedTypeOfWork == item.Type)
                };

                btnWork.Click += (s, e) =>
                {
                    selectedTypeOfWork = item.Type;
                    HighlightSelected(flowLayout_TypeOfWork, item.Type);
                    UpdateSummaryText();
                };

                flowLayout_TypeOfWork.Controls.Add(btnWork);
            }
        }

        private void UpdateSummaryText()
        {
            TimeSpan start = TimePicker_StartOfWork.Value.TimeOfDay;
            TimeSpan interval = dateTimePicker_Interval.Value.TimeOfDay;
            TimeSpan end = start + interval;

            richTextBox_YourRequest.Clear();

            bool hasRes = !string.IsNullOrEmpty(selectedResName);

            richTextBox_YourRequest.AddField("Обладнання", hasRes ? selectedResName : "Не обрано", !hasRes);
            richTextBox_YourRequest.AddField("Дата", monthCalendar.SelectionStart.ToString("dd.MM.yyyy"));
            richTextBox_YourRequest.AddField("Час", $"{start:hh\\:mm} – {end:hh\\:mm}");
            richTextBox_YourRequest.AddField("Тривалість", $"{(int)interval.TotalHours} год {interval.Minutes} хв");
            richTextBox_YourRequest.AddField("Тип роботи", selectedTypeOfWork.ToDisplayName());
        }

        private void button_AddRequest_Click(object sender, EventArgs e)
        {
            if (!selectedResID.HasValue)
            {
                MessageBox.Show("Будь ласка, оберіть обладнання!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime reservDate = monthCalendar.SelectionStart.Date;
            TimeSpan startTime = TimePicker_StartOfWork.Value.TimeOfDay;
            TimeSpan interval = dateTimePicker_Interval.Value.TimeOfDay;

            if (interval <= TimeSpan.Zero)
            {
                MessageBox.Show("Тривалість має бути більшою за 0.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startTime < TimeSpan.FromHours(WorkStartHour) || startTime + interval > TimeSpan.FromHours(WorkEndHour))
            {
                MessageBox.Show($"Лабораторія працює з {WorkStartHour:00}:00 до {WorkEndHour:00}:00. Змініть час початку або тривалість.",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (reservDate == DateTime.Today && startTime < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("Цей час сьогодні вже минув.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Person person = AppServices.Scheduler.GetOrCreatePerson(currentUser.Name, currentUser.Role);

                if (AppServices.Scheduler.CheckForPersonConflict(person, reservDate, startTime, interval) != null)
                {
                    var information = MessageBox.Show(
                        "У вас уже є активна бронь у цей час! Бажаєте все одно додати новий запит?",
                        "Конфлікт бронювання",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (information == DialogResult.No) return;
                }

                Resourse resource = AppServices.Scheduler.GetResourses().FirstOrDefault(r => r.ID == selectedResID.Value);

                if (resource == null)
                {
                    MessageBox.Show("Помилка: обране обладнання не знайдено в базі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = AppServices.Scheduler.TryAddRequest(resource, person, reservDate, startTime, interval, selectedTypeOfWork);

                if (result.IsAvailable)
                {
                    MessageBox.Show(result.Message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    selectedResID = null;
                    selectedResName = "";
                    selectedTypeOfWork = TypeOfWork.IndependentWork;

                    textBox_SearchRes.Clear();
                    LoadSelectableResources("");
                    HighlightSelected(flowLayout_TypeOfWork, selectedTypeOfWork);

                    monthCalendar.SetDate(DateTime.Today);
                    SetDefaultTime();
                    UpdateSummaryText();
                }
                else
                {
                    MessageBox.Show(result.Message, "Конфлікт розкладу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при збереженні запиту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            selectedResID = null;
            selectedResName = "";
            selectedTypeOfWork = TypeOfWork.IndependentWork;

            textBox_SearchRes.Clear();
            LoadSelectableResources("");
            HighlightSelected(flowLayout_TypeOfWork, selectedTypeOfWork);

            monthCalendar.SetDate(DateTime.Today);
            SetDefaultTime();
            UpdateSummaryText();
        }


        private void button_PanelMane_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void button_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void button_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
        private void button1_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);

        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
        private void pictureBox_PanelDelete_Click(object sender, EventArgs e) => NavigateTo(AppPage.DeleteRequest);
    }
}