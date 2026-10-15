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
            pictureBox_LogoDel = new PictureBox();
            button_PanelDelReq = new Button();
            pictureBox_LogoSchedule = new PictureBox();
            button2 = new Button();
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
            dateTimePicker_DeleteReq = new DateTimePicker();
            label1 = new Label();
            dataGridView_MySchedule = new DataGridView();
            ColumnTime = new DataGridViewTextBoxColumn();
            ColumnName = new DataGridViewTextBoxColumn();
            ColumnRes = new DataGridViewTextBoxColumn();
            ColumnType = new DataGridViewTextBoxColumn();
            label2 = new Label();
            dataGridView_ByComing = new DataGridView();
            ColumnComingDate = new DataGridViewTextBoxColumn();
            ColumnReservedDate = new DataGridViewTextBoxColumn();
            ColumnPIB = new DataGridViewTextBoxColumn();
            ColumnResource = new DataGridViewTextBoxColumn();
            ColumnTypeOfWork = new DataGridViewTextBoxColumn();
            label_infoSystemName = new Label();
            panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoDel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarAssistant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarProfesor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AvatarStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMySchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_LogoMakeReq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_MySchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ByComing).BeginInit();
            SuspendLayout();
            // 
            // panel_Menu
            // 
            panel_Menu.BackColor = Color.DarkCyan;
            panel_Menu.Controls.Add(pictureBox_LogoDel);
            panel_Menu.Controls.Add(button_PanelDelReq);
            panel_Menu.Controls.Add(pictureBox_LogoSchedule);
            panel_Menu.Controls.Add(button2);
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
            // pictureBox_LogoDel
            // 
            pictureBox_LogoDel.Image = (Image)resources.GetObject("pictureBox_LogoDel.Image");
            pictureBox_LogoDel.InitialImage = (Image)resources.GetObject("pictureBox_LogoDel.InitialImage");
            pictureBox_LogoDel.Location = new Point(32, 317);
            pictureBox_LogoDel.Name = "pictureBox_LogoDel";
            pictureBox_LogoDel.Size = new Size(50, 41);
            pictureBox_LogoDel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoDel.TabIndex = 41;
            pictureBox_LogoDel.TabStop = false;
            // 
            // button_PanelDelReq
            // 
            button_PanelDelReq.FlatAppearance.BorderSize = 0;
            button_PanelDelReq.FlatStyle = FlatStyle.Flat;
            button_PanelDelReq.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelDelReq.ForeColor = Color.AliceBlue;
            button_PanelDelReq.Location = new Point(63, 321);
            button_PanelDelReq.Name = "button_PanelDelReq";
            button_PanelDelReq.Size = new Size(168, 33);
            button_PanelDelReq.TabIndex = 40;
            button_PanelDelReq.Text = "Видалити запит";
            button_PanelDelReq.TextAlign = ContentAlignment.MiddleRight;
            button_PanelDelReq.UseVisualStyleBackColor = true;
            button_PanelDelReq.Click += button_PanelDelReq_Click;
            // 
            // pictureBox_LogoSchedule
            // 
            pictureBox_LogoSchedule.Image = (Image)resources.GetObject("pictureBox_LogoSchedule.Image");
            pictureBox_LogoSchedule.InitialImage = (Image)resources.GetObject("pictureBox_LogoSchedule.InitialImage");
            pictureBox_LogoSchedule.Location = new Point(37, 258);
            pictureBox_LogoSchedule.Name = "pictureBox_LogoSchedule";
            pictureBox_LogoSchedule.Size = new Size(39, 34);
            pictureBox_LogoSchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoSchedule.TabIndex = 39;
            pictureBox_LogoSchedule.TabStop = false;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(75, 259);
            button2.Name = "button2";
            button2.Size = new Size(181, 33);
            button2.TabIndex = 38;
            button2.Text = "Загальний розклад";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
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
            pictureBox_LogoMySchedule.Location = new Point(37, 191);
            pictureBox_LogoMySchedule.Name = "pictureBox_LogoMySchedule";
            pictureBox_LogoMySchedule.Size = new Size(42, 41);
            pictureBox_LogoMySchedule.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoMySchedule.TabIndex = 34;
            pictureBox_LogoMySchedule.TabStop = false;
            // 
            // pictureBox_LogoMakeReq
            // 
            pictureBox_LogoMakeReq.Image = (Image)resources.GetObject("pictureBox_LogoMakeReq.Image");
            pictureBox_LogoMakeReq.InitialImage = (Image)resources.GetObject("pictureBox_LogoMakeReq.InitialImage");
            pictureBox_LogoMakeReq.Location = new Point(35, 126);
            pictureBox_LogoMakeReq.Name = "pictureBox_LogoMakeReq";
            pictureBox_LogoMakeReq.Size = new Size(42, 41);
            pictureBox_LogoMakeReq.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LogoMakeReq.TabIndex = 33;
            pictureBox_LogoMakeReq.TabStop = false;
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
            // label_RoleNameSch
            // 
            label_RoleNameSch.AutoSize = true;
            label_RoleNameSch.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_RoleNameSch.ForeColor = Color.AliceBlue;
            label_RoleNameSch.Location = new Point(78, 879);
            label_RoleNameSch.Name = "label_RoleNameSch";
            label_RoleNameSch.Size = new Size(37, 20);
            label_RoleNameSch.TabIndex = 4;
            label_RoleNameSch.Text = "Ім'я";
            // 
            // button_PanelAddReq
            // 
            button_PanelAddReq.FlatAppearance.BorderSize = 0;
            button_PanelAddReq.FlatStyle = FlatStyle.Flat;
            button_PanelAddReq.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_PanelAddReq.ForeColor = Color.AliceBlue;
            button_PanelAddReq.Location = new Point(82, 130);
            button_PanelAddReq.Name = "button_PanelAddReq";
            button_PanelAddReq.Size = new Size(152, 33);
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
            button_PanelMySchedule.Location = new Point(76, 195);
            button_PanelMySchedule.Name = "button_PanelMySchedule";
            button_PanelMySchedule.Size = new Size(128, 33);
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
            button_PanelMainForm.Location = new Point(80, 71);
            button_PanelMainForm.Name = "button_PanelMainForm";
            button_PanelMainForm.Size = new Size(87, 33);
            button_PanelMainForm.TabIndex = 1;
            button_PanelMainForm.Text = "Головна";
            button_PanelMainForm.TextAlign = ContentAlignment.MiddleRight;
            button_PanelMainForm.UseVisualStyleBackColor = true;
            button_PanelMainForm.Click += button_PanelMainForm_Click;
            // 
            // dateTimePicker_DeleteReq
            // 
            dateTimePicker_DeleteReq.CalendarFont = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker_DeleteReq.Format = DateTimePickerFormat.Short;
            dateTimePicker_DeleteReq.Location = new Point(445, 171);
            dateTimePicker_DeleteReq.Name = "dateTimePicker_DeleteReq";
            dateTimePicker_DeleteReq.Size = new Size(674, 26);
            dateTimePicker_DeleteReq.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(669, 147);
            label1.Name = "label1";
            label1.Size = new Size(216, 21);
            label1.TabIndex = 58;
            label1.Text = "Розклад на обрану дату";
            // 
            // dataGridView_MySchedule
            // 
            dataGridView_MySchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_MySchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_MySchedule.Columns.AddRange(new DataGridViewColumn[] { ColumnTime, ColumnName, ColumnRes, ColumnType });
            dataGridView_MySchedule.Location = new Point(445, 203);
            dataGridView_MySchedule.Name = "dataGridView_MySchedule";
            dataGridView_MySchedule.RowHeadersWidth = 51;
            dataGridView_MySchedule.Size = new Size(674, 570);
            dataGridView_MySchedule.TabIndex = 57;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(1396, 147);
            label2.Name = "label2";
            label2.Size = new Size(297, 21);
            label2.TabIndex = 61;
            label2.Text = "Розклад за надходженням запитів";
            // 
            // dataGridView_ByComing
            // 
            dataGridView_ByComing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_ByComing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_ByComing.Columns.AddRange(new DataGridViewColumn[] { ColumnComingDate, ColumnReservedDate, ColumnPIB, ColumnResource, ColumnTypeOfWork });
            dataGridView_ByComing.Location = new Point(1198, 171);
            dataGridView_ByComing.Name = "dataGridView_ByComing";
            dataGridView_ByComing.RowHeadersWidth = 51;
            dataGridView_ByComing.Size = new Size(674, 602);
            dataGridView_ByComing.TabIndex = 60;
            // 
            // ColumnComingDate
            // 
            ColumnComingDate.HeaderText = "Час надходження";
            ColumnComingDate.MinimumWidth = 6;
            ColumnComingDate.Name = "ColumnComingDate";
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
            // ColumnResource
            // 
            ColumnResource.HeaderText = "Обладнання";
            ColumnResource.MinimumWidth = 6;
            ColumnResource.Name = "ColumnResource";
            // 
            // ColumnTypeOfWork
            // 
            ColumnTypeOfWork.HeaderText = "Тип роботи";
            ColumnTypeOfWork.MinimumWidth = 6;
            ColumnTypeOfWork.Name = "ColumnTypeOfWork";
            // 
            // label_infoSystemName
            // 
            label_infoSystemName.AutoSize = true;
            label_infoSystemName.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_infoSystemName.Location = new Point(1107, 32);
            label_infoSystemName.Name = "label_infoSystemName";
            label_infoSystemName.Size = new Size(184, 22);
            label_infoSystemName.TabIndex = 62;
            label_infoSystemName.Text = "Загальний розклад";
            // 
            // Schedule_Form
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1924, 1033);
            Controls.Add(label_infoSystemName);
            Controls.Add(label2);
            Controls.Add(dataGridView_ByComing);
            Controls.Add(dateTimePicker_DeleteReq);
            Controls.Add(label1);
            Controls.Add(dataGridView_MySchedule);
            Controls.Add(panel_Menu);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView_MySchedule).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_ByComing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_Menu;
        private PictureBox pictureBox_LogoDel;
        private Button button_PanelDelReq;
        private PictureBox pictureBox_LogoSchedule;
        private Button button2;
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
        private DateTimePicker dateTimePicker_DeleteReq;
        private Label label1;
        private DataGridView dataGridView_MySchedule;
        private DataGridViewTextBoxColumn ColumnTime;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnRes;
        private DataGridViewTextBoxColumn ColumnType;
        private Label label2;
        private DataGridView dataGridView_ByComing;
        private DataGridViewTextBoxColumn ColumnComingDate;
        private DataGridViewTextBoxColumn ColumnReservedDate;
        private DataGridViewTextBoxColumn ColumnPIB;
        private DataGridViewTextBoxColumn ColumnResource;
        private DataGridViewTextBoxColumn ColumnTypeOfWork;
        private Label label_infoSystemName;
    }
}