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

        public Person GetOrCreatePerson(string name, UserRole role)
        {
            return schedule.GetOrCreatePerson(name, role);
        }

        public List<Request> GetRequestsByDate(DateTime date)
        {
            return schedule.GetAllRequest()
                .Where(r => r.DayOfReservation.Date == date.Date)
                .OrderBy(r => r.Interval.Start)
                .ToList();
        }

        public List<Request> GetRequestsByArrival()
        {
            return schedule.GetAllRequest()
                .OrderBy(r => r.CreationTime)
                .ToList();
        }

        public List<Request> GetRequestsByPerson(string name, UserRole role)
        {
            return schedule.GetAllRequest()
                .Where(r => r.Person.Name == name && r.Person.Role == role)
                .OrderBy(r => r.DayOfReservation)
                .ThenBy(r => r.Interval.Start)
                .ToList();
        }

        public Conflictcs CheckForConflictcs(Request newRequest)
        {
            var allRequest = schedule.GetAllRequest();

            foreach (var request in allRequest)
            {
                if (newRequest.Resourse.ID == request.Resourse.ID && newRequest.DayOfReservation == request.DayOfReservation)
                {
                    if (request.Interval.Start < newRequest.Interval.End && newRequest.Interval.Start < request.Interval.End)
                    {
                        return new Conflictcs(request, newRequest);
                    }
                }
            }

            return null;
        }

        public TimeInterval GetTimeInterval(int resId, DateTime date, TimeSpan interval)
        {
            TimeSpan workDayStart = new TimeSpan(8, 0, 0);
            TimeSpan workDayEnd = new TimeSpan(19, 0, 0);

            var allRequest = schedule.GetAllRequest()
                .Where(r => r.Resourse.ID == resId && r.DayOfReservation == date.Date)
                .OrderBy(r => r.Interval.Start)
                .ToList();

            TimeSpan currentTime = workDayStart;

            foreach (var request in allRequest)
            {
                if (request.Interval.Start - currentTime >= interval)
                {
                    return new TimeInterval(currentTime, currentTime + interval);
                }
                if (request.Interval.End > currentTime)
                {
                    currentTime = request.Interval.End;
                }
            }

            if (workDayEnd - currentTime >= interval)
            {
                return new TimeInterval(currentTime, currentTime + interval);
            }

            return null;
        }

        public (TimeInterval interval, DateTime date)? GetNextTimeInterval(int resId, DateTime date, TimeSpan interval, int maxDayToCheck = 30)
        {
            for (int i = 0; i < maxDayToCheck; i++)
            {
                DateTime checkDate = date.AddDays(i);
                TimeInterval spot = GetTimeInterval(resId, checkDate, interval);

                if (spot != null) 
                {
                    return (spot, checkDate);
                }             
            }

            return null;
        }

        public List<Request> GetListOfRequestSortedByPriority()
        {
            var requests = schedule.GetAllRequest();

            return requests
                .OrderByDescending(r => (int)r.Person.Role)
                .ThenBy(r=>(int)r.TypeOfWork)
                .ThenBy(r=>r.CreationTime)
                .ToList();
        }

        public (bool IsAvailable, string Message) TryAddRequest(Resourse resourse, Person person, DateTime reservDate, TimeSpan startTime, TimeSpan interval, TypeOfWork typeOfWork)
        {
            TimeSpan endTime = startTime + interval;
            var newInterval = new TimeInterval(startTime, endTime);

            var newRequest = new Request(0, resourse, person, newInterval, typeOfWork, reservDate);

            var conflicts = CheckForConflictcs(newRequest);

            if(conflicts != null)
            {
                var alternativeTime = GetNextTimeInterval(resourse.ID, reservDate, interval);

                if (alternativeTime != null) 
                {
                    string altTimeStr = $"{alternativeTime.Value.interval.Start:hh\\:mm} - {alternativeTime.Value.interval.End:hh\\:mm}";
                    string altDateStr = alternativeTime.Value.date.ToShortDateString();

                    return (false, $"Цей час зайнятий! Найближчий вільний час для обладнання '{resourse.NAME}': {altDateStr} з {altTimeStr}.");
                }
                else
                {
                    return (false, "Цей час зайнятий, і на найближчі дні вільних вікон немає.");
                }
            }

            schedule.AddRequestToBD(newRequest);
            return (true, "Запит успішно додано до розкладу!");
        }

        public void DeleteRequest(int reqId)
        {
            schedule.DeleteRequestFromBD(reqId);
        }
    }
}
