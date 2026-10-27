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
    public partial class DeleteRequestForm : BaseForm
    {
        private FlowLayoutPanel flowLayout_Requests;
        private int? selectedRequestID = null;
        private Request selectedRequestObject = null;

        private Font summaryCaptionFont;
        private Font summaryValueFont;

        public DeleteRequestForm(UserContext user) : base(user)
        {
            InitializeComponent();

            this.FormClosed += (s, e) => Application.Exit();
            this.Resize += DeleteRequestForm_Resize;
        }

        public DeleteRequestForm(string userInfo) : this(new UserContext(userInfo)) { }

        private void DeleteRequestForm_Resize(object sender, EventArgs e)
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
                if (button1 != null) button1.Visible = false;

                if (pictureBox_AvatarAssistant != null) pictureBox_AvatarAssistant.Visible = false;
                if (pictureBox_AvatarProfesor != null) pictureBox_AvatarProfesor.Visible = false;
                if (pictureBox_AvatarStudent != null) pictureBox_AvatarStudent.Visible = false;
                if (label_RoleNameDel != null) label_RoleNameDel.Visible = false;
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
                if (button1 != null) button1.Visible = true;
                if (label_RoleNameDel != null) label_RoleNameDel.Visible = true;
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
                    panel_AllElements.Width = 1243;
                    panel_AllElements.Height = 954;
                }

                int innerWidth = panel_AllElements.Width - 40;
                int spacing = 20;

                int leftPanelWidth = (int)((innerWidth - spacing) * 0.52);
                int rightPanelWidth = (innerWidth - spacing) - leftPanelWidth;

                if (roundedPanel_RequestsForDel != null)
                {
                    roundedPanel_RequestsForDel.Width = leftPanelWidth;
                    roundedPanel_RequestsForDel.Top = 161;

                    roundedPanel_RequestsForDel.Height = panel_AllElements.Height - roundedPanel_RequestsForDel.Top - 20;

                    if (dateTimePicker_DeleteReq != null)
                    {
                        dateTimePicker_DeleteReq.Width = roundedPanel_RequestsForDel.Width - 120;
                    }

                    if (flowLayout_Requests != null)
                    {
                        flowLayout_Requests.Width = roundedPanel_RequestsForDel.Width - 50;
                        flowLayout_Requests.Height = roundedPanel_RequestsForDel.Height - dateTimePicker_DeleteReq.Bottom - 30;

                        int newBtnWidth = flowLayout_Requests.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;

                        foreach (Control ctrl in flowLayout_Requests.Controls)
                        {
                            if (ctrl is RoundedButton btn)
                            {
                                btn.Width = newBtnWidth > 0 ? newBtnWidth : 100;
                            }
                        }
                    }
                }

                if (roundedPanel_ShowRequest != null)
                {
                    roundedPanel_ShowRequest.Width = rightPanelWidth;
                    roundedPanel_ShowRequest.Left = roundedPanel_RequestsForDel.Right + spacing;

                    roundedPanel_ShowRequest.Top = 161;
                    roundedPanel_ShowRequest.Height = panel_AllElements.Height - roundedPanel_ShowRequest.Top - 20;

                    if (richTextBox_YourRequest != null)
                    {
                        richTextBox_YourRequest.Width = roundedPanel_ShowRequest.Width - 100;
                    }

                    if (button_DeleteReq != null)
                    {
                        button_DeleteReq.Width = 350;
                        button_DeleteReq.Left = (roundedPanel_ShowRequest.Width - button_DeleteReq.Width) / 2;

                        button_DeleteReq.Top = roundedPanel_ShowRequest.Height - button_DeleteReq.Height - 30;
                    }
                }
            }
        }

        private void DeleteRequestForm_Load(object sender, EventArgs e)
        {
            ShowUserInfo(label_RoleNameDel, label_infoRole, pictureBox_AvatarStudent, pictureBox_AvatarAssistant, pictureBox_AvatarProfesor);

            summaryCaptionFont = new Font("Century Gothic", 9F, FontStyle.Regular);
            summaryValueFont = new Font("Century Gothic", 10.5F, FontStyle.Bold);

            richTextBox_YourRequest.ReadOnly = true;
            richTextBox_YourRequest.TabStop = false;
            richTextBox_YourRequest.BackColor = Color.White;
            richTextBox_YourRequest.Cursor = Cursors.Default;

            SetupRequestsPanel();

            dateTimePicker_DeleteReq.Format = DateTimePickerFormat.Short;
            dateTimePicker_DeleteReq.Value = DateTime.Today;
            dateTimePicker_DeleteReq.ValueChanged += (s, e) => LoadRequestsForDate(dateTimePicker_DeleteReq.Value.Date);

            button_DeleteReq.Click += button_DeleteReq_Click;

            LoadRequestsForDate(dateTimePicker_DeleteReq.Value.Date);
            UpdateRequestPreview();

            this.MinimumSize = new Size(1244, 795);
        }

        private void SetupRequestsPanel()
        {
            flowLayout_Requests = new FlowLayoutPanel
            {
                Location = new Point(25, dateTimePicker_DeleteReq.Bottom + 15),
                Size = new Size(roundedPanel_RequestsForDel.Width - 50, roundedPanel_RequestsForDel.Height - dateTimePicker_DeleteReq.Bottom - 30),
                BackColor = Color.White,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            roundedPanel_RequestsForDel.Controls.Add(flowLayout_Requests);
        }

        private void LoadRequestsForDate(DateTime date)
        {
            flowLayout_Requests.SuspendLayout();
            flowLayout_Requests.Controls.Clear();

            var userRequests = AppServices.Scheduler.GetRequestsByPerson(currentUser.Name, currentUser.Role)
                .Where(r => r.DayOfReservation.Date == date.Date)
                .ToList();

            if (!userRequests.Any())
            {
                var lblEmpty = new Label
                {
                    Text = "На цю дату у вас немає запитів",
                    Font = new Font("Century Gothic", 9.5F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flowLayout_Requests.Controls.Add(lblEmpty);
                selectedRequestID = null;
                selectedRequestObject = null;
                UpdateRequestPreview();
                flowLayout_Requests.ResumeLayout();
                return;
            }

            int btnWidth = flowLayout_Requests.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;
            RoundedButton firstButton = null;

            foreach (var req in userRequests)
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
                    UpdateRequestPreview();
                };

                flowLayout_Requests.Controls.Add(btnReq);
                if (firstButton == null && !selectedRequestID.HasValue)
                {
                    firstButton = btnReq;
                }
            }

            flowLayout_Requests.ResumeLayout();

            if (!selectedRequestID.HasValue && firstButton != null)
            {
                firstButton.PerformClick();
            }
            else if (selectedRequestID.HasValue)
            {
                var existing = userRequests.FirstOrDefault(r => r.IdRequest == selectedRequestID.Value);
                if (existing == null)
                {
                    selectedRequestID = null;
                    selectedRequestObject = null;
                    UpdateRequestPreview();
                }
            }
        }

        private void HighlightSelectedRequest(int requestId)
        {
            foreach (Control ctrl in flowLayout_Requests.Controls)
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

        private void UpdateRequestPreview()
        {
            richTextBox_YourRequest.Clear();

            if (selectedRequestObject == null)
            {
                AppendField("Інформація", "Запит не вибрано");
                return;
            }

            var r = selectedRequestObject;
            AppendField("Обладнання", r.Resourse.NAME);
            AppendField("Дата", r.DayOfReservation.ToString("dd.MM.yyyy"));
            AppendField("Час", $"{r.Interval.Start:hh\\:mm} – {r.Interval.End:hh\\:mm}");
            AppendField("Тип роботи", r.TypeOfWork.ToDisplayName());
        }

        private void button_DeleteReq_Click(object sender, EventArgs e)
        {
            if (!selectedRequestID.HasValue || selectedRequestObject == null)
            {
                MessageBox.Show("Будь ласка, оберіть запит для видалення зі списку ліворуч!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Ви дійсно хочете видалити запит на обладнання '{selectedRequestObject.Resourse.NAME}'?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    AppServices.Scheduler.DeleteRequest(selectedRequestID.Value);

                    MessageBox.Show("Запит успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    selectedRequestID = null;
                    selectedRequestObject = null;

                    LoadRequestsForDate(dateTimePicker_DeleteReq.Value.Date);
                    UpdateRequestPreview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні запиту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_PanelMain_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void button_MakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void button_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void button_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);

        private void pictureBox_Logo_Click(object sender, EventArgs e) => NavigateTo(AppPage.Main);
        private void pictureBox_PanelMakeReq_Click(object sender, EventArgs e) => NavigateTo(AppPage.AddRequest);
        private void pictureBox_PanelMySchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.MySchedule);
        private void pictureBox_PanelSchedule_Click(object sender, EventArgs e) => NavigateTo(AppPage.Schedule);
    }
}