using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();

            comboBox_Role.Items.Add("Викладач");
            comboBox_Role.Items.Add("Студент");
            comboBox_Role.Items.Add("Аспірант");

            comboBox_Role.SelectedIndex = 1;

            this.Resize += LogInForm_Resize;
            button_LogIn.Click += button_LogIn_Click;
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            string role = comboBox_Role.SelectedItem?.ToString() ?? "Студент";
            string surname = textBox_Surname.Text.Trim();
            string name = textBox_Name.Text.Trim();
            string fatherName = textBox_FatherName.Text.Trim();

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(fatherName))
            {
                MessageBox.Show("Будь ласка, введіть прізвище, ім'я та по - батькові!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullUserIdentifier = $"{surname} {name} {fatherName} ({role})";

            MainForm_FirstWindow mainForm = new MainForm_FirstWindow(fullUserIdentifier);

            mainForm.Show();
            this.Hide();
        }


        private void LogInForm_Load(object sender, EventArgs e)
        {
            ResetLabelHint(label_infoRightSurname, "Наприклад: Петренко");
            ResetLabelHint(label_infoRightName, "Наприклад: Іван");
            ResetLabelHint(label_infoRightAfterFather, "Наприклад: Петрович");

            textBox_Surname.TextChanged += (s, e) => CheckField(textBox_Surname.Text, label_infoRightSurname, "Прізвище", "Наприклад: Петренко");
            textBox_Name.TextChanged += (s, e) => CheckField(textBox_Name.Text, label_infoRightName, "Ім'я", "Наприклад: Іван");
            textBox_FatherName.TextChanged += (s, e) => CheckField(textBox_FatherName.Text, label_infoRightAfterFather, "По-батькові", "Наприклад: Петрович");

            this.MinimumSize = new Size(500, 500);
            CenterContentPanel();
            ValidateFormState();
        }

        private void LogInForm_Resize(object sender, EventArgs e)
        {
            CenterContentPanel();
        }

        private void CenterContentPanel()
        { 
            if (panel_Content != null)
            {
                panel_Content.Left = (this.ClientSize.Width - panel_Content.Width) / 2;
                panel_Content.Top = (this.ClientSize.Height - panel_Content.Height) / 2;
            }
        }
        private void ResetLabelHint(Label label, string hintText)
        {
            label.Text = hintText;
            label.ForeColor = Color.Gray;
        }

        private bool CheckField(string text, Label errorLabel, string fieldName, string hintText)
        {
            text = text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                ResetLabelHint(errorLabel, hintText);
                ValidateFormState();
                return false;
            }

            if (text.Length < 2)
            {
                errorLabel.Text = "Неправильний формат";
                errorLabel.ForeColor = Color.Red;
                ValidateFormState();
                return false;
            }


            foreach (char c in text)
            {
                if (!char.IsLetter(c) && c != '-' && c != '\'' && c != '’')
                {
                    errorLabel.Text = "Можна вводити лише букви";
                    errorLabel.ForeColor = Color.Red;
                    ValidateFormState();
                    return false;
                }
            }

            errorLabel.Text = "";
            ValidateFormState();
            return true;
        }

        private bool IsFieldValid(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text) || text.Length < 2) return false;

            foreach (char c in text)
            {
                if (!char.IsLetter(c) && c != '-' && c != '\'' && c != '’') return false;
            }
            return true;
        }

        private void ValidateFormState()
        {
            bool isSurnameOk = IsFieldValid(textBox_Surname.Text);
            bool isNameOk = IsFieldValid(textBox_Name.Text);
            bool isFatherOk = IsFieldValid(textBox_FatherName.Text);

            button_LogIn.Enabled = isSurnameOk && isNameOk && isFatherOk;
        }
    }
}
