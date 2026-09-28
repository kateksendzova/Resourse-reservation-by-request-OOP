using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Request
	{
		private int idRequest;
		private Resourse resourse;
		private TimeInterval interval;
		private string typeOfWork;
		public DateTime creationTime;
        private DateTime dayOfReservation;
        public Request()
        {
        }
        public Request(int _idRequest, Resourse _resourse, TimeInterval _interval, string _typeOfWork, DateTime _dayOfReservation)
		{
			idRequest = _idRequest;
            resourse=_resourse;
			interval=_interval;
			typeOfWork = _typeOfWork;
			creationTime = DateTime.Now;
			dayOfReservation = _dayOfReservation;
        }

		public int IdRequest
		{
			get { return idRequest; }
			set { idRequest = value; }
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
		public DateTime DayOfReservation
		{
			get { return dayOfReservation; }
			set { dayOfReservation = value; }
		}
    }
}
