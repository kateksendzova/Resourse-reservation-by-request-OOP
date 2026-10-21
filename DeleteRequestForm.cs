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
        private readonly Scheduler scheduler = new Scheduler();
        private readonly string currentUserInfo;
        private string currentName;
        private UserRole currentRole;

        private FlowLayoutPanel flowLayout_Requests;
        private int? selectedRequestID = null;
        private Request selectedRequestObject = null;

        private Font summaryCaptionFont;
        private Font summaryValueFont;

        public DeleteRequestForm(string userInfo)
        {
            InitializeComponent();
            currentUserInfo = userInfo;
            ParseUserInfo(userInfo);

            this.FormClosed += (s, e) => Application.Exit();
        }

        private void DeleteRequestForm_Load(object sender, EventArgs e)
        {
            LoadNameAndRole();

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
            label_RoleNameDel.Text = currentName;
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

        private static string GetWorkTypeName(TypeOfWork type) => type switch
        {
            TypeOfWork.LaboratoryWork => "Лабораторна",
            TypeOfWork.DiplomaThesis => "Дипломна",
            TypeOfWork.ScientificExperiment => "Експеримент",
            _ => "Самостійна робота"
        };

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

            var userRequests = scheduler.GetRequestsByPerson(currentName, currentRole)
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
            AppendField("Тип роботи", GetWorkTypeName(r.TypeOfWork));
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
                    scheduler.DeleteRequest(selectedRequestID.Value);

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
    }
}