using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
	public enum TypeOfWork
	{
        IndependentWork = 1,
		LaboratoryWork = 2,
		DiplomaThesis = 3,
        ScientificExperiment = 4
    }
    internal class Request
	{
		private int idRequest;
		private Resourse resourse;
		private Person person;
		private TimeInterval interval;
		private TypeOfWork typeOfWork;
		public DateTime creationTime;
        private DateTime dayOfReservation;
        public Request()
        {
        }
        public Request(int _idRequest, Resourse _resourse, Person _person, TimeInterval _interval, TypeOfWork _typeOfWork, DateTime _dayOfReservation)
		{
			idRequest = _idRequest;
            resourse=_resourse;
			person = _person;
			interval=_interval;
			typeOfWork = _typeOfWork;
			creationTime = DateTime.Now;
			dayOfReservation = _dayOfReservation;
        }

		[Key]
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
		public Person Person
		{
			get { return person; }
			set { person = value; }
		}
		public TimeInterval Interval
		{
			get { return interval; }
			set { interval = value; }
		}
		public TypeOfWork TypeOfWork
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
