using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using КурсоваРобота_Ксендзова_ПЗ27.Properties;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<Request> allRequest = schedule.GetAllRequest();

            List<Request> sortedRequest = new List<Request>();

            foreach (Request request in allRequest)
            {
                if(request.DayOfReservation.Date == date)
                {
                    sortedRequest.Add(request);
                }
            }

            for(int i = 0; i < sortedRequest.Count - 1; i++)
            {
                for(int j=i+1; j < sortedRequest.Count; j++)
                {
                    if (sortedRequest[j].Interval.Start < sortedRequest[i].Interval.Start)
                    {
                        Request temp = sortedRequest[i];
                        sortedRequest[i] = sortedRequest[j];
                        sortedRequest[j] = temp;
                    }
                }
            }

            return sortedRequest;
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
            List<Request> allRequest = schedule.GetAllRequest();

            foreach (Request request in allRequest)
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

            List<Request> allRequest = schedule.GetAllRequest()
                .Where(r => r.Resourse.ID == resId && r.DayOfReservation == date.Date)
                .OrderBy(r => r.Interval.Start)
                .ToList();

            TimeSpan currentTime = workDayStart;

            foreach (Request request in allRequest)
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

        public bool IsResourceAvailableForAtLeastOneHour(int resourceId, DateTime date)
        {
            TimeSpan requiredInterval = TimeSpan.FromHours(1);
            
            TimeInterval freeSlot = GetTimeInterval(resourceId, date, requiredInterval);
            
            return freeSlot != null;
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
            TimeInterval newInterval = new TimeInterval(startTime, endTime);

            Request newRequest = new Request(0, resourse, person, newInterval, typeOfWork, reservDate);

            Conflictcs conflicts = CheckForConflictcs(newRequest);

            if(conflicts != null)
            {
                var alternativeTime = GetNextTimeInterval(resourse.ID, reservDate, interval);

                if (alternativeTime != null) 
                {
                    string altTimeStr = $"{alternativeTime.Value.interval.Start:hh\\:mm} - {alternativeTime.Value.interval.End:hh\\:mm}";
                    string altDateStr = alternativeTime.Value.date.ToShortDateString();

                    return (false, $"Цей час зайнятий! Найближчий вільний час для обладнання '{resourse.NAME}': {altDateStr} з {altTimeStr}");
                }
                else
                {
                    return (false, "Цей час зайнятий, і на найближчі дні вільних вікон немає");
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
