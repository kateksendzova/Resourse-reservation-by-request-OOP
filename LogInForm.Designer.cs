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
            pictureBox2 = new PictureBox();
            panel_Content = new Panel();
            button_LogIn = new RoundedButton();
            label_infoRightAfterFather = new Label();
            label_infoRightName = new Label();
            label_infoRightSurname = new Label();
            textBox_FatherName = new TextBox();
            textBox_Name = new TextBox();
            textBox_Surname = new TextBox();
            comboBox_Role = new ComboBox();
            label_infoName = new Label();
            label_infoFatherName = new Label();
            label_infoRole = new Label();
            label_infoSurname = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel_Content.SuspendLayout();
            SuspendLayout();
            // 
            // label_infoReservSystemLogIn
            // 
            label_infoReservSystemLogIn.AutoSize = true;
            label_infoReservSystemLogIn.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_infoReservSystemLogIn.Location = new Point(52, 15);
            label_infoReservSystemLogIn.Name = "label_infoReservSystemLogIn";
            label_infoReservSystemLogIn.Size = new Size(307, 19);
            label_infoReservSystemLogIn.TabIndex = 0;
            label_infoReservSystemLogIn.Text = "Система бронювання лабораторії";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 49);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 43;
            pictureBox2.TabStop = false;
            // 
            // panel_Content
            // 
            panel_Content.BackColor = Color.Transparent;
            panel_Content.Controls.Add(button_LogIn);
            panel_Content.Controls.Add(label_infoRightAfterFather);
            panel_Content.Controls.Add(label_infoRightName);
            panel_Content.Controls.Add(label_infoRightSurname);
            panel_Content.Controls.Add(textBox_FatherName);
            panel_Content.Controls.Add(textBox_Name);
            panel_Content.Controls.Add(textBox_Surname);
            panel_Content.Controls.Add(comboBox_Role);
            panel_Content.Controls.Add(label_infoName);
            panel_Content.Controls.Add(label_infoFatherName);
            panel_Content.Controls.Add(label_infoRole);
            panel_Content.Controls.Add(label_infoSurname);
            panel_Content.Controls.Add(pictureBox2);
            panel_Content.Controls.Add(label_infoReservSystemLogIn);
            panel_Content.Location = new Point(94, 20);
            panel_Content.Name = "panel_Content";
            panel_Content.Size = new Size(364, 420);
            panel_Content.TabIndex = 47;
            // 
            // button_LogIn
            // 
            button_LogIn.BackColor = Color.AliceBlue;
            button_LogIn.BorderColor = Color.DarkCyan;
            button_LogIn.BorderRadius = 30;
            button_LogIn.BorderSize = 1;
            button_LogIn.FlatAppearance.BorderSize = 0;
            button_LogIn.FlatStyle = FlatStyle.Flat;
            button_LogIn.Font = new Font("Century Gothic", 9.5F, FontStyle.Bold);
            button_LogIn.ForeColor = Color.DarkCyan;
            button_LogIn.IsSelected = false;
            button_LogIn.Location = new Point(101, 351);
            button_LogIn.Name = "button_LogIn";
            button_LogIn.Size = new Size(162, 50);
            button_LogIn.TabIndex = 59;
            button_LogIn.Text = "Увійти";
            button_LogIn.UseVisualStyleBackColor = false;
            // 
            // label_infoRightAfterFather
            // 
            label_infoRightAfterFather.AutoSize = true;
            label_infoRightAfterFather.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightAfterFather.ForeColor = Color.Red;
            label_infoRightAfterFather.Location = new Point(114, 298);
            label_infoRightAfterFather.Name = "label_infoRightAfterFather";
            label_infoRightAfterFather.Size = new Size(92, 17);
            label_infoRightAfterFather.TabIndex = 58;
            label_infoRightAfterFather.Text = "Правильність";
            // 
            // label_infoRightName
            // 
            label_infoRightName.AutoSize = true;
            label_infoRightName.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightName.ForeColor = Color.Red;
            label_infoRightName.Location = new Point(114, 238);
            label_infoRightName.Name = "label_infoRightName";
            label_infoRightName.Size = new Size(92, 17);
            label_infoRightName.TabIndex = 57;
            label_infoRightName.Text = "Правильність";
            // 
            // label_infoRightSurname
            // 
            label_infoRightSurname.AutoSize = true;
            label_infoRightSurname.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRightSurname.ForeColor = Color.Red;
            label_infoRightSurname.Location = new Point(114, 173);
            label_infoRightSurname.Name = "label_infoRightSurname";
            label_infoRightSurname.Size = new Size(92, 17);
            label_infoRightSurname.TabIndex = 56;
            label_infoRightSurname.Text = "Правильність";
            // 
            // textBox_FatherName
            // 
            textBox_FatherName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_FatherName.Location = new Point(114, 269);
            textBox_FatherName.Name = "textBox_FatherName";
            textBox_FatherName.Size = new Size(185, 26);
            textBox_FatherName.TabIndex = 54;
            // 
            // textBox_Name
            // 
            textBox_Name.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_Name.Location = new Point(114, 209);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(185, 26);
            textBox_Name.TabIndex = 53;
            // 
            // textBox_Surname
            // 
            textBox_Surname.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_Surname.Location = new Point(114, 144);
            textBox_Surname.Name = "textBox_Surname";
            textBox_Surname.Size = new Size(185, 26);
            textBox_Surname.TabIndex = 52;
            // 
            // comboBox_Role
            // 
            comboBox_Role.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Role.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Location = new Point(114, 84);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new Size(185, 28);
            comboBox_Role.TabIndex = 51;
            // 
            // label_infoName
            // 
            label_infoName.AutoSize = true;
            label_infoName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoName.Location = new Point(76, 213);
            label_infoName.Name = "label_infoName";
            label_infoName.Size = new Size(37, 20);
            label_infoName.TabIndex = 50;
            label_infoName.Text = "Ім'я";
            // 
            // label_infoFatherName
            // 
            label_infoFatherName.AutoSize = true;
            label_infoFatherName.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoFatherName.Location = new Point(17, 273);
            label_infoFatherName.Name = "label_infoFatherName";
            label_infoFatherName.Size = new Size(95, 20);
            label_infoFatherName.TabIndex = 49;
            label_infoFatherName.Text = "По-батькові";
            // 
            // label_infoRole
            // 
            label_infoRole.AutoSize = true;
            label_infoRole.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoRole.Location = new Point(69, 88);
            label_infoRole.Name = "label_infoRole";
            label_infoRole.Size = new Size(43, 20);
            label_infoRole.TabIndex = 48;
            label_infoRole.Text = "Роль";
            // 
            // label_infoSurname
            // 
            label_infoSurname.AutoSize = true;
            label_infoSurname.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_infoSurname.Location = new Point(34, 148);
            label_infoSurname.Name = "label_infoSurname";
            label_infoSurname.Size = new Size(79, 20);
            label_infoSurname.TabIndex = 47;
            label_infoSurname.Text = "Прізвище";
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(594, 483);
            Controls.Add(panel_Content);
            Name = "LogInForm";
            Text = "Реєстрація";
            Load += LogInForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel_Content.ResumeLayout(false);
            panel_Content.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label_infoReservSystemLogIn;
        private PictureBox pictureBox2;
        private Panel panel_Content;
        private Label label_infoRightAfterFather;
        private Label label_infoRightName;
        private Label label_infoRightSurname;
        private TextBox textBox_FatherName;
        private TextBox textBox_Name;
        private TextBox textBox_Surname;
        private ComboBox comboBox_Role;
        private Label label_infoName;
        private Label label_infoFatherName;
        private Label label_infoRole;
        private Label label_infoSurname;
        private RoundedButton button_LogIn;
    }
}