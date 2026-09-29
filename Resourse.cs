using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Resourse
    {
        private int id;
        private string name;

        public Resourse() { }
        public Resourse(int _id, string _name)
        {
            id = _id;
            name = _name;
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string NAME
        {
            get { return  name; }
            set { name = value; }
        }   
    }
}
