using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Request
	{
		private Resourse resourse;
		private TimeInterval interval;
		private string typeOfWork;
		public DateTime creationTime;
        private string nameOfPerson;
        private string role;
        private DateTime dayOfReservation;
        public Request()
        {
        }
        public Request(Resourse _resourse, TimeInterval _interval, string _typeOfWork, string _name, string _role, DateTime _dayOfReservation)
		{
            resourse=_resourse;
			interval=_interval;
			typeOfWork = _typeOfWork;
			creationTime = DateTime.Now;
			nameOfPerson = _name;
			role = _role;
			dayOfReservation = _dayOfReservation;
        }

		public Resourse Resourse 
		{ 
			get { return resourse; }
			set { resourse = value; }
		}
		public TimeInterval Interval
		{
			get { return interval; }
			set { interval = value; }
		}
		public string TypeOfWork
		{ 
			get { return typeOfWork; }
			set { typeOfWork = value; }
		}
		public DateTime CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }
        public string NameOfPerson
        {
            get { return nameOfPerson; }
            set { nameOfPerson = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

		public DateTime DayOfReservation
		{
			get { return dayOfReservation; }
			set { dayOfReservation = value; }
		}
    }
}
