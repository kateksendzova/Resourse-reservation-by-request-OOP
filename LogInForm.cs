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
        }

        private void label_infoSurname_Click(object sender, EventArgs e)
        {

        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            string role = comboBox_Role.SelectedItem?.ToString() ?? "Студент";
            string surname = textBox_Surname.Text.Trim();
            string name = textBox_Name.Text.Trim();
            string fatherName = textBox_FatherName.Text.Trim();

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Будь ласка, введіть прізвище та ім'я!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullUserIdentifier = $"{surname} {name} {fatherName} ({role})";

            AddRequestForm mainForm = new AddRequestForm(fullUserIdentifier);

            mainForm.Show();
            this.Hide();
        }

        private void comboBox_Role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_LogInToDeleteReq_Click(object sender, EventArgs e)
        {
            string role = comboBox_Role.SelectedItem?.ToString() ?? "Студент";
            string surname = textBox_Surname.Text.Trim();
            string name = textBox_Name.Text.Trim();
            string fatherName = textBox_FatherName.Text.Trim();

            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Будь ласка, введіть прізвище та ім'я!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullUserIdentifier = $"{surname} {name} {fatherName} ({role})";

            DeleteRequestForm mainForm = new DeleteRequestForm(fullUserIdentifier);

            mainForm.Show();
            this.Hide();
        }
    }
}
