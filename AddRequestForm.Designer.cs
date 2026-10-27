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
            label_infoRes = new Label();
            TimePicker_StartOfWork = new DateTimePicker();
            label_infoTimeStartManual = new Label();
            monthCalendar = new MonthCalendar();
            button_AddRequest = new Button();
            label_infoInterval = new Label();
            button_ClearAll = new Button();
            dateTimePicker_Interval = new DateTimePicker();
            panel_Menu = new Panel();
            label_infoRole = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
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
            pictureBox2 = new PictureBox();
            roundedPanel_Resources = new RoundedPanel();
            textBox_SearchRes = new TextBox();
            roundedPanel_Calendar = new RoundedPanel();
            label_infoCalendar = new Label();
            roundedPanel_TypeOfWork = new RoundedPanel();
            label1 = new Label();
            roundedPanel_YourRequest = new RoundedPanel();
            richTextBox_YourRequest = new RichTextBox();
            label_infoYourRequest = new Label();
            panel1 = new Panel();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMySchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PanelMakeReq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedPanel_Resources.SuspendLayout();
            roundedPanel_Calendar.SuspendLayout();
            roundedPanel_TypeOfWork.SuspendLayout();
            roundedPanel_YourRequest.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_infoSystemName
            // 
            label_infoSystemName.AutoSize = true;
            label_infoSystemName.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_infoSystemName.Location = new Point(123, 34);
            label_infoSystemName.Name = "label_infoSystemName";
            label_infoSystemName.Size = new Size(337, 27);
            label_infoSystemName.TabIndex = 0;
            label_infoSystemName.Text = "Новий запит на обладнання";
            // 
            // label_infoChooseResource
            // 
            label_infoChooseResource.AutoSize = true;
            label_infoChooseResource.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoChooseResource.Location = new Point(123, 63);
            label_infoChooseResource.Name = "label_infoChooseResource";
            label_infoChooseResource.Size = new Size(292, 20);
            label_infoChooseResource.TabIndex = 1;
            label_infoChooseResource.Text = "Оберіть обладнання, час і тип роботи";
            // 
            // label_infoRes
            // 
            label_infoRes.AutoSize = true;
            label_infoRes.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRes.Location = new Point(32, 20);
            label_infoRes.Name = "label_infoRes";
            label_infoRes.Size = new Size(136, 21);
            label_infoRes.TabIndex = 3;
            label_infoRes.Text = "1. Обладнання";
            // 
            // TimePicker_StartOfWork
            // 
            TimePicker_StartOfWork.CalendarMonthBackground = Color.LightCyan;
            TimePicker_StartOfWork.CustomFormat = "HH:mm";
            TimePicker_StartOfWork.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TimePicker_StartOfWork.Format = DateTimePickerFormat.Custom;
            TimePicker_StartOfWork.Location = new Point(32, 327);
            TimePicker_StartOfWork.Name = "TimePicker_StartOfWork";
            TimePicker_StartOfWork.ShowUpDown = true;
            TimePicker_StartOfWork.Size = new Size(102, 28);
            TimePicker_StartOfWork.TabIndex = 5;
            // 
            // label_infoTimeStartManual
            // 
            label_infoTimeStartManual.AutoSize = true;
            label_infoTimeStartManual.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoTimeStartManual.Location = new Point(32, 303);
            label_infoTimeStartManual.Name = "label_infoTimeStartManual";
            label_infoTimeStartManual.Size = new Size(112, 21);
            label_infoTimeStartManual.TabIndex = 6;
            label_infoTimeStartManual.Text = "Час початку";
            // 
            // monthCalendar
            // 
            monthCalendar.BackColor = Color.LightCyan;
            monthCalendar.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            monthCalendar.Location = new Point(32, 68);
            monthCalendar.Margin = new Padding(10, 9, 10, 9);
            monthCalendar.MinDate = new DateTime(2026, 9, 27, 0, 0, 0, 0);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 7;
            // 
            // button_AddRequest
            // 
            button_AddRequest.BackColor = Color.Teal;
            button_AddRequest.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_AddRequest.ForeColor = Color.AliceBlue;
            button_AddRequest.Location = new Point(63, 583);
            button_AddRequest.Name = "button_AddRequest";
            button_AddRequest.Size = new Size(361, 58);
            button_AddRequest.TabIndex = 11;
            button_AddRequest.Text = "Додати запит";
            button_AddRequest.UseVisualStyleBackColor = false;
            button_AddRequest.Click += button_AddRequest_Click;
            // 
            // label_infoInterval
            // 
            label_infoInterval.AutoSize = true;
            label_infoInterval.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoInterval.Location = new Point(32, 385);
            label_infoInterval.Name = "label_infoInterval";
            label_infoInterval.Size = new Size(98, 21);
            label_infoInterval.TabIndex = 21;
            label_infoInterval.Text = "Тривалість";
            // 
            // button_ClearAll
            // 
            button_ClearAll.BackColor = Color.AliceBlue;
            button_ClearAll.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button_ClearAll.Location = new Point(63, 660);
            button_ClearAll.Name = "button_ClearAll";
            button_ClearAll.Size = new Size(361, 49);
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
            dateTimePicker_Interval.Location = new Point(32, 409);
            dateTimePicker_Interval.Name = "dateTimePicker_Interval";
            dateTimePicker_Interval.ShowUpDown = true;
            dateTimePicker_Interval.Size = new Size(102, 28);
            dateTimePicker_Interval.TabIndex = 30;
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.DarkCyan;
            panel_Menu.Controls.Add(label_infoRole);
            panel_Menu.Controls.Add(button1);
            panel_Menu.Controls.Add(pictureBox1);
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
            // label_infoRole
            // 
            label_infoRole.AutoSize = true;
            label_infoRole.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRole.ForeColor = Color.AliceBlue;
            label_infoRole.Location = new Point(78, 909);
            label_infoRole.Name = "label_infoRole";
            label_infoRole.Size = new Size(38, 17);
            label_infoRole.TabIndex = 42;
            label_infoRole.Text = "Роль";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.AliceBlue;
            button1.Location = new Point(92, 320);
            button1.Name = "button1";
            button1.Size = new Size(152, 33);
            button1.TabIndex = 40;
            button1.Text = "Видалити запит";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(44, 317);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 41;
            pictureBox1.TabStop = false;
            // 
            // pictureBox_PanelSchedule
            // 
            pictureBox_PanelSchedule.Image = (Image)resources.GetObject("pictureBox_PanelSchedule.Image");
            pictureBox_PanelSchedule.InitialImage = (Image)resources.GetObject("pictureBox_PanelSchedule.InitialImage");
            pictureBox_PanelSchedule.Location = new Point(47, 258);
            pictureBox_PanelSchedule.Name = "pictureBox_PanelSchedule";
            pictureBox_PanelSchedule.Size = new Size(50, 34);
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
            button_PanelSchedule.Location = new Point(96, 258);
            button_PanelSchedule.Name = "button_PanelSchedule";
            button_PanelSchedule.Size = new Size(178, 33);
            button_PanelSchedule.TabIndex = 38;
            button_PanelSchedule.Text = "Загальний розклад";
            button_PanelSchedule.TextAlign = ContentAlignment.MiddleRight;
            button_PanelSchedule.UseVisualStyleBackColor = true;
            button_PanelSchedule.Click += button_PanelSchedule_Click;
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
            pictureBox_PanelMySchedule.Location = new Point(47, 191);
            pictureBox_PanelMySchedule.Name = "pictureBox_PanelMySchedule";
            pictureBox_PanelMySchedule.Size = new Size(53, 41);
            pictureBox_PanelMySchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PanelMySchedule.TabIndex = 34;
            pictureBox_PanelMySchedule.TabStop = false;
            // 
            // pictureBox_PanelMakeReq
            // 
            pictureBox_PanelMakeReq.Image = (Image)resources.GetObject("pictureBox_PanelMakeReq.Image");
            pictureBox_PanelMakeReq.InitialImage = (Image)resources.GetObject("pictureBox_PanelMakeReq.InitialImage");
            pictureBox_PanelMakeReq.Location = new Point(44, 126);
            pictureBox_PanelMakeReq.Name = "pictureBox_PanelMakeReq";
            pictureBox_PanelMakeReq.Size = new Size(53, 41);
            pictureBox_PanelMakeReq.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PanelMakeReq.TabIndex = 33;
            pictureBox_PanelMakeReq.TabStop = false;
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.Image = (Image)resources.GetObject("pictureBox_Logo.Image");
            pictureBox_Logo.InitialImage = (Image)resources.GetObject("pictureBox_Logo.InitialImage");
            pictureBox_Logo.Location = new Point(43, 63);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(58, 49);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 32;
            pictureBox_Logo.TabStop = false;
            // 
            // label_RoleName
            // 
            label_RoleName.AutoSize = true;
            label_RoleName.Font = new Font("Century Gothic", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label_RoleName.ForeColor = Color.AliceBlue;
            label_RoleName.Location = new Point(78, 879);
            label_RoleName.Name = "label_RoleName";
            label_RoleName.Size = new Size(35, 18);
            label_RoleName.TabIndex = 4;
            label_RoleName.Text = "Ім'я";
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(91, 131);
            button2.Name = "button2";
            button2.Size = new Size(158, 33);
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
            button_PanelMySchedule.Location = new Point(96, 195);
            button_PanelMySchedule.Name = "button_PanelMySchedule";
            button_PanelMySchedule.Size = new Size(123, 33);
            button_PanelMySchedule.TabIndex = 2;
            button_PanelMySchedule.Text = "Мій розклад";
            button_PanelMySchedule.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMySchedule.UseVisualStyleBackColor = true;
            button_PanelMySchedule.Click += button_PanelMySchedule_Click;
            // 
            // button_PanelMane
            // 
            button_PanelMane.FlatAppearance.BorderSize = 0;
            button_PanelMane.FlatStyle = FlatStyle.Flat;
            button_PanelMane.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelMane.ForeColor = Color.AliceBlue;
            button_PanelMane.Location = new Point(96, 74);
            button_PanelMane.Name = "button_PanelMane";
            button_PanelMane.Size = new Size(89, 33);
            button_PanelMane.TabIndex = 1;
            button_PanelMane.Text = "Головна";
            button_PanelMane.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMane.UseVisualStyleBackColor = true;
            button_PanelMane.Click += button_PanelMane_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(71, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 49);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 42;
            pictureBox2.TabStop = false;
            // 
            // roundedPanel_Resources
            // 
            roundedPanel_Resources.BackColor = Color.White;
            roundedPanel_Resources.BorderColor = Color.LightGray;
            roundedPanel_Resources.Controls.Add(textBox_SearchRes);
            roundedPanel_Resources.Controls.Add(label_infoRes);
            roundedPanel_Resources.CornerRadius = 12;
            roundedPanel_Resources.Location = new Point(18, 124);
            roundedPanel_Resources.Name = "roundedPanel_Resources";
            roundedPanel_Resources.Size = new Size(427, 752);
            roundedPanel_Resources.TabIndex = 44;
            // 
            // textBox_SearchRes
            // 
            textBox_SearchRes.Location = new Point(32, 67);
            textBox_SearchRes.Name = "textBox_SearchRes";
            textBox_SearchRes.Size = new Size(363, 26);
            textBox_SearchRes.TabIndex = 4;
            // 
            // roundedPanel_Calendar
            // 
            roundedPanel_Calendar.BackColor = Color.White;
            roundedPanel_Calendar.BorderColor = Color.LightGray;
            roundedPanel_Calendar.Controls.Add(label_infoCalendar);
            roundedPanel_Calendar.Controls.Add(monthCalendar);
            roundedPanel_Calendar.Controls.Add(label_infoTimeStartManual);
            roundedPanel_Calendar.Controls.Add(TimePicker_StartOfWork);
            roundedPanel_Calendar.Controls.Add(dateTimePicker_Interval);
            roundedPanel_Calendar.Controls.Add(label_infoInterval);
            roundedPanel_Calendar.CornerRadius = 12;
            roundedPanel_Calendar.Location = new Point(479, 124);
            roundedPanel_Calendar.Name = "roundedPanel_Calendar";
            roundedPanel_Calendar.Size = new Size(344, 474);
            roundedPanel_Calendar.TabIndex = 45;
            // 
            // label_infoCalendar
            // 
            label_infoCalendar.AutoSize = true;
            label_infoCalendar.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoCalendar.Location = new Point(32, 20);
            label_infoCalendar.Name = "label_infoCalendar";
            label_infoCalendar.Size = new Size(61, 21);
            label_infoCalendar.TabIndex = 5;
            label_infoCalendar.Text = "2. Час";
            // 
            // roundedPanel_TypeOfWork
            // 
            roundedPanel_TypeOfWork.BackColor = Color.White;
            roundedPanel_TypeOfWork.BorderColor = Color.LightGray;
            roundedPanel_TypeOfWork.Controls.Add(label1);
            roundedPanel_TypeOfWork.CornerRadius = 12;
            roundedPanel_TypeOfWork.Location = new Point(479, 638);
            roundedPanel_TypeOfWork.Name = "roundedPanel_TypeOfWork";
            roundedPanel_TypeOfWork.Size = new Size(344, 238);
            roundedPanel_TypeOfWork.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(32, 20);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 3;
            label1.Text = "3. Тип роботи";
            // 
            // roundedPanel_YourRequest
            // 
            roundedPanel_YourRequest.BackColor = Color.White;
            roundedPanel_YourRequest.BorderColor = Color.LightGray;
            roundedPanel_YourRequest.Controls.Add(button_ClearAll);
            roundedPanel_YourRequest.Controls.Add(button_AddRequest);
            roundedPanel_YourRequest.Controls.Add(richTextBox_YourRequest);
            roundedPanel_YourRequest.Controls.Add(label_infoYourRequest);
            roundedPanel_YourRequest.CornerRadius = 12;
            roundedPanel_YourRequest.Location = new Point(857, 124);
            roundedPanel_YourRequest.Name = "roundedPanel_YourRequest";
            roundedPanel_YourRequest.Size = new Size(474, 752);
            roundedPanel_YourRequest.TabIndex = 45;
            // 
            // richTextBox_YourRequest
            // 
            richTextBox_YourRequest.BorderStyle = BorderStyle.None;
            richTextBox_YourRequest.Location = new Point(18, 67);
            richTextBox_YourRequest.Name = "richTextBox_YourRequest";
            richTextBox_YourRequest.Size = new Size(434, 497);
            richTextBox_YourRequest.TabIndex = 26;
            richTextBox_YourRequest.Text = "";
            // 
            // label_infoYourRequest
            // 
            label_infoYourRequest.AutoSize = true;
            label_infoYourRequest.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoYourRequest.Location = new Point(32, 20);
            label_infoYourRequest.Name = "label_infoYourRequest";
            label_infoYourRequest.Size = new Size(99, 21);
            label_infoYourRequest.TabIndex = 3;
            label_infoYourRequest.Text = "Ваш запит";
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedPanel_YourRequest);
            panel1.Controls.Add(label_infoSystemName);
            panel1.Controls.Add(roundedPanel_Calendar);
            panel1.Controls.Add(roundedPanel_TypeOfWork);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label_infoChooseResource);
            panel1.Controls.Add(roundedPanel_Resources);
            panel1.Location = new Point(474, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1344, 897);
            panel1.TabIndex = 46;
            // 
            // AddRequestForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1924, 1033);
            Controls.Add(panel_Menu);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedPanel_Resources.ResumeLayout(false);
            roundedPanel_Resources.PerformLayout();
            roundedPanel_Calendar.ResumeLayout(false);
            roundedPanel_Calendar.PerformLayout();
            roundedPanel_TypeOfWork.ResumeLayout(false);
            roundedPanel_TypeOfWork.PerformLayout();
            roundedPanel_YourRequest.ResumeLayout(false);
            roundedPanel_YourRequest.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label_infoSystemName;
        private Label label_infoChooseResource;
        private Label label_infoRes;
        private DateTimePicker TimePicker_StartOfWork;
        private Label label_infoTimeStartManual;
        private MonthCalendar monthCalendar;
        private Button button_AddRequest;
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
        private PictureBox pictureBox1;
        private Button button1;
        private PictureBox pictureBox2;
        private RoundedPanel roundedPanel_Resources;
        private RoundedPanel roundedPanel_Calendar;
        private TextBox textBox_SearchRes;
        private Label label_infoCalendar;
        private RoundedPanel roundedPanel_TypeOfWork;
        private Label label1;
        private RoundedPanel roundedPanel_YourRequest;
        private RichTextBox richTextBox_YourRequest;
        private Label label_infoYourRequest;
        private Label label_infoRole;
        private Panel panel1;
    }
}
