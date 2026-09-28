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
        private bool isAvailable;

        public Resourse() { }
        public Resourse(int _id, string _name, bool _isAvailable)
        {
            id = _id;
            name = _name;
            isAvailable = _isAvailable;
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

        public bool ISAVAILABLE
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
    
    }
}
