namespace КурсоваРобота_Ксендзова_ПЗ27
{
    partial class AddRequestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_infoSystemName = new Label();
            label_infoChooseResource = new Label();
            comboBox_ResourseList = new ComboBox();
            label_infoDay = new Label();
            TimePicker_StartOfWork = new DateTimePicker();
            label_infoTimeStartManual = new Label();
            monthCalendar = new MonthCalendar();
            button_AddRequest = new Button();
            dataGridView_Schedule = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colResource = new DataGridViewTextBoxColumn();
            ColNameOfPerson = new DataGridViewTextBoxColumn();
            ColRole = new DataGridViewTextBoxColumn();
            ColTypeOfWork = new DataGridViewTextBoxColumn();
            label_infoPriority = new Label();
            comboBox_Priority = new ComboBox();
            richTextBox_request = new RichTextBox();
            label_infoReqRichText = new Label();
            label_infoInterval = new Label();
            button_ClearAll = new Button();
            dateTimePicker_Schedule = new DateTimePicker();
            button_ByComing = new Button();
            button_LikeSchedule = new Button();
            dataGridView_ByComing = new DataGridView();
            Col_TimeOfComing = new DataGridViewTextBoxColumn();
            Col_DayOdReserv = new DataGridViewTextBoxColumn();
            Col_Interval = new DataGridViewTextBoxColumn();
            Col_PIB = new DataGridViewTextBoxColumn();
            Col_Resourse = new DataGridViewTextBoxColumn();
            button_MySchedule = new Button();
            dateTimePicker_Interval = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Schedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ByComing).BeginInit();
            SuspendLayout();
            // 
            // label_infoSystemName
            // 
            label_infoSystemName.AutoSize = true;
            label_infoSystemName.Location = new Point(340, 9);
            label_infoSystemName.Name = "label_infoSystemName";
            label_infoSystemName.Size = new Size(212, 20);
            label_infoSystemName.TabIndex = 0;
            label_infoSystemName.Text = "Додати запит на обладнання";
            // 
            // label_infoChooseResource
            // 
            label_infoChooseResource.AutoSize = true;
            label_infoChooseResource.Location = new Point(62, 56);
            label_infoChooseResource.Name = "label_infoChooseResource";
            label_infoChooseResource.Size = new Size(153, 20);
            label_infoChooseResource.TabIndex = 1;
            label_infoChooseResource.Text = "Оберіть обладнання";
            // 
            // comboBox_ResourseList
            // 
            comboBox_ResourseList.FormattingEnabled = true;
            comboBox_ResourseList.Location = new Point(12, 79);
            comboBox_ResourseList.Name = "comboBox_ResourseList";
            comboBox_ResourseList.Size = new Size(238, 28);
            comboBox_ResourseList.TabIndex = 2;
            // 
            // label_infoDay
            // 
            label_infoDay.AutoSize = true;
            label_infoDay.Location = new Point(321, 58);
            label_infoDay.Name = "label_infoDay";
            label_infoDay.Size = new Size(101, 20);
            label_infoDay.TabIndex = 3;
            label_infoDay.Text = "Оберіть день";
            // 
            // TimePicker_StartOfWork
            // 
            TimePicker_StartOfWork.CustomFormat = "HH:mm";
            TimePicker_StartOfWork.Format = DateTimePickerFormat.Custom;
            TimePicker_StartOfWork.Location = new Point(489, 83);
            TimePicker_StartOfWork.Name = "TimePicker_StartOfWork";
            TimePicker_StartOfWork.ShowUpDown = true;
            TimePicker_StartOfWork.Size = new Size(91, 27);
            TimePicker_StartOfWork.TabIndex = 5;
            // 
            // label_infoTimeStartManual
            // 
            label_infoTimeStartManual.AutoSize = true;
            label_infoTimeStartManual.Location = new Point(485, 58);
            label_infoTimeStartManual.Name = "label_infoTimeStartManual";
            label_infoTimeStartManual.Size = new Size(149, 20);
            label_infoTimeStartManual.TabIndex = 6;
            label_infoTimeStartManual.Text = "Оберіть час початку";
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(274, 79);
            monthCalendar.MinDate = new DateTime(2026, 9, 27, 0, 0, 0, 0);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 7;
            // 
            // button_AddRequest
            // 
            button_AddRequest.BackColor = Color.FromArgb(192, 255, 192);
            button_AddRequest.Location = new Point(502, 523);
            button_AddRequest.Name = "button_AddRequest";
            button_AddRequest.Size = new Size(94, 50);
            button_AddRequest.TabIndex = 11;
            button_AddRequest.Text = "Додати запит";
            button_AddRequest.UseVisualStyleBackColor = false;
            // 
            // dataGridView_Schedule
            // 
            dataGridView_Schedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Schedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_Schedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Schedule.Columns.AddRange(new DataGridViewColumn[] { colTime, colResource, ColNameOfPerson, ColRole, ColTypeOfWork });
            dataGridView_Schedule.Location = new Point(718, 87);
            dataGridView_Schedule.Name = "dataGridView_Schedule";
            dataGridView_Schedule.RowHeadersWidth = 51;
            dataGridView_Schedule.Size = new Size(754, 515);
            dataGridView_Schedule.TabIndex = 12;
            // 
            // colTime
            // 
            colTime.HeaderText = "Час";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            // 
            // colResource
            // 
            colResource.HeaderText = "Обладнання";
            colResource.MinimumWidth = 6;
            colResource.Name = "colResource";
            // 
            // ColNameOfPerson
            // 
            ColNameOfPerson.HeaderText = "ПІБ";
            ColNameOfPerson.MinimumWidth = 6;
            ColNameOfPerson.Name = "ColNameOfPerson";
            // 
            // ColRole
            // 
            ColRole.HeaderText = "Роль";
            ColRole.MinimumWidth = 6;
            ColRole.Name = "ColRole";
            // 
            // ColTypeOfWork
            // 
            ColTypeOfWork.HeaderText = "Вид діяльності";
            ColTypeOfWork.MinimumWidth = 6;
            ColTypeOfWork.Name = "ColTypeOfWork";
            // 
            // label_infoPriority
            // 
            label_infoPriority.AutoSize = true;
            label_infoPriority.Location = new Point(93, 155);
            label_infoPriority.Name = "label_infoPriority";
            label_infoPriority.Size = new Size(90, 20);
            label_infoPriority.TabIndex = 13;
            label_infoPriority.Text = "Тип роботи";
            // 
            // comboBox_Priority
            // 
            comboBox_Priority.FormattingEnabled = true;
            comboBox_Priority.Location = new Point(12, 178);
            comboBox_Priority.Name = "comboBox_Priority";
            comboBox_Priority.Size = new Size(238, 28);
            comboBox_Priority.TabIndex = 14;
            // 
            // richTextBox_request
            // 
            richTextBox_request.Location = new Point(12, 332);
            richTextBox_request.Name = "richTextBox_request";
            richTextBox_request.Size = new Size(687, 185);
            richTextBox_request.TabIndex = 15;
            richTextBox_request.Text = "";
            // 
            // label_infoReqRichText
            // 
            label_infoReqRichText.AutoSize = true;
            label_infoReqRichText.Location = new Point(12, 309);
            label_infoReqRichText.Name = "label_infoReqRichText";
            label_infoReqRichText.Size = new Size(384, 20);
            label_infoReqRichText.TabIndex = 16;
            label_infoReqRichText.Text = "Ваш запит на обладнання. Перевірте його та додайте";
            // 
            // label_infoInterval
            // 
            label_infoInterval.AutoSize = true;
            label_infoInterval.Location = new Point(489, 136);
            label_infoInterval.Name = "label_infoInterval";
            label_infoInterval.Size = new Size(142, 20);
            label_infoInterval.TabIndex = 21;
            label_infoInterval.Text = "Введіть час роботи";
            // 
            // button_ClearAll
            // 
            button_ClearAll.BackColor = Color.FromArgb(255, 192, 192);
            button_ClearAll.Location = new Point(605, 523);
            button_ClearAll.Name = "button_ClearAll";
            button_ClearAll.Size = new Size(94, 50);
            button_ClearAll.TabIndex = 25;
            button_ClearAll.Text = "Очистити";
            button_ClearAll.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker_Schedule
            // 
            dateTimePicker_Schedule.Format = DateTimePickerFormat.Short;
            dateTimePicker_Schedule.Location = new Point(718, 59);
            dateTimePicker_Schedule.Name = "dateTimePicker_Schedule";
            dateTimePicker_Schedule.Size = new Size(754, 27);
            dateTimePicker_Schedule.TabIndex = 9;
            // 
            // button_ByComing
            // 
            button_ByComing.BackColor = Color.BurlyWood;
            button_ByComing.Location = new Point(1094, 1);
            button_ByComing.Name = "button_ByComing";
            button_ByComing.Size = new Size(379, 29);
            button_ByComing.TabIndex = 26;
            button_ByComing.Text = "За надходженням";
            button_ByComing.UseVisualStyleBackColor = false;
            // 
            // button_LikeSchedule
            // 
            button_LikeSchedule.BackColor = Color.BurlyWood;
            button_LikeSchedule.Location = new Point(718, 1);
            button_LikeSchedule.Name = "button_LikeSchedule";
            button_LikeSchedule.Size = new Size(379, 29);
            button_LikeSchedule.TabIndex = 27;
            button_LikeSchedule.Text = "Розклад";
            button_LikeSchedule.UseVisualStyleBackColor = false;
            // 
            // dataGridView_ByComing
            // 
            dataGridView_ByComing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_ByComing.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_ByComing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ByComing.Columns.AddRange(new DataGridViewColumn[] { Col_TimeOfComing, Col_DayOdReserv, Col_Interval, Col_PIB, Col_Resourse });
            dataGridView_ByComing.Location = new Point(718, 59);
            dataGridView_ByComing.Name = "dataGridView_ByComing";
            dataGridView_ByComing.RowHeadersWidth = 51;
            dataGridView_ByComing.Size = new Size(754, 679);
            dataGridView_ByComing.TabIndex = 28;
            // 
            // Col_TimeOfComing
            // 
            Col_TimeOfComing.HeaderText = "Час надходження";
            Col_TimeOfComing.MinimumWidth = 6;
            Col_TimeOfComing.Name = "Col_TimeOfComing";
            // 
            // Col_DayOdReserv
            // 
            Col_DayOdReserv.HeaderText = "День резервації";
            Col_DayOdReserv.MinimumWidth = 6;
            Col_DayOdReserv.Name = "Col_DayOdReserv";
            // 
            // Col_Interval
            // 
            Col_Interval.HeaderText = "Інтервал";
            Col_Interval.MinimumWidth = 6;
            Col_Interval.Name = "Col_Interval";
            // 
            // Col_PIB
            // 
            Col_PIB.HeaderText = "ПІБ";
            Col_PIB.MinimumWidth = 6;
            Col_PIB.Name = "Col_PIB";
            // 
            // Col_Resourse
            // 
            Col_Resourse.HeaderText = "Обладнання";
            Col_Resourse.MinimumWidth = 6;
            Col_Resourse.Name = "Col_Resourse";
            // 
            // button_MySchedule
            // 
            button_MySchedule.BackColor = Color.BlanchedAlmond;
            button_MySchedule.Location = new Point(718, 29);
            button_MySchedule.Name = "button_MySchedule";
            button_MySchedule.Size = new Size(754, 29);
            button_MySchedule.TabIndex = 29;
            button_MySchedule.Text = "Мій розклад";
            button_MySchedule.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker_Interval
            // 
            dateTimePicker_Interval.CustomFormat = "HH:mm";
            dateTimePicker_Interval.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Interval.Location = new Point(489, 159);
            dateTimePicker_Interval.Name = "dateTimePicker_Interval";
            dateTimePicker_Interval.ShowUpDown = true;
            dateTimePicker_Interval.Size = new Size(91, 27);
            dateTimePicker_Interval.TabIndex = 30;
            dateTimePicker_Interval.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // AddRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 579);
            Controls.Add(dateTimePicker_Interval);
            Controls.Add(button_MySchedule);
            Controls.Add(dataGridView_ByComing);
            Controls.Add(button_LikeSchedule);
            Controls.Add(button_ByComing);
            Controls.Add(button_ClearAll);
            Controls.Add(label_infoInterval);
            Controls.Add(label_infoReqRichText);
            Controls.Add(richTextBox_request);
            Controls.Add(comboBox_Priority);
            Controls.Add(label_infoPriority);
            Controls.Add(dataGridView_Schedule);
            Controls.Add(button_AddRequest);
            Controls.Add(dateTimePicker_Schedule);
            Controls.Add(monthCalendar);
            Controls.Add(label_infoTimeStartManual);
            Controls.Add(TimePicker_StartOfWork);
            Controls.Add(label_infoDay);
            Controls.Add(comboBox_ResourseList);
            Controls.Add(label_infoChooseResource);
            Controls.Add(label_infoSystemName);
            Name = "AddRequestForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Schedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ByComing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_infoSystemName;
        private Label label_infoChooseResource;
        private ComboBox comboBox_ResourseList;
        private Label label_infoDay;
        private DateTimePicker TimePicker_StartOfWork;
        private Label label_infoTimeStartManual;
        private MonthCalendar monthCalendar;
        private Button button_AddRequest;
        private DataGridView dataGridView_Schedule;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colResource;
        private Label label_infoPriority;
        private ComboBox comboBox_Priority;
        private RichTextBox richTextBox_request;
        private Label label_infoReqRichText;
        private Label label_infoInterval;
        private DataGridViewTextBoxColumn ColNameOfPerson;
        private DataGridViewTextBoxColumn ColRole;
        private DataGridViewTextBoxColumn ColTypeOfWork;
        private Button button_ClearAll;
        private DateTimePicker dateTimePicker_Schedule;
        private Button button_ByComing;
        private Button button_LikeSchedule;
        private DataGridView dataGridView_ByComing;
        private DataGridViewTextBoxColumn Col_TimeOfComing;
        private DataGridViewTextBoxColumn Col_DayOdReserv;
        private DataGridViewTextBoxColumn Col_Interval;
        private DataGridViewTextBoxColumn Col_PIB;
        private DataGridViewTextBoxColumn Col_Resourse;
        private Button button_MySchedule;
        private DateTimePicker dateTimePicker_Interval;
    }
}
