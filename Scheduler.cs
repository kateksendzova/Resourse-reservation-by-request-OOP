using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Scheduler
    {
        private Schedule schedule;

        public Scheduler() 
        {
            schedule = new Schedule();
            schedule.InitializeDataBase();
        }

        public List<Request> GetRequests()
        {
            return schedule.GetAllRequest();
        }

        public List<Resourse> GetResourses() 
        {
            return schedule.GetAllResourse();
        }


    }
}
