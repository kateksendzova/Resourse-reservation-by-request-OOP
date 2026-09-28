using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Person
    {
        private int idPerson;
        private string name;
        private string role;

        public Person(int _idPerson, string _name, string _role)
        {
            idPerson = _idPerson;
            name = _name;
            role = _role;
        }

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

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
