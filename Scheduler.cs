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

        public Scheduler(Schedule _schedule)
        {
            this.schedule = _schedule;
        }

        public Conflictcs CheckConflict(Request newRequest)
        {
            foreach (var existing in schedule.GetAllRequest()
                .Where(r=>r.DayOfReservation == newRequest.DayOfReservation))
            {
                if (existing.Resourse.ID == newRequest.Resourse.ID)
                {
                    if (existing.Interval.Start < newRequest.Interval.End && newRequest.Interval.Start < existing.Interval.End)
                    {
                        return new Conflictcs(existing, newRequest);
                    }
                }
            }

            return null;
        }

        public TimeInterval FindAvailableSpot(int resursedId, DateTime data, TimeSpan duration)
        {
            TimeSpan startWorkDay = new TimeSpan(8, 0, 0);
            TimeSpan endWorkDay = new TimeSpan(19, 0, 0);

            var resourceRequest = schedule.GetAllRequest()
                .Where(r => r.Resourse.ID == resursedId && r.DayOfReservation.Date == data.Date)
                .OrderBy(r => r.Interval.Start)
                .ToList();

            TimeSpan currentTimePoint = startWorkDay;

            foreach (var resource in resourceRequest)
            {
                if(resource.Interval.Start - currentTimePoint >= duration)
                {
                    return new TimeInterval(currentTimePoint, currentTimePoint + duration);
                }

                if(resource.Interval.End > currentTimePoint)
                {
                    currentTimePoint= resource.Interval.End;
                }
            }

            if (endWorkDay - currentTimePoint >= duration)
            {
                return new TimeInterval(currentTimePoint, currentTimePoint + duration);
            }

            return null;
        }

        public (TimeInterval Interval, DateTime FoundDate)? FindNextAvailableSpotRecursive(int resourceId, DateTime startDate, TimeSpan duration, int maxDaysToCheck = 30)
        {
            for (int i = 0; i < maxDaysToCheck; i++)
            {
                DateTime currentCheckDate = startDate.AddDays(i);

                TimeInterval spot = FindAvailableSpot(resourceId, currentCheckDate, duration);

                if (spot != null)
                {
                    return (spot, currentCheckDate);
                }
            }


             return null;
        }
    }
}
