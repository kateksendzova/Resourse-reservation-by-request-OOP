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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRequestForm));
            label_infoSystemName = new Label();
            label_infoChooseResource = new Label();
            label_infoDay = new Label();
            TimePicker_StartOfWork = new DateTimePicker();
            label_infoTimeStartManual = new Label();
            monthCalendar = new MonthCalendar();
            button_AddRequest = new Button();
            label_infoPriority = new Label();
            richTextBox_request = new RichTextBox();
            label_infoReqRichText = new Label();
            label_infoInterval = new Label();
            button_ClearAll = new Button();
            dateTimePicker_Interval = new DateTimePicker();
            panel_Menu = new Panel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            pictureBox_PanelSchedule = new PictureBox();
            button_PanelSchedule = new Button();
            pictureBox_AvatarAssistant = new PictureBox();
            pictureBox_AvatarProfesor = new PictureBox();
            pictureBox_AvatarStudent = new PictureBox();
            pictureBox_PanelMySchedule = new PictureBox();
            pictureBox_PanelMakeReq = new PictureBox();
            pictureBox_Logo = new PictureBox();
            label_RoleName = new Label();
            button2 = new Button();
            button_PanelMySchedule = new Button();
            button_PanelMane = new Button();
            listBox_Resources = new ListBox();
            listBox_Priority = new ListBox();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMySchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMakeReq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            SuspendLayout();
            // 
            // label_infoSystemName
            // 
            label_infoSystemName.AutoSize = true;
            label_infoSystemName.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_infoSystemName.Location = new Point(995, 18);
            label_infoSystemName.Name = "label_infoSystemName";
            label_infoSystemName.Size = new Size(283, 22);
            label_infoSystemName.TabIndex = 0;
            label_infoSystemName.Text = "Додати запит на обладнання";
            // 
            // label_infoChooseResource
            // 
            label_infoChooseResource.AutoSize = true;
            label_infoChooseResource.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoChooseResource.Location = new Point(632, 100);
            label_infoChooseResource.Name = "label_infoChooseResource";
            label_infoChooseResource.Size = new Size(185, 21);
            label_infoChooseResource.TabIndex = 1;
            label_infoChooseResource.Text = "Оберіть обладнання";
            // 
            // label_infoDay
            // 
            label_infoDay.AutoSize = true;
            label_infoDay.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoDay.Location = new Point(1106, 101);
            label_infoDay.Name = "label_infoDay";
            label_infoDay.Size = new Size(121, 21);
            label_infoDay.TabIndex = 3;
            label_infoDay.Text = "Оберіть день";
            // 
            // TimePicker_StartOfWork
            // 
            TimePicker_StartOfWork.CalendarMonthBackground = Color.LightCyan;
            TimePicker_StartOfWork.CustomFormat = "HH:mm";
            TimePicker_StartOfWork.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TimePicker_StartOfWork.Format = DateTimePickerFormat.Custom;
            TimePicker_StartOfWork.Location = new Point(1083, 417);
            TimePicker_StartOfWork.Name = "TimePicker_StartOfWork";
            TimePicker_StartOfWork.ShowUpDown = true;
            TimePicker_StartOfWork.Size = new Size(91, 28);
            TimePicker_StartOfWork.TabIndex = 5;
            // 
            // label_infoTimeStartManual
            // 
            label_infoTimeStartManual.AutoSize = true;
            label_infoTimeStartManual.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoTimeStartManual.Location = new Point(1070, 394);
            label_infoTimeStartManual.Name = "label_infoTimeStartManual";
            label_infoTimeStartManual.Size = new Size(183, 21);
            label_infoTimeStartManual.TabIndex = 6;
            label_infoTimeStartManual.Text = "Оберіть час початку";
            // 
            // monthCalendar
            // 
            monthCalendar.BackColor = Color.LightCyan;
            monthCalendar.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            monthCalendar.Location = new Point(1070, 125);
            monthCalendar.MinDate = new DateTime(2026, 9, 27, 0, 0, 0, 0);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 7;
            // 
            // button_AddRequest
            // 
            button_AddRequest.BackColor = Color.Teal;
            button_AddRequest.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_AddRequest.ForeColor = Color.AliceBlue;
            button_AddRequest.Location = new Point(1712, 805);
            button_AddRequest.Name = "button_AddRequest";
            button_AddRequest.Size = new Size(148, 58);
            button_AddRequest.TabIndex = 11;
            button_AddRequest.Text = "Додати запит";
            button_AddRequest.UseVisualStyleBackColor = false;
            button_AddRequest.Click += button_AddRequest_Click;
            // 
            // label_infoPriority
            // 
            label_infoPriority.AutoSize = true;
            label_infoPriority.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoPriority.Location = new Point(568, 601);
            label_infoPriority.Name = "label_infoPriority";
            label_infoPriority.Size = new Size(105, 21);
            label_infoPriority.TabIndex = 13;
            label_infoPriority.Text = "Тип роботи";
            // 
            // richTextBox_request
            // 
            richTextBox_request.BackColor = Color.LightCyan;
            richTextBox_request.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox_request.Location = new Point(1361, 170);
            richTextBox_request.Name = "richTextBox_request";
            richTextBox_request.Size = new Size(499, 603);
            richTextBox_request.TabIndex = 15;
            richTextBox_request.Text = "";
            // 
            // label_infoReqRichText
            // 
            label_infoReqRichText.AutoSize = true;
            label_infoReqRichText.Font = new Font("Century Gothic", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label_infoReqRichText.Location = new Point(1373, 142);
            label_infoReqRichText.Name = "label_infoReqRichText";
            label_infoReqRichText.Size = new Size(475, 21);
            label_infoReqRichText.TabIndex = 16;
            label_infoReqRichText.Text = "Ваш запит на обладнання. Перевірте його та додайте";
            // 
            // label_infoInterval
            // 
            label_infoInterval.AutoSize = true;
            label_infoInterval.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoInterval.Location = new Point(1070, 475);
            label_infoInterval.Name = "label_infoInterval";
            label_infoInterval.Size = new Size(170, 21);
            label_infoInterval.TabIndex = 21;
            label_infoInterval.Text = "Введіть час роботи";
            // 
            // button_ClearAll
            // 
            button_ClearAll.BackColor = Color.AliceBlue;
            button_ClearAll.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button_ClearAll.Location = new Point(1731, 895);
            button_ClearAll.Name = "button_ClearAll";
            button_ClearAll.Size = new Size(129, 58);
            button_ClearAll.TabIndex = 25;
            button_ClearAll.Text = "Очистити";
            button_ClearAll.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker_Interval
            // 
            dateTimePicker_Interval.CalendarMonthBackground = Color.LightCyan;
            dateTimePicker_Interval.CustomFormat = "HH:mm";
            dateTimePicker_Interval.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_Interval.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Interval.Location = new Point(1083, 499);
            dateTimePicker_Interval.Name = "dateTimePicker_Interval";
            dateTimePicker_Interval.ShowUpDown = true;
            dateTimePicker_Interval.Size = new Size(91, 28);
            dateTimePicker_Interval.TabIndex = 30;
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.DarkCyan;
            panel_Menu.Controls.Add(pictureBox1);
            panel_Menu.Controls.Add(button1);
            panel_Menu.Controls.Add(pictureBox_PanelSchedule);
            panel_Menu.Controls.Add(button_PanelSchedule);
            panel_Menu.Controls.Add(pictureBox_AvatarAssistant);
            panel_Menu.Controls.Add(pictureBox_AvatarProfesor);
            panel_Menu.Controls.Add(pictureBox_AvatarStudent);
            panel_Menu.Controls.Add(pictureBox_PanelMySchedule);
            panel_Menu.Controls.Add(pictureBox_PanelMakeReq);
            panel_Menu.Controls.Add(pictureBox_Logo);
            panel_Menu.Controls.Add(label_RoleName);
            panel_Menu.Controls.Add(button2);
            panel_Menu.Controls.Add(button_PanelMySchedule);
            panel_Menu.Controls.Add(button_PanelMane);
            panel_Menu.Dock = DockStyle.Left;
            panel_Menu.Location = new Point(0, 0);
            panel_Menu.Name = "panel_Menu";
            panel_Menu.Size = new Size(382, 1033);
            panel_Menu.TabIndex = 31;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(32, 317);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 41;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.AliceBlue;
            button1.Location = new Point(63, 321);
            button1.Name = "button1";
            button1.Size = new Size(168, 33);
            button1.TabIndex = 40;
            button1.Text = "Видалити запит";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox_PanelSchedule
            // 
            pictureBox_PanelSchedule.Image = (Image)resources.GetObject("pictureBox_PanelSchedule.Image");
            pictureBox_PanelSchedule.InitialImage = (Image)resources.GetObject("pictureBox_PanelSchedule.InitialImage");
            pictureBox_PanelSchedule.Location = new Point(37, 258);
            pictureBox_PanelSchedule.Name = "pictureBox_PanelSchedule";
            pictureBox_PanelSchedule.Size = new Size(39, 34);
            pictureBox_PanelSchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PanelSchedule.TabIndex = 39;
            pictureBox_PanelSchedule.TabStop = false;
            // 
            // button_PanelSchedule
            // 
            button_PanelSchedule.FlatAppearance.BorderSize = 0;
            button_PanelSchedule.FlatStyle = FlatStyle.Flat;
            button_PanelSchedule.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelSchedule.ForeColor = Color.AliceBlue;
            button_PanelSchedule.Location = new Point(75, 259);
            button_PanelSchedule.Name = "button_PanelSchedule";
            button_PanelSchedule.Size = new Size(181, 33);
            button_PanelSchedule.TabIndex = 38;
            button_PanelSchedule.Text = "Загальний розклад";
            button_PanelSchedule.TextAlign = ContentAlignment.MiddleRight;
            button_PanelSchedule.UseVisualStyleBackColor = true;
            // 
            // pictureBox_AvatarAssistant
            // 
            pictureBox_AvatarAssistant.Image = (Image)resources.GetObject("pictureBox_AvatarAssistant.Image");
            pictureBox_AvatarAssistant.InitialImage = (Image)resources.GetObject("pictureBox_AvatarAssistant.InitialImage");
            pictureBox_AvatarAssistant.Location = new Point(30, 864);
            pictureBox_AvatarAssistant.Name = "pictureBox_AvatarAssistant";
            pictureBox_AvatarAssistant.Size = new Size(46, 49);
            pictureBox_AvatarAssistant.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_AvatarAssistant.TabIndex = 37;
            pictureBox_AvatarAssistant.TabStop = false;
            // 
            // pictureBox_AvatarProfesor
            // 
            pictureBox_AvatarProfesor.Image = (Image)resources.GetObject("pictureBox_AvatarProfesor.Image");
            pictureBox_AvatarProfesor.InitialImage = (Image)resources.GetObject("pictureBox_AvatarProfesor.InitialImage");
            pictureBox_AvatarProfesor.Location = new Point(30, 864);
            pictureBox_AvatarProfesor.Name = "pictureBox_AvatarProfesor";
            pictureBox_AvatarProfesor.Size = new Size(46, 49);
            pictureBox_AvatarProfesor.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_AvatarProfesor.TabIndex = 36;
            pictureBox_AvatarProfesor.TabStop = false;
            // 
            // pictureBox_AvatarStudent
            // 
            pictureBox_AvatarStudent.Image = (Image)resources.GetObject("pictureBox_AvatarStudent.Image");
            pictureBox_AvatarStudent.InitialImage = (Image)resources.GetObject("pictureBox_AvatarStudent.InitialImage");
            pictureBox_AvatarStudent.Location = new Point(30, 864);
            pictureBox_AvatarStudent.Name = "pictureBox_AvatarStudent";
            pictureBox_AvatarStudent.Size = new Size(46, 49);
            pictureBox_AvatarStudent.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_AvatarStudent.TabIndex = 35;
            pictureBox_AvatarStudent.TabStop = false;
            // 
            // pictureBox_PanelMySchedule
            // 
            pictureBox_PanelMySchedule.Image = (Image)resources.GetObject("pictureBox_PanelMySchedule.Image");
            pictureBox_PanelMySchedule.InitialImage = (Image)resources.GetObject("pictureBox_PanelMySchedule.InitialImage");
            pictureBox_PanelMySchedule.Location = new Point(37, 191);
            pictureBox_PanelMySchedule.Name = "pictureBox_PanelMySchedule";
            pictureBox_PanelMySchedule.Size = new Size(42, 41);
            pictureBox_PanelMySchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PanelMySchedule.TabIndex = 34;
            pictureBox_PanelMySchedule.TabStop = false;
            // 
            // pictureBox_PanelMakeReq
            // 
            pictureBox_PanelMakeReq.Image = (Image)resources.GetObject("pictureBox_PanelMakeReq.Image");
            pictureBox_PanelMakeReq.InitialImage = (Image)resources.GetObject("pictureBox_PanelMakeReq.InitialImage");
            pictureBox_PanelMakeReq.Location = new Point(35, 126);
            pictureBox_PanelMakeReq.Name = "pictureBox_PanelMakeReq";
            pictureBox_PanelMakeReq.Size = new Size(42, 41);
            pictureBox_PanelMakeReq.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PanelMakeReq.TabIndex = 33;
            pictureBox_PanelMakeReq.TabStop = false;
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.Image = (Image)resources.GetObject("pictureBox_Logo.Image");
            pictureBox_Logo.InitialImage = (Image)resources.GetObject("pictureBox_Logo.InitialImage");
            pictureBox_Logo.Location = new Point(30, 63);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(46, 49);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 32;
            pictureBox_Logo.TabStop = false;
            // 
            // label_RoleName
            // 
            label_RoleName.AutoSize = true;
            label_RoleName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_RoleName.ForeColor = Color.AliceBlue;
            label_RoleName.Location = new Point(78, 879);
            label_RoleName.Name = "label_RoleName";
            label_RoleName.Size = new Size(37, 20);
            label_RoleName.TabIndex = 4;
            label_RoleName.Text = "Ім'я";
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(82, 130);
            button2.Name = "button2";
            button2.Size = new Size(152, 33);
            button2.TabIndex = 3;
            button2.Text = "Створити запит";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button_PanelMySchedule
            // 
            button_PanelMySchedule.FlatAppearance.BorderSize = 0;
            button_PanelMySchedule.FlatStyle = FlatStyle.Flat;
            button_PanelMySchedule.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelMySchedule.ForeColor = Color.AliceBlue;
            button_PanelMySchedule.Location = new Point(76, 195);
            button_PanelMySchedule.Name = "button_PanelMySchedule";
            button_PanelMySchedule.Size = new Size(128, 33);
            button_PanelMySchedule.TabIndex = 2;
            button_PanelMySchedule.Text = "Мій розклад";
            button_PanelMySchedule.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMySchedule.UseVisualStyleBackColor = true;
            // 
            // button_PanelMane
            // 
            button_PanelMane.FlatAppearance.BorderSize = 0;
            button_PanelMane.FlatStyle = FlatStyle.Flat;
            button_PanelMane.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelMane.ForeColor = Color.AliceBlue;
            button_PanelMane.Location = new Point(80, 71);
            button_PanelMane.Name = "button_PanelMane";
            button_PanelMane.Size = new Size(87, 33);
            button_PanelMane.TabIndex = 1;
            button_PanelMane.Text = "Головна";
            button_PanelMane.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMane.UseVisualStyleBackColor = true;
            button_PanelMane.Click += button_PanelMane_Click;
            // 
            // listBox_Resources
            // 
            listBox_Resources.BackColor = Color.LightCyan;
            listBox_Resources.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBox_Resources.FormattingEnabled = true;
            listBox_Resources.ItemHeight = 21;
            listBox_Resources.Location = new Point(482, 125);
            listBox_Resources.Name = "listBox_Resources";
            listBox_Resources.Size = new Size(487, 445);
            listBox_Resources.TabIndex = 32;
            // 
            // listBox_Priority
            // 
            listBox_Priority.BackColor = Color.LightCyan;
            listBox_Priority.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listBox_Priority.FormattingEnabled = true;
            listBox_Priority.ItemHeight = 21;
            listBox_Priority.Location = new Point(482, 626);
            listBox_Priority.Name = "listBox_Priority";
            listBox_Priority.Size = new Size(279, 109);
            listBox_Priority.TabIndex = 33;
            // 
            // AddRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1902, 1033);
            Controls.Add(listBox_Priority);
            Controls.Add(listBox_Resources);
            Controls.Add(dateTimePicker_Interval);
            Controls.Add(button_ClearAll);
            Controls.Add(label_infoInterval);
            Controls.Add(label_infoReqRichText);
            Controls.Add(richTextBox_request);
            Controls.Add(label_infoPriority);
            Controls.Add(button_AddRequest);
            Controls.Add(monthCalendar);
            Controls.Add(label_infoTimeStartManual);
            Controls.Add(TimePicker_StartOfWork);
            Controls.Add(label_infoDay);
            Controls.Add(label_infoChooseResource);
            Controls.Add(label_infoSystemName);
            Controls.Add(panel_Menu);
            Name = "AddRequestForm";
            Text = "Створити запит";
            WindowState = FormWindowState.Maximized;
            Load += AddRequestForm_Load;
            panel_Menu.ResumeLayout(false);
            panel_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelSchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMySchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMakeReq).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_infoSystemName;
        private Label label_infoChooseResource;
        private Label label_infoDay;
        private DateTimePicker TimePicker_StartOfWork;
        private Label label_infoTimeStartManual;
        private MonthCalendar monthCalendar;
        private Button button_AddRequest;
        private Label label_infoPriority;
        private RichTextBox richTextBox_request;
        private Label label_infoReqRichText;
        private Label label_infoInterval;
        private Button button_ClearAll;
        private DateTimePicker dateTimePicker_Interval;
        private Panel panel_Menu;
        private Button button_PanelMane;
        private Button button2;
        private Button button_PanelMySchedule;
        private Label label_RoleName;
        private PictureBox pictureBox_Logo;
        private PictureBox pictureBox_PanelMakeReq;
        private PictureBox pictureBox_PanelMySchedule;
        private PictureBox pictureBox_AvatarStudent;
        private PictureBox pictureBox_AvatarAssistant;
        private PictureBox pictureBox_AvatarProfesor;
        private Button button_PanelSchedule;
        private PictureBox pictureBox_PanelSchedule;
        private ListBox listBox_Resources;
        private ListBox listBox_Priority;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
