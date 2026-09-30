namespace КурсоваРобота_Ксендзова_ПЗ27
{
    partial class DeleteRequestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_infoDeleteReq = new Label();
            comboBox_Resourse = new ComboBox();
            comboBox_TypeOfWorkDelete = new ComboBox();
            monthCalendar_DeleteReq = new MonthCalendar();
            dateTimePicker_StartDelete = new DateTimePicker();
            dateTimePicker_EndDelete = new DateTimePicker();
            label_infoDeleteRes = new Label();
            label_infoTypeWorkDelete = new Label();
            label_DayOfResDel = new Label();
            label_infoDash = new Label();
            label_infoStartDel = new Label();
            label_infoEndDel = new Label();
            richTextBox_CheckReqDel = new RichTextBox();
            label_infoCheckReqDel = new Label();
            button_DeleteReq = new Button();
            button_ClearDel = new Button();
            button_ScheduleDel = new Button();
            button_ByComingDel = new Button();
            dataGridView1 = new DataGridView();
            ColTimeOfComing = new DataGridViewTextBoxColumn();
            ColDayOfRes = new DataGridViewTextBoxColumn();
            ColIntervalDel = new DataGridViewTextBoxColumn();
            ColPib = new DataGridViewTextBoxColumn();
            ColResourseDel = new DataGridViewTextBoxColumn();
            dateTimePicker_ScheduleDel = new DateTimePicker();
            dataGridView_ScheduleForDel = new DataGridView();
            ColTimeDel = new DataGridViewTextBoxColumn();
            ColResourse = new DataGridViewTextBoxColumn();
            ColPibDell = new DataGridViewTextBoxColumn();
            ColRoleDel = new DataGridViewTextBoxColumn();
            ColTypeWorkDel = new DataGridViewTextBoxColumn();
            button_MyScheduleDel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleForDel).BeginInit();
            SuspendLayout();
            // 
            // label_infoDeleteReq
            // 
            label_infoDeleteReq.AutoSize = true;
            label_infoDeleteReq.Location = new Point(257, 9);
            label_infoDeleteReq.Name = "label_infoDeleteReq";
            label_infoDeleteReq.Size = new Size(322, 20);
            label_infoDeleteReq.TabIndex = 0;
            label_infoDeleteReq.Text = "Видалити запит на бронювання обладнання";
            // 
            // comboBox_Resourse
            // 
            comboBox_Resourse.FormattingEnabled = true;
            comboBox_Resourse.Location = new Point(34, 73);
            comboBox_Resourse.Name = "comboBox_Resourse";
            comboBox_Resourse.Size = new Size(236, 28);
            comboBox_Resourse.TabIndex = 1;
            // 
            // comboBox_TypeOfWorkDelete
            // 
            comboBox_TypeOfWorkDelete.FormattingEnabled = true;
            comboBox_TypeOfWorkDelete.Location = new Point(34, 182);
            comboBox_TypeOfWorkDelete.Name = "comboBox_TypeOfWorkDelete";
            comboBox_TypeOfWorkDelete.Size = new Size(236, 28);
            comboBox_TypeOfWorkDelete.TabIndex = 2;
            // 
            // monthCalendar_DeleteReq
            // 
            monthCalendar_DeleteReq.Location = new Point(286, 73);
            monthCalendar_DeleteReq.MinDate = new DateTime(2026, 9, 27, 0, 0, 0, 0);
            monthCalendar_DeleteReq.Name = "monthCalendar_DeleteReq";
            monthCalendar_DeleteReq.TabIndex = 3;
            // 
            // dateTimePicker_StartDelete
            // 
            dateTimePicker_StartDelete.CustomFormat = "HH:mm";
            dateTimePicker_StartDelete.Format = DateTimePickerFormat.Custom;
            dateTimePicker_StartDelete.Location = new Point(503, 74);
            dateTimePicker_StartDelete.Name = "dateTimePicker_StartDelete";
            dateTimePicker_StartDelete.Size = new Size(60, 27);
            dateTimePicker_StartDelete.TabIndex = 4;
            // 
            // dateTimePicker_EndDelete
            // 
            dateTimePicker_EndDelete.CustomFormat = "HH:mm";
            dateTimePicker_EndDelete.Format = DateTimePickerFormat.Custom;
            dateTimePicker_EndDelete.Location = new Point(589, 74);
            dateTimePicker_EndDelete.Name = "dateTimePicker_EndDelete";
            dateTimePicker_EndDelete.Size = new Size(60, 27);
            dateTimePicker_EndDelete.TabIndex = 5;
            // 
            // label_infoDeleteRes
            // 
            label_infoDeleteRes.AutoSize = true;
            label_infoDeleteRes.Location = new Point(105, 53);
            label_infoDeleteRes.Name = "label_infoDeleteRes";
            label_infoDeleteRes.Size = new Size(96, 20);
            label_infoDeleteRes.TabIndex = 6;
            label_infoDeleteRes.Text = "Обладнання";
            // 
            // label_infoTypeWorkDelete
            // 
            label_infoTypeWorkDelete.AutoSize = true;
            label_infoTypeWorkDelete.Location = new Point(105, 159);
            label_infoTypeWorkDelete.Name = "label_infoTypeWorkDelete";
            label_infoTypeWorkDelete.Size = new Size(90, 20);
            label_infoTypeWorkDelete.TabIndex = 7;
            label_infoTypeWorkDelete.Text = "Тип роботи";
            // 
            // label_DayOfResDel
            // 
            label_DayOfResDel.AutoSize = true;
            label_DayOfResDel.Location = new Point(324, 53);
            label_DayOfResDel.Name = "label_DayOfResDel";
            label_DayOfResDel.Size = new Size(122, 20);
            label_DayOfResDel.TabIndex = 8;
            label_DayOfResDel.Text = "День резервації";
            // 
            // label_infoDash
            // 
            label_infoDash.AutoSize = true;
            label_infoDash.Location = new Point(566, 77);
            label_infoDash.Name = "label_infoDash";
            label_infoDash.Size = new Size(21, 20);
            label_infoDash.TabIndex = 9;
            label_infoDash.Text = "--";
            // 
            // label_infoStartDel
            // 
            label_infoStartDel.AutoSize = true;
            label_infoStartDel.Location = new Point(498, 51);
            label_infoStartDel.Name = "label_infoStartDel";
            label_infoStartDel.Size = new Size(67, 20);
            label_infoStartDel.TabIndex = 10;
            label_infoStartDel.Text = "Початок";
            // 
            // label_infoEndDel
            // 
            label_infoEndDel.AllowDrop = true;
            label_infoEndDel.AutoSize = true;
            label_infoEndDel.Location = new Point(590, 51);
            label_infoEndDel.Name = "label_infoEndDel";
            label_infoEndDel.Size = new Size(56, 20);
            label_infoEndDel.TabIndex = 11;
            label_infoEndDel.Text = "Кінець";
            // 
            // richTextBox_CheckReqDel
            // 
            richTextBox_CheckReqDel.Location = new Point(34, 341);
            richTextBox_CheckReqDel.Name = "richTextBox_CheckReqDel";
            richTextBox_CheckReqDel.Size = new Size(615, 197);
            richTextBox_CheckReqDel.TabIndex = 12;
            richTextBox_CheckReqDel.Text = "";
            // 
            // label_infoCheckReqDel
            // 
            label_infoCheckReqDel.AutoSize = true;
            label_infoCheckReqDel.Location = new Point(34, 317);
            label_infoCheckReqDel.Name = "label_infoCheckReqDel";
            label_infoCheckReqDel.Size = new Size(347, 20);
            label_infoCheckReqDel.TabIndex = 13;
            label_infoCheckReqDel.Text = "Ваш запит для видалення. Перевірте та видаліть";
            // 
            // button_DeleteReq
            // 
            button_DeleteReq.BackColor = Color.FromArgb(192, 255, 192);
            button_DeleteReq.ForeColor = SystemColors.ActiveCaptionText;
            button_DeleteReq.Location = new Point(376, 544);
            button_DeleteReq.Name = "button_DeleteReq";
            button_DeleteReq.Size = new Size(134, 40);
            button_DeleteReq.TabIndex = 14;
            button_DeleteReq.Text = "Видалити запит";
            button_DeleteReq.UseVisualStyleBackColor = false;
            // 
            // button_ClearDel
            // 
            button_ClearDel.BackColor = Color.FromArgb(255, 192, 192);
            button_ClearDel.ForeColor = Color.Black;
            button_ClearDel.Location = new Point(516, 544);
            button_ClearDel.Name = "button_ClearDel";
            button_ClearDel.Size = new Size(134, 40);
            button_ClearDel.TabIndex = 15;
            button_ClearDel.Text = "Очистити";
            button_ClearDel.UseVisualStyleBackColor = false;
            // 
            // button_ScheduleDel
            // 
            button_ScheduleDel.BackColor = Color.Tan;
            button_ScheduleDel.ForeColor = SystemColors.ActiveCaptionText;
            button_ScheduleDel.Location = new Point(1052, 3);
            button_ScheduleDel.Name = "button_ScheduleDel";
            button_ScheduleDel.Size = new Size(378, 29);
            button_ScheduleDel.TabIndex = 16;
            button_ScheduleDel.Text = "Розклад";
            button_ScheduleDel.UseVisualStyleBackColor = false;
            // 
            // button_ByComingDel
            // 
            button_ByComingDel.BackColor = Color.Tan;
            button_ByComingDel.ForeColor = SystemColors.ActiveCaptionText;
            button_ByComingDel.Location = new Point(674, 3);
            button_ByComingDel.Name = "button_ByComingDel";
            button_ByComingDel.Size = new Size(381, 29);
            button_ByComingDel.TabIndex = 17;
            button_ByComingDel.Text = "За надходженням";
            button_ByComingDel.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColTimeOfComing, ColDayOfRes, ColIntervalDel, ColPib, ColResourseDel });
            dataGridView1.Location = new Point(674, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(756, 550);
            dataGridView1.TabIndex = 18;
            // 
            // ColTimeOfComing
            // 
            ColTimeOfComing.HeaderText = "Час надходження";
            ColTimeOfComing.MinimumWidth = 6;
            ColTimeOfComing.Name = "ColTimeOfComing";
            // 
            // ColDayOfRes
            // 
            ColDayOfRes.HeaderText = "День резервації";
            ColDayOfRes.MinimumWidth = 6;
            ColDayOfRes.Name = "ColDayOfRes";
            // 
            // ColIntervalDel
            // 
            ColIntervalDel.HeaderText = "Інтервал";
            ColIntervalDel.MinimumWidth = 6;
            ColIntervalDel.Name = "ColIntervalDel";
            // 
            // ColPib
            // 
            ColPib.HeaderText = "ПІБ";
            ColPib.MinimumWidth = 6;
            ColPib.Name = "ColPib";
            // 
            // ColResourseDel
            // 
            ColResourseDel.HeaderText = "Обладнання";
            ColResourseDel.MinimumWidth = 6;
            ColResourseDel.Name = "ColResourseDel";
            // 
            // dateTimePicker_ScheduleDel
            // 
            dateTimePicker_ScheduleDel.Location = new Point(674, 61);
            dateTimePicker_ScheduleDel.MinDate = new DateTime(2026, 9, 27, 0, 0, 0, 0);
            dateTimePicker_ScheduleDel.Name = "dateTimePicker_ScheduleDel";
            dateTimePicker_ScheduleDel.Size = new Size(756, 27);
            dateTimePicker_ScheduleDel.TabIndex = 19;
            // 
            // dataGridView_ScheduleForDel
            // 
            dataGridView_ScheduleForDel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_ScheduleForDel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView_ScheduleForDel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ScheduleForDel.Columns.AddRange(new DataGridViewColumn[] { ColTimeDel, ColResourse, ColPibDell, ColRoleDel, ColTypeWorkDel });
            dataGridView_ScheduleForDel.Location = new Point(674, 90);
            dataGridView_ScheduleForDel.Name = "dataGridView_ScheduleForDel";
            dataGridView_ScheduleForDel.RowHeadersWidth = 51;
            dataGridView_ScheduleForDel.Size = new Size(756, 523);
            dataGridView_ScheduleForDel.TabIndex = 20;
            // 
            // ColTimeDel
            // 
            ColTimeDel.HeaderText = "Час";
            ColTimeDel.MinimumWidth = 6;
            ColTimeDel.Name = "ColTimeDel";
            // 
            // ColResourse
            // 
            ColResourse.HeaderText = "Обладнання";
            ColResourse.MinimumWidth = 6;
            ColResourse.Name = "ColResourse";
            // 
            // ColPibDell
            // 
            ColPibDell.HeaderText = "ПІБ";
            ColPibDell.MinimumWidth = 6;
            ColPibDell.Name = "ColPibDell";
            // 
            // ColRoleDel
            // 
            ColRoleDel.HeaderText = "Роль";
            ColRoleDel.MinimumWidth = 6;
            ColRoleDel.Name = "ColRoleDel";
            // 
            // ColTypeWorkDel
            // 
            ColTypeWorkDel.HeaderText = "Вид діяльності";
            ColTypeWorkDel.MinimumWidth = 6;
            ColTypeWorkDel.Name = "ColTypeWorkDel";
            // 
            // button_MyScheduleDel
            // 
            button_MyScheduleDel.BackColor = Color.PapayaWhip;
            button_MyScheduleDel.ForeColor = SystemColors.ActiveCaptionText;
            button_MyScheduleDel.Location = new Point(674, 31);
            button_MyScheduleDel.Name = "button_MyScheduleDel";
            button_MyScheduleDel.Size = new Size(756, 29);
            button_MyScheduleDel.TabIndex = 21;
            button_MyScheduleDel.Text = "Мій розклад";
            button_MyScheduleDel.UseVisualStyleBackColor = false;
            // 
            // DeleteRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 588);
            Controls.Add(button_MyScheduleDel);
            Controls.Add(dateTimePicker_ScheduleDel);
            Controls.Add(dataGridView_ScheduleForDel);
            Controls.Add(dataGridView1);
            Controls.Add(button_ByComingDel);
            Controls.Add(button_ScheduleDel);
            Controls.Add(button_ClearDel);
            Controls.Add(button_DeleteReq);
            Controls.Add(label_infoCheckReqDel);
            Controls.Add(richTextBox_CheckReqDel);
            Controls.Add(label_infoEndDel);
            Controls.Add(label_infoStartDel);
            Controls.Add(label_infoDash);
            Controls.Add(label_DayOfResDel);
            Controls.Add(label_infoTypeWorkDelete);
            Controls.Add(label_infoDeleteRes);
            Controls.Add(dateTimePicker_EndDelete);
            Controls.Add(dateTimePicker_StartDelete);
            Controls.Add(monthCalendar_DeleteReq);
            Controls.Add(comboBox_TypeOfWorkDelete);
            Controls.Add(comboBox_Resourse);
            Controls.Add(label_infoDeleteReq);
            Name = "DeleteRequestForm";
            Text = "DeleteRequestForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleForDel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_infoDeleteReq;
        private ComboBox comboBox_Resourse;
        private ComboBox comboBox_TypeOfWorkDelete;
        private MonthCalendar monthCalendar_DeleteReq;
        private DateTimePicker dateTimePicker_StartDelete;
        private DateTimePicker dateTimePicker_EndDelete;
        private Label label_infoDeleteRes;
        private Label label_infoTypeWorkDelete;
        private Label label_DayOfResDel;
        private Label label_infoDash;
        private Label label_infoStartDel;
        private Label label_infoEndDel;
        private RichTextBox richTextBox_CheckReqDel;
        private Label label_infoCheckReqDel;
        private Button button_DeleteReq;
        private Button button_ClearDel;
        private Button button_ScheduleDel;
        private Button button_ByComingDel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColTimeOfComing;
        private DataGridViewTextBoxColumn ColDayOfRes;
        private DataGridViewTextBoxColumn ColIntervalDel;
        private DataGridViewTextBoxColumn ColPib;
        private DataGridViewTextBoxColumn ColResourseDel;
        private DateTimePicker dateTimePicker_ScheduleDel;
        private DataGridView dataGridView_ScheduleForDel;
        private DataGridViewTextBoxColumn ColTimeDel;
        private DataGridViewTextBoxColumn ColResourse;
        private DataGridViewTextBoxColumn ColPibDell;
        private DataGridViewTextBoxColumn ColRoleDel;
        private DataGridViewTextBoxColumn ColTypeWorkDel;
        private Button button_MyScheduleDel;
    }
}