using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public partial class AddRequestForm : Form
    {
        private bool isInitialized = false;
        private Schedule mainSchedule = new Schedule();
        private string currentUserInfo;
        public AddRequestForm(string userInfo)
        {
            InitializeComponent();
        }
    }
}