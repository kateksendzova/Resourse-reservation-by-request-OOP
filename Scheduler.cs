using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public (bool IsAvailable, string Message) TryAddRequest(Resourse resourse, Person person, DateTime reservDate, TimeSpan startTime, TimeSpan interval, TypeOfWork typeOfWork)
        {
            TimeSpan endTime = startTime + interval;
            TimeInterval newInterval = new TimeInterval(startTime, endTime);
            Request newRequest = new Request(0, resourse, person, newInterval, typeOfWork, reservDate);

            BatchResult batchResult = PlanBatch(new List<Request> { newRequest }, new PriorityStrategy());

            if (batchResult.Accepted.Any())
            {
                return (true, "Запит успішно додано до розкладу!");
            }
            else
            {
                string rejectionReason = batchResult.Rejected.FirstOrDefault() ?? "Цей час зайнятий.";
                return (false, rejectionReason);
            }
        }

        public Request CheckForPersonConflict(Person person, DateTime reservDate, TimeSpan startTime, TimeSpan interval)
        {
            TimeSpan endTime = startTime + interval;
            TimeInterval newInterval = new TimeInterval(startTime, endTime);

            List<Request> requestsUser = GetRequestsByPerson(person.Name, person.Role);

            foreach (Request request in requestsUser) 
            {
                if(request.DayOfReservation.Date == reservDate.Date)
                {
                    if(request.Interval.Start < newInterval.End && newInterval.Start < request.Interval.End)
                    {
                        return request;
                    }
                }
            }

            return null;
        }

        public BatchResult PlanBatch(IEnumerable<Request> candidates, SchedulingStrategy strategy)
        {
            var result = new BatchResult();

            List<string> acceptedLines = new List<string>();
            List<string> rejectedLines = new List<string>();

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            foreach (Request r in strategy.Order(candidates))
            {
                Conflictcs conflict = CheckForConflictcs(r);

                if (conflict == null)
                {
                    schedule.AddRequestToBD(r);
                    result.Accepted.Add(r);

                    string acceptedInfo = $"[{timestamp}] [Стратегія: {strategy.Name}] " +
                                         $"Користувач: {r.Person.Name} ({r.Person.Role}) | " +
                                         $"Обладнання: {r.Resourse.NAME} | " +
                                         $"Дата: {r.DayOfReservation:dd.MM.yyyy} | " +
                                         $"Час: {r.Interval.StartString}-{r.Interval.EndString}";

                    acceptedLines.Add(acceptedInfo);
                }
                else
                {
                    var alt = GetNextTimeInterval(r.Resourse.ID, r.DayOfReservation, r.Interval.End - r.Interval.Start);
                    string hint = alt == null
                        ? "Вільних вікон на найближчі дні немає"
                        : $"Найближчий вільний час: {alt.Value.date:dd.MM.yyyy} {alt.Value.interval.StartString}-{alt.Value.interval.EndString}";

                    string rejectionMsg = $"Для обладнання {r.Resourse.NAME} вікно {r.Interval.StartString}-{r.Interval.EndString} зайнято! {hint}";
                    result.Rejected.Add(rejectionMsg);

                    string rejectedInfo = $"[{timestamp}] [Стратегія: {strategy.Name}] " +
                                         $"Користувач: {r.Person.Name} | " +
                                         $"Обладнання: {r.Resourse.NAME} | " +
                                         $"Запитуваний час: {r.DayOfReservation:dd.MM.yyyy} {r.Interval.StartString}-{r.Interval.EndString} | " +
                                         $"Причина: {hint}";

                    rejectedLines.Add(rejectedInfo);
                }
            }

            try
            {
                if (acceptedLines.Count > 0)
                {
                    System.IO.File.AppendAllLines("accepted_requests.txt", acceptedLines);
                }

                if (rejectedLines.Count > 0)
                {
                    System.IO.File.AppendAllLines("rejected_requests.txt", rejectedLines);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Помилка запису у файли: {ex.Message}");
            }

            return result;
        }

        public void DeleteRequest(int reqId)
        {
            schedule.DeleteRequestFromBD(reqId);
        }
    }
}
