using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class AddRequestForm : Form
    {
        private const int WorkStartHour = 8;
        private const int WorkEndHour = 19;

        private readonly string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private readonly Scheduler scheduler = new Scheduler();
        private readonly ToolTip toolTip = new ToolTip();

        private FlowLayoutPanel flowLayout_SelectResources;
        private FlowLayoutPanel flowLayout_TypeOfWork;

        private int? selectedResID = null;
        private string selectedResName = "";
        private TypeOfWork selectedTypeOfWork = TypeOfWork.IndependentWork;

        private Font summaryCaptionFont;
        private Font summaryValueFont;

        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
        }

        public AddRequestForm(string userInfo, int resourceID) : this(userInfo)
        {
            selectedResID = resourceID;
        }


        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();

            summaryCaptionFont = new Font("Century Gothic", 9F, FontStyle.Regular);
            summaryValueFont = new Font("Century Gothic", 10.5F, FontStyle.Bold);

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
                var res = scheduler.GetResourses().FirstOrDefault(r => r.ID == selectedResID.Value);
                if (res != null) selectedResName = res.NAME;
            }

            monthCalendar.DateChanged += (s, ev) => UpdateSummaryText();
            TimePicker_StartOfWork.ValueChanged += (s, ev) => UpdateSummaryText();
            dateTimePicker_Interval.ValueChanged += (s, ev) => UpdateSummaryText();
            button_ClearAll.Click += button_ClearAll_Click;

            UpdateSummaryText();
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

            IEnumerable<Resourse> filtered = scheduler.GetResourses();
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

        private static string GetWorkTypeName(TypeOfWork type) => type switch
        {
            TypeOfWork.LaboratoryWork => "Лабораторна",
            TypeOfWork.DiplomaThesis => "Дипломна",
            TypeOfWork.ScientificExperiment => "Експеримент",
            _ => "Самостійна робота"
        };

        private void AppendField(string caption, string value, bool isPlaceholder = false)
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
            box.SelectionColor = isPlaceholder ? Color.Gray : Color.Black;
            box.AppendText(value + "\n\n");
        }

        private void UpdateSummaryText()
        {
            TimeSpan start = TimePicker_StartOfWork.Value.TimeOfDay;
            TimeSpan interval = dateTimePicker_Interval.Value.TimeOfDay;
            TimeSpan end = start + interval;

            richTextBox_YourRequest.Clear();

            bool hasRes = !string.IsNullOrEmpty(selectedResName);
            AppendField("Обладнання", hasRes ? selectedResName : "Не обрано", !hasRes);
            AppendField("Дата", monthCalendar.SelectionStart.ToString("dd.MM.yyyy"));
            AppendField("Час", $"{start:hh\\:mm} – {end:hh\\:mm}");
            AppendField("Тривалість", $"{(int)interval.TotalHours} год {interval.Minutes} хв");
            AppendField("Тип роботи", GetWorkTypeName(selectedTypeOfWork));
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
            label_RoleName.Text = currentName;
            label_infoRole.Text = currentRole switch
            {
                UserRole.Professor => "Викладач",
                UserRole.Assistant => "Аспірант",
                _ => "Студент"
            };


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
                Person person = scheduler.GetOrCreatePerson(currentName, currentRole);

                if(scheduler.CheckForPersonConflict(person, reservDate, startTime, interval) != null)
                {
                    var information = MessageBox.Show(
                        "У вас уже є активна бронь у цей час! Бажаєте все одно додати новий запит?",
                        "Конфлікт бронювання",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (information == DialogResult.No)
                    {
                        return;
                    }
                }

                Resourse resource = scheduler.GetResourses().FirstOrDefault(r => r.ID == selectedResID.Value);
                if (resource == null)
                {
                    MessageBox.Show("Помилка: обране обладнання не знайдено в базі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = scheduler.TryAddRequest(resource, person, reservDate, startTime, interval, selectedTypeOfWork);

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

        private void button_PanelMane_Click(object sender, EventArgs e)
        {
            new MainForm_FirstWindow(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelMySchedule_Click(object sender, EventArgs e)
        {
            new MySchedule_Form(currentUserInfo).Show();
            this.Hide();
        }

        private void button_PanelSchedule_Click(object sender, EventArgs e)
        {
            new Schedule_Form(currentUserInfo).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DeleteRequestForm(currentUserInfo).Show();
            this.Hide();
        }
    }
}