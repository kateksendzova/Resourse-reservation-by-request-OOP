using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public class BaseForm : Form
    {
        private bool isNavigating;
        protected UserContext currentUser { get; }

        public BaseForm() { }

        public BaseForm(UserContext userContext)
        {
            currentUser = userContext;

            FormClosed += (s, e) =>
            {
                if (isNavigating)
                {
                    Application.Exit();
                }
            };
        }

        protected void NavigateTo(AppPage page) => NavigateTo(Navigator.Create(page, currentUser));

        protected void NavigateTo(Form next)
        {
            isNavigating = true;
            next.Show();
            this.Hide();
        }

        protected void ShowUserInfo(Label nameLabel, Label roleLabel, PictureBox student, PictureBox assistant, PictureBox professor)
        {
            if (currentUser == null) return;

            if(nameLabel!=null)
            {
                nameLabel.Text = currentUser.Name;
            }

            if (roleLabel != null)
            {
                roleLabel.Text = currentUser.Role.ToDisplayName();
            }

            if (student != null)
            {
                student.Visible = currentUser.Role == UserRole.Student;
            }

            if (assistant != null)
            {
                assistant.Visible = currentUser.Role == UserRole.Assistant;
            }

            if (professor != null)
            {
                professor.Visible = currentUser.Role == UserRole.Professor;
            }
        }
    }
}
