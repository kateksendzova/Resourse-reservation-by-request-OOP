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
            label_infoReservSystemLogIn = new Label();
            label_infoLogIn = new Label();
            label_infoSurname = new Label();
            label_infoRole = new Label();
            label_infoName = new Label();
            label_infoFatherName = new Label();
            comboBox_Role = new ComboBox();
            textBox_Surname = new TextBox();
            textBox_Name = new TextBox();
            textBox_FatherName = new TextBox();
            button_LogIn = new Button();
            button_LogInToDeleteReq = new Button();
            SuspendLayout();
            // 
            // label_infoReservSystemLogIn
            // 
            label_infoReservSystemLogIn.AutoSize = true;
            label_infoReservSystemLogIn.Location = new Point(185, 25);
            label_infoReservSystemLogIn.Name = "label_infoReservSystemLogIn";
            label_infoReservSystemLogIn.Size = new Size(248, 20);
            label_infoReservSystemLogIn.TabIndex = 0;
            label_infoReservSystemLogIn.Text = "Система бронювання лабораторії";
            // 
            // label_infoLogIn
            // 
            label_infoLogIn.AutoSize = true;
            label_infoLogIn.Location = new Point(278, 56);
            label_infoLogIn.Name = "label_infoLogIn";
            label_infoLogIn.Size = new Size(54, 20);
            label_infoLogIn.TabIndex = 1;
            label_infoLogIn.Text = "Увійти";
            // 
            // label_infoSurname
            // 
            label_infoSurname.AutoSize = true;
            label_infoSurname.Location = new Point(130, 166);
            label_infoSurname.Name = "label_infoSurname";
            label_infoSurname.Size = new Size(77, 20);
            label_infoSurname.TabIndex = 2;
            label_infoSurname.Text = "Прізвище";
            label_infoSurname.Click += label_infoSurname_Click;
            // 
            // label_infoRole
            // 
            label_infoRole.AutoSize = true;
            label_infoRole.Location = new Point(165, 121);
            label_infoRole.Name = "label_infoRole";
            label_infoRole.Size = new Size(42, 20);
            label_infoRole.TabIndex = 3;
            label_infoRole.Text = "Роль";
            // 
            // label_infoName
            // 
            label_infoName.AutoSize = true;
            label_infoName.Location = new Point(172, 218);
            label_infoName.Name = "label_infoName";
            label_infoName.Size = new Size(35, 20);
            label_infoName.TabIndex = 5;
            label_infoName.Text = "Ім'я";
            // 
            // label_infoFatherName
            // 
            label_infoFatherName.AutoSize = true;
            label_infoFatherName.Location = new Point(113, 271);
            label_infoFatherName.Name = "label_infoFatherName";
            label_infoFatherName.Size = new Size(94, 20);
            label_infoFatherName.TabIndex = 4;
            label_infoFatherName.Text = "По-батькові";
            // 
            // comboBox_Role
            // 
            comboBox_Role.FormattingEnabled = true;
            comboBox_Role.Location = new Point(210, 117);
            comboBox_Role.Name = "comboBox_Role";
            comboBox_Role.Size = new Size(185, 28);
            comboBox_Role.TabIndex = 6;
            comboBox_Role.SelectedIndexChanged += comboBox_Role_SelectedIndexChanged;
            // 
            // textBox_Surname
            // 
            textBox_Surname.Location = new Point(210, 162);
            textBox_Surname.Name = "textBox_Surname";
            textBox_Surname.Size = new Size(185, 27);
            textBox_Surname.TabIndex = 7;
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(210, 214);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(185, 27);
            textBox_Name.TabIndex = 8;
            // 
            // textBox_FatherName
            // 
            textBox_FatherName.Location = new Point(210, 267);
            textBox_FatherName.Name = "textBox_FatherName";
            textBox_FatherName.Size = new Size(185, 27);
            textBox_FatherName.TabIndex = 9;
            // 
            // button_LogIn
            // 
            button_LogIn.BackColor = SystemColors.HotTrack;
            button_LogIn.ForeColor = SystemColors.ButtonHighlight;
            button_LogIn.Location = new Point(157, 334);
            button_LogIn.Name = "button_LogIn";
            button_LogIn.Size = new Size(131, 49);
            button_LogIn.TabIndex = 10;
            button_LogIn.Text = "Увійти, щоб забронювати";
            button_LogIn.UseVisualStyleBackColor = false;
            button_LogIn.Click += button_LogIn_Click;
            // 
            // button_LogInToDeleteReq
            // 
            button_LogInToDeleteReq.BackColor = SystemColors.GradientActiveCaption;
            button_LogInToDeleteReq.ForeColor = SystemColors.ActiveCaptionText;
            button_LogInToDeleteReq.Location = new Point(296, 334);
            button_LogInToDeleteReq.Name = "button_LogInToDeleteReq";
            button_LogInToDeleteReq.Size = new Size(131, 49);
            button_LogInToDeleteReq.TabIndex = 11;
            button_LogInToDeleteReq.Text = "Увійти, щоб видалити";
            button_LogInToDeleteReq.UseVisualStyleBackColor = false;
            button_LogInToDeleteReq.Click += button_LogInToDeleteReq_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 442);
            Controls.Add(button_LogInToDeleteReq);
            Controls.Add(button_LogIn);
            Controls.Add(textBox_FatherName);
            Controls.Add(textBox_Name);
            Controls.Add(textBox_Surname);
            Controls.Add(comboBox_Role);
            Controls.Add(label_infoName);
            Controls.Add(label_infoFatherName);
            Controls.Add(label_infoRole);
            Controls.Add(label_infoSurname);
            Controls.Add(label_infoLogIn);
            Controls.Add(label_infoReservSystemLogIn);
            Name = "LogInForm";
            Text = "LogInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_infoReservSystemLogIn;
        private Label label_infoLogIn;
        private Label label_infoSurname;
        private Label label_infoRole;
        private Label label_infoName;
        private Label label_infoFatherName;
        private ComboBox comboBox_Role;
        private TextBox textBox_Surname;
        private TextBox textBox_Name;
        private TextBox textBox_FatherName;
        private Button button_LogIn;
        private Button button_LogInToDeleteReq;
    }
}