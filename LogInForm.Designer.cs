namespace КурсоваРобота_Ксендзова_ПЗ27
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            label_infoReservSystemLogIn = new Label();
            label_infoSurname = new Label();
            label_infoRole = new Label();
            label_infoName = new Label();
            label_infoFatherName = new Label();
            comboBox_Role = new ComboBox();
            textBox_Surname = new TextBox();
            textBox_Name = new TextBox();
            textBox_FatherName = new TextBox();
            button_LogIn = new Button();
            pictureBox2 = new PictureBox();
            label_infoRightSurname = new Label();
            label_infoRightName = new Label();
            label_infoRightAfterFather = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label_infoReservSystemLogIn
            // 
            label_infoReservSystemLogIn.AutoSize = true;
            label_infoReservSystemLogIn.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_infoReservSystemLogIn.Location = new Point(146, 33);
            label_infoReservSystemLogIn.Name = "label_infoReservSystemLogIn";
            label_infoReservSystemLogIn.Size = new Size(307, 19);
            label_infoReservSystemLogIn.TabIndex = 0;
            label_infoReservSystemLogIn.Text = "Система бронювання лабораторії";
            // 
            // label_infoSurname
            // 
            label_infoSurname.AutoSize = true;
            label_infoSurname.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoSurname.Location = new Point(130, 162);
            label_infoSurname.Name = "label_infoSurname";
            label_infoSurname.Size = new Size(79, 20);
            label_infoSurname.TabIndex = 2;
            label_infoSurname.Text = "Прізвище";
            // 
            // label_infoRole
            // 
            label_infoRole.AutoSize = true;
            label_infoRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRole.Location = new Point(165, 102);
            label_infoRole.Name = "label_infoRole";
            label_infoRole.Size = new Size(43, 20);
            label_infoRole.TabIndex = 3;
            label_infoRole.Text = "Роль";
            // 
            // label_infoName
            // 
            label_infoName.AutoSize = true;
            label_infoName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoName.Location = new Point(172, 227);
            label_infoName.Name = "label_infoName";
            label_infoName.Size = new Size(37, 20);
            label_infoName.TabIndex = 5;
            label_infoName.Text = "Ім'я";
            // 
            // label_infoFatherName
            // 
            label_infoFatherName.AutoSize = true;
            label_infoFatherName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoFatherName.Location = new Point(113, 287);
            label_infoFatherName.Name = "label_infoFatherName";
            label_infoFatherName.Size = new Size(95, 20);
            label_infoFatherName.TabIndex = 4;
            label_infoFatherName.Text = "По-батькові";
            // 
            // comboBox_Role
            // 
            comboBox_Role.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Location = new Point(210, 98);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new Size(185, 28);
            comboBox_Role.TabIndex = 6;
            // 
            // textBox_Surname
            // 
            textBox_Surname.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_Surname.Location = new Point(210, 158);
            textBox_Surname.Name = "textBox_Surname";
            textBox_Surname.Size = new Size(185, 26);
            textBox_Surname.TabIndex = 7;
            // 
            // textBox_Name
            // 
            textBox_Name.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_Name.Location = new Point(210, 223);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(185, 26);
            textBox_Name.TabIndex = 8;
            // 
            // textBox_FatherName
            // 
            textBox_FatherName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_FatherName.Location = new Point(210, 283);
            textBox_FatherName.Name = "textBox_FatherName";
            textBox_FatherName.Size = new Size(185, 26);
            textBox_FatherName.TabIndex = 9;
            // 
            // button_LogIn
            // 
            button_LogIn.BackColor = Color.LightCyan;
            button_LogIn.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_LogIn.ForeColor = Color.Black;
            button_LogIn.Location = new Point(232, 368);
            button_LogIn.Name = "button_LogIn";
            button_LogIn.Size = new Size(131, 49);
            button_LogIn.TabIndex = 10;
            button_LogIn.Text = "Увійти";
            button_LogIn.UseVisualStyleBackColor = false;
            button_LogIn.Click += button_LogIn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(94, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 49);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 43;
            pictureBox2.TabStop = false;
            // 
            // label_infoRightSurname
            // 
            label_infoRightSurname.AutoSize = true;
            label_infoRightSurname.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightSurname.ForeColor = Color.Red;
            label_infoRightSurname.Location = new Point(210, 187);
            label_infoRightSurname.Name = "label_infoRightSurname";
            label_infoRightSurname.Size = new Size(92, 17);
            label_infoRightSurname.TabIndex = 44;
            label_infoRightSurname.Text = "Правильність";
            // 
            // label_infoRightName
            // 
            label_infoRightName.AutoSize = true;
            label_infoRightName.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightName.ForeColor = Color.Red;
            label_infoRightName.Location = new Point(210, 252);
            label_infoRightName.Name = "label_infoRightName";
            label_infoRightName.Size = new Size(92, 17);
            label_infoRightName.TabIndex = 45;
            label_infoRightName.Text = "Правильність";
            // 
            // label_infoRightAfterFather
            // 
            label_infoRightAfterFather.AutoSize = true;
            label_infoRightAfterFather.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightAfterFather.ForeColor = Color.Red;
            label_infoRightAfterFather.Location = new Point(210, 312);
            label_infoRightAfterFather.Name = "label_infoRightAfterFather";
            label_infoRightAfterFather.Size = new Size(92, 17);
            label_infoRightAfterFather.TabIndex = 46;
            label_infoRightAfterFather.Text = "Правильність";
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(594, 483);
            Controls.Add(label_infoRightAfterFather);
            Controls.Add(label_infoRightName);
            Controls.Add(label_infoRightSurname);
            Controls.Add(pictureBox2);
            Controls.Add(button_LogIn);
            Controls.Add(textBox_FatherName);
            Controls.Add(textBox_Name);
            Controls.Add(textBox_Surname);
            Controls.Add(comboBox_Role);
            Controls.Add(label_infoName);
            Controls.Add(label_infoFatherName);
            Controls.Add(label_infoRole);
            Controls.Add(label_infoSurname);
            Controls.Add(label_infoReservSystemLogIn);
            Name = "LogInForm";
            Text = "Реєстрація";
            Load += LogInForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_infoReservSystemLogIn;
        private Label label_infoSurname;
        private Label label_infoRole;
        private Label label_infoName;
        private Label label_infoFatherName;
        private ComboBox comboBox_Role;
        private TextBox textBox_Surname;
        private TextBox textBox_Name;
        private TextBox textBox_FatherName;
        private Button button_LogIn;
        private PictureBox pictureBox2;
        private Label label_infoRightSurname;
        private Label label_infoRightName;
        private Label label_infoRightAfterFather;
    }
}