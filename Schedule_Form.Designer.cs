namespace КурсоваРобота_Ксендзова_ПЗ27
{
    partial class Schedule_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule_Form));
            panel_Menu = new Panel();
            label_infoRole = new Label();
            button_PanelDelReq = new Button();
            pictureBox_LogoDel = new PictureBox();
            pictureBox_LogoSchedule = new PictureBox();
            button_PanelSchedule = new Button();
            pictureBox_AvatarAssistant = new PictureBox();
            pictureBox_AvatarProfesor = new PictureBox();
            pictureBox_AvatarStudent = new PictureBox();
            pictureBox_LogoMySchedule = new PictureBox();
            pictureBox_LogoMakeReq = new PictureBox();
            pictureBox_Logo = new PictureBox();
            label_RoleNameSch = new Label();
            button_PanelAddReq = new Button();
            button_PanelMySchedule = new Button();
            button_PanelMainForm = new Button();
            dataGridView_ScheduleTimeOfBooking = new DataGridView();
            ColumnTime = new DataGridViewTextBoxColumn();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnRes = new DataGridViewTextBoxColumn();
            ColumnType = new DataGridViewTextBoxColumn();
            dataGridView_ScheduleByComing = new DataGridView();
            ColumnReservedDate = new DataGridViewTextBoxColumn();
            ColumnPIB = new DataGridViewTextBoxColumn();
            ColumnTypeOfWork = new DataGridViewTextBoxColumn();
            roundedPanel_ScheduleTimeOfBooking = new RoundedPanel();
            dateTimePicker_ScheduleTimeOfBooking = new DateTimePicker();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            roundedPanel_ByComing = new RoundedPanel();
            comboBox_Resource = new ComboBox();
            dateTimePicker_ScheduleByComing = new DateTimePicker();
            roundedButton_TimeOfBooking = new RoundedButton();
            roundedButton_Resource = new RoundedButton();
            panel_AllElements = new Panel();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoDel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMySchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMakeReq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleTimeOfBooking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleByComing).BeginInit();
            roundedPanel_ScheduleTimeOfBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedPanel_ByComing.SuspendLayout();
            panel_AllElements.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.DarkCyan;
            panel_Menu.Controls.Add(label_infoRole);
            panel_Menu.Controls.Add(button_PanelDelReq);
            panel_Menu.Controls.Add(pictureBox_LogoDel);
            panel_Menu.Controls.Add(pictureBox_LogoSchedule);
            panel_Menu.Controls.Add(button_PanelSchedule);
            panel_Menu.Controls.Add(pictureBox_AvatarAssistant);
            panel_Menu.Controls.Add(pictureBox_AvatarProfesor);
            panel_Menu.Controls.Add(pictureBox_AvatarStudent);
            panel_Menu.Controls.Add(pictureBox_LogoMySchedule);
            panel_Menu.Controls.Add(pictureBox_LogoMakeReq);
            panel_Menu.Controls.Add(pictureBox_Logo);
            panel_Menu.Controls.Add(label_RoleNameSch);
            panel_Menu.Controls.Add(button_PanelAddReq);
            panel_Menu.Controls.Add(button_PanelMySchedule);
            panel_Menu.Controls.Add(button_PanelMainForm);
            panel_Menu.Dock = DockStyle.Left;
            panel_Menu.Location = new Point(0, 0);
            panel_Menu.Name = "panel_Menu";
            panel_Menu.Size = new Size(382, 1033);
            panel_Menu.TabIndex = 55;
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
            // button_PanelDelReq
            // 
            button_PanelDelReq.FlatAppearance.BorderSize = 0;
            button_PanelDelReq.FlatStyle = FlatStyle.Flat;
            button_PanelDelReq.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelDelReq.ForeColor = Color.AliceBlue;
            button_PanelDelReq.Location = new Point(92, 320);
            button_PanelDelReq.Name = "button_PanelDelReq";
            button_PanelDelReq.Size = new Size(152, 33);
            button_PanelDelReq.TabIndex = 40;
            button_PanelDelReq.Text = "Видалити запит";
            button_PanelDelReq.TextAlign = ContentAlignment.MiddleRight;
            button_PanelDelReq.UseVisualStyleBackColor = true;
            button_PanelDelReq.Click += button_PanelDelReq_Click;
            // 
            // pictureBox_LogoDel
            // 
            pictureBox_LogoDel.Image = (Image)resources.GetObject("pictureBox_LogoDel.Image");
            pictureBox_LogoDel.InitialImage = (Image)resources.GetObject("pictureBox_LogoDel.InitialImage");
            pictureBox_LogoDel.Location = new Point(44, 317);
            pictureBox_LogoDel.Name = "pictureBox_LogoDel";
            pictureBox_LogoDel.Size = new Size(63, 41);
            pictureBox_LogoDel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoDel.TabIndex = 41;
            pictureBox_LogoDel.TabStop = false;
            // 
            // pictureBox_LogoSchedule
            // 
            pictureBox_LogoSchedule.Image = (Image)resources.GetObject("pictureBox_LogoSchedule.Image");
            pictureBox_LogoSchedule.InitialImage = (Image)resources.GetObject("pictureBox_LogoSchedule.InitialImage");
            pictureBox_LogoSchedule.Location = new Point(47, 258);
            pictureBox_LogoSchedule.Name = "pictureBox_LogoSchedule";
            pictureBox_LogoSchedule.Size = new Size(50, 34);
            pictureBox_LogoSchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoSchedule.TabIndex = 39;
            pictureBox_LogoSchedule.TabStop = false;
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
            // pictureBox_LogoMySchedule
            // 
            pictureBox_LogoMySchedule.Image = (Image)resources.GetObject("pictureBox_LogoMySchedule.Image");
            pictureBox_LogoMySchedule.InitialImage = (Image)resources.GetObject("pictureBox_LogoMySchedule.InitialImage");
            pictureBox_LogoMySchedule.Location = new Point(47, 191);
            pictureBox_LogoMySchedule.Name = "pictureBox_LogoMySchedule";
            pictureBox_LogoMySchedule.Size = new Size(53, 41);
            pictureBox_LogoMySchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoMySchedule.TabIndex = 34;
            pictureBox_LogoMySchedule.TabStop = false;
            // 
            // pictureBox_LogoMakeReq
            // 
            pictureBox_LogoMakeReq.Image = (Image)resources.GetObject("pictureBox_LogoMakeReq.Image");
            pictureBox_LogoMakeReq.InitialImage = (Image)resources.GetObject("pictureBox_LogoMakeReq.InitialImage");
            pictureBox_LogoMakeReq.Location = new Point(44, 126);
            pictureBox_LogoMakeReq.Name = "pictureBox_LogoMakeReq";
            pictureBox_LogoMakeReq.Size = new Size(53, 41);
            pictureBox_LogoMakeReq.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoMakeReq.TabIndex = 33;
            pictureBox_LogoMakeReq.TabStop = false;
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
            // label_RoleNameSch
            // 
            label_RoleNameSch.AutoSize = true;
            label_RoleNameSch.Font = new Font("Century Gothic", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label_RoleNameSch.ForeColor = Color.AliceBlue;
            label_RoleNameSch.Location = new Point(78, 879);
            label_RoleNameSch.Name = "label_RoleNameSch";
            label_RoleNameSch.Size = new Size(35, 18);
            label_RoleNameSch.TabIndex = 4;
            label_RoleNameSch.Text = "Ім'я";
            // 
            // button_PanelAddReq
            // 
            button_PanelAddReq.FlatAppearance.BorderSize = 0;
            button_PanelAddReq.FlatStyle = FlatStyle.Flat;
            button_PanelAddReq.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelAddReq.ForeColor = Color.AliceBlue;
            button_PanelAddReq.Location = new Point(91, 131);
            button_PanelAddReq.Name = "button_PanelAddReq";
            button_PanelAddReq.Size = new Size(158, 33);
            button_PanelAddReq.TabIndex = 3;
            button_PanelAddReq.Text = "Створити запит";
            button_PanelAddReq.TextAlign = ContentAlignment.MiddleRight;
            button_PanelAddReq.UseVisualStyleBackColor = true;
            button_PanelAddReq.Click += button_PanelAddReq_Click;
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
            // button_PanelMainForm
            // 
            button_PanelMainForm.FlatAppearance.BorderSize = 0;
            button_PanelMainForm.FlatStyle = FlatStyle.Flat;
            button_PanelMainForm.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelMainForm.ForeColor = Color.AliceBlue;
            button_PanelMainForm.Location = new Point(96, 74);
            button_PanelMainForm.Name = "button_PanelMainForm";
            button_PanelMainForm.Size = new Size(89, 33);
            button_PanelMainForm.TabIndex = 1;
            button_PanelMainForm.Text = "Головна";
            button_PanelMainForm.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMainForm.UseVisualStyleBackColor = true;
            button_PanelMainForm.Click += button_PanelMainForm_Click;
            // 
            // dataGridView_ScheduleTimeOfBooking
            // 
            dataGridView_ScheduleTimeOfBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_ScheduleTimeOfBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ScheduleTimeOfBooking.Columns.AddRange(new DataGridViewColumn[] { ColumnTime, ColumnName, ColumnRes, ColumnType });
            dataGridView_ScheduleTimeOfBooking.Location = new Point(22, 98);
            dataGridView_ScheduleTimeOfBooking.Name = "dataGridView_ScheduleTimeOfBooking";
            dataGridView_ScheduleTimeOfBooking.RowHeadersWidth = 51;
            dataGridView_ScheduleTimeOfBooking.Size = new Size(1129, 638);
            dataGridView_ScheduleTimeOfBooking.TabIndex = 57;
            // 
            // ColumnTime
            // 
            ColumnTime.HeaderText = "Час бронювання";
            ColumnTime.MinimumWidth = 6;
            ColumnTime.Name = "ColumnTime";
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "ПІБ";
            ColumnName.MinimumWidth = 6;
            ColumnName.Name = "ColumnName";
            // 
            // ColumnRes
            // 
            ColumnRes.HeaderText = "Обладнання";
            ColumnRes.MinimumWidth = 6;
            ColumnRes.Name = "ColumnRes";
            // 
            // ColumnType
            // 
            ColumnType.HeaderText = "Тип роботи";
            ColumnType.MinimumWidth = 6;
            ColumnType.Name = "ColumnType";
            // 
            // dataGridView_ScheduleByComing
            // 
            dataGridView_ScheduleByComing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_ScheduleByComing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ScheduleByComing.Columns.AddRange(new DataGridViewColumn[] { ColumnReservedDate, ColumnPIB, ColumnTypeOfWork });
            dataGridView_ScheduleByComing.Location = new Point(22, 98);
            dataGridView_ScheduleByComing.Name = "dataGridView_ScheduleByComing";
            dataGridView_ScheduleByComing.RowHeadersWidth = 51;
            dataGridView_ScheduleByComing.Size = new Size(1129, 638);
            dataGridView_ScheduleByComing.TabIndex = 60;
            // 
            // ColumnReservedDate
            // 
            ColumnReservedDate.HeaderText = "Заброньовано на";
            ColumnReservedDate.MinimumWidth = 6;
            ColumnReservedDate.Name = "ColumnReservedDate";
            // 
            // ColumnPIB
            // 
            ColumnPIB.HeaderText = "ПІБ";
            ColumnPIB.MinimumWidth = 6;
            ColumnPIB.Name = "ColumnPIB";
            // 
            // ColumnTypeOfWork
            // 
            ColumnTypeOfWork.HeaderText = "Тип роботи";
            ColumnTypeOfWork.MinimumWidth = 6;
            ColumnTypeOfWork.Name = "ColumnTypeOfWork";
            // 
            // roundedPanel_ScheduleTimeOfBooking
            // 
            roundedPanel_ScheduleTimeOfBooking.AutoScroll = true;
            roundedPanel_ScheduleTimeOfBooking.BackColor = Color.White;
            roundedPanel_ScheduleTimeOfBooking.BorderColor = Color.LightGray;
            roundedPanel_ScheduleTimeOfBooking.Controls.Add(dateTimePicker_ScheduleTimeOfBooking);
            roundedPanel_ScheduleTimeOfBooking.Controls.Add(dataGridView_ScheduleTimeOfBooking);
            roundedPanel_ScheduleTimeOfBooking.CornerRadius = 12;
            roundedPanel_ScheduleTimeOfBooking.Location = new Point(3, 197);
            roundedPanel_ScheduleTimeOfBooking.Name = "roundedPanel_ScheduleTimeOfBooking";
            roundedPanel_ScheduleTimeOfBooking.Size = new Size(1176, 752);
            roundedPanel_ScheduleTimeOfBooking.TabIndex = 63;
            // 
            // dateTimePicker_ScheduleTimeOfBooking
            // 
            dateTimePicker_ScheduleTimeOfBooking.CalendarFont = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_ScheduleTimeOfBooking.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_ScheduleTimeOfBooking.Format = DateTimePickerFormat.Short;
            dateTimePicker_ScheduleTimeOfBooking.Location = new Point(93, 45);
            dateTimePicker_ScheduleTimeOfBooking.MinDate = new DateTime(2026, 10, 21, 0, 0, 0, 0);
            dateTimePicker_ScheduleTimeOfBooking.Name = "dateTimePicker_ScheduleTimeOfBooking";
            dateTimePicker_ScheduleTimeOfBooking.Size = new Size(528, 28);
            dateTimePicker_ScheduleTimeOfBooking.TabIndex = 50;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(4, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 49);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 66;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(59, 67);
            label3.Name = "label3";
            label3.Size = new Size(345, 20);
            label3.TabIndex = 65;
            label3.Text = "Усі бронювання лабораторії на обрану дату";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(59, 34);
            label4.Name = "label4";
            label4.Size = new Size(231, 27);
            label4.TabIndex = 64;
            label4.Text = "Загальний розклад";
            // 
            // roundedPanel_ByComing
            // 
            roundedPanel_ByComing.AutoScroll = true;
            roundedPanel_ByComing.BackColor = Color.White;
            roundedPanel_ByComing.BorderColor = Color.LightGray;
            roundedPanel_ByComing.Controls.Add(comboBox_Resource);
            roundedPanel_ByComing.Controls.Add(dateTimePicker_ScheduleByComing);
            roundedPanel_ByComing.Controls.Add(dataGridView_ScheduleByComing);
            roundedPanel_ByComing.CornerRadius = 12;
            roundedPanel_ByComing.Location = new Point(3, 197);
            roundedPanel_ByComing.Name = "roundedPanel_ByComing";
            roundedPanel_ByComing.Size = new Size(1176, 752);
            roundedPanel_ByComing.TabIndex = 64;
            // 
            // comboBox_Resource
            // 
            comboBox_Resource.FormattingEnabled = true;
            comboBox_Resource.Location = new Point(502, 45);
            comboBox_Resource.Name = "comboBox_Resource";
            comboBox_Resource.Size = new Size(649, 28);
            comboBox_Resource.TabIndex = 69;
            // 
            // dateTimePicker_ScheduleByComing
            // 
            dateTimePicker_ScheduleByComing.CalendarFont = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_ScheduleByComing.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_ScheduleByComing.Format = DateTimePickerFormat.Short;
            dateTimePicker_ScheduleByComing.Location = new Point(22, 45);
            dateTimePicker_ScheduleByComing.MinDate = new DateTime(2026, 10, 27, 0, 0, 0, 0);
            dateTimePicker_ScheduleByComing.Name = "dateTimePicker_ScheduleByComing";
            dateTimePicker_ScheduleByComing.Size = new Size(439, 28);
            dateTimePicker_ScheduleByComing.TabIndex = 50;
            // 
            // roundedButton_TimeOfBooking
            // 
            roundedButton_TimeOfBooking.BackColor = Color.AliceBlue;
            roundedButton_TimeOfBooking.BorderColor = Color.DarkCyan;
            roundedButton_TimeOfBooking.BorderRadius = 30;
            roundedButton_TimeOfBooking.BorderSize = 1;
            roundedButton_TimeOfBooking.FlatAppearance.BorderSize = 0;
            roundedButton_TimeOfBooking.FlatStyle = FlatStyle.Flat;
            roundedButton_TimeOfBooking.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            roundedButton_TimeOfBooking.ForeColor = Color.DarkCyan;
            roundedButton_TimeOfBooking.IsSelected = false;
            roundedButton_TimeOfBooking.Location = new Point(35, 127);
            roundedButton_TimeOfBooking.Name = "roundedButton_TimeOfBooking";
            roundedButton_TimeOfBooking.Size = new Size(243, 39);
            roundedButton_TimeOfBooking.TabIndex = 67;
            roundedButton_TimeOfBooking.Text = "За часом бронювання";
            roundedButton_TimeOfBooking.UseVisualStyleBackColor = false;
            // 
            // roundedButton_Resource
            // 
            roundedButton_Resource.BackColor = Color.AliceBlue;
            roundedButton_Resource.BorderColor = Color.DarkCyan;
            roundedButton_Resource.BorderRadius = 30;
            roundedButton_Resource.BorderSize = 1;
            roundedButton_Resource.FlatAppearance.BorderSize = 0;
            roundedButton_Resource.FlatStyle = FlatStyle.Flat;
            roundedButton_Resource.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            roundedButton_Resource.ForeColor = Color.DarkCyan;
            roundedButton_Resource.IsSelected = false;
            roundedButton_Resource.Location = new Point(297, 127);
            roundedButton_Resource.Name = "roundedButton_Resource";
            roundedButton_Resource.Size = new Size(243, 39);
            roundedButton_Resource.TabIndex = 68;
            roundedButton_Resource.Text = "Для обладнання";
            roundedButton_Resource.UseVisualStyleBackColor = false;
            // 
            // panel_AllElements
            // 
            panel_AllElements.BackColor = Color.Transparent;
            panel_AllElements.Controls.Add(roundedButton_Resource);
            panel_AllElements.Controls.Add(roundedPanel_ByComing);
            panel_AllElements.Controls.Add(roundedPanel_ScheduleTimeOfBooking);
            panel_AllElements.Controls.Add(pictureBox2);
            panel_AllElements.Controls.Add(roundedButton_TimeOfBooking);
            panel_AllElements.Controls.Add(label4);
            panel_AllElements.Controls.Add(label3);
            panel_AllElements.Location = new Point(560, 0);
            panel_AllElements.Name = "panel_AllElements";
            panel_AllElements.Size = new Size(1183, 959);
            panel_AllElements.TabIndex = 69;
            // 
            // Schedule_Form
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1924, 1033);
            Controls.Add(panel_Menu);
            Controls.Add(panel_AllElements);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "Schedule_Form";
            Text = "Загальний розклад";
            WindowState = FormWindowState.Maximized;
            Load += Schedule_Form_Load;
            panel_Menu.ResumeLayout(false);
            panel_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoDel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoSchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMySchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMakeReq).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleTimeOfBooking).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ScheduleByComing).EndInit();
            roundedPanel_ScheduleTimeOfBooking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedPanel_ByComing.ResumeLayout(false);
            panel_AllElements.ResumeLayout(false);
            panel_AllElements.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Menu;
        private PictureBox pictureBox_LogoDel;
        private Button button_PanelDelReq;
        private PictureBox pictureBox_LogoSchedule;
        private Button button_PanelSchedule;
        private PictureBox pictureBox_AvatarAssistant;
        private PictureBox pictureBox_AvatarProfesor;
        private PictureBox pictureBox_AvatarStudent;
        private PictureBox pictureBox_LogoMySchedule;
        private PictureBox pictureBox_LogoMakeReq;
        private PictureBox pictureBox_Logo;
        private Label label_RoleNameSch;
        private Button button_PanelAddReq;
        private Button button_PanelMySchedule;
        private Button button_PanelMainForm;
        private DataGridView dataGridView_ScheduleTimeOfBooking;
        private DataGridViewTextBoxColumn ColumnTime;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnRes;
        private DataGridViewTextBoxColumn ColumnType;
        private Label label2;
        private DataGridView dataGridView_ScheduleByComing;
        private RoundedPanel roundedPanel_ScheduleTimeOfBooking;
        private DateTimePicker dateTimePicker_ScheduleTimeOfBooking;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private RoundedPanel roundedPanel_ByComing;
        private DateTimePicker dateTimePicker_ScheduleByComing;
        private RoundedButton roundedButton_TimeOfBooking;
        private RoundedButton roundedButton_Resource;
        private DataGridViewTextBoxColumn ColumnReservedDate;
        private DataGridViewTextBoxColumn ColumnPIB;
        private DataGridViewTextBoxColumn ColumnTypeOfWork;
        private ComboBox comboBox_Resource;
        private Label label_infoRole;
        private Panel panel_AllElements;
    }
}