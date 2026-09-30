using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public enum UserRole
    {
        Student = 1,
        Assistant = 2,
        Professor = 3
    }
    internal class Person
    {
        private int idPerson;
        private string name;
        private UserRole role;

        public Person() { }
        public Person(int _idPerson, string _name, UserRole _role)
        {
            idPerson = _idPerson;
            name = _name;
            role = _role;
        }

        [Key]
        public int IdPerson
        { 
            get { return idPerson; }
            set { idPerson = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public UserRole Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
