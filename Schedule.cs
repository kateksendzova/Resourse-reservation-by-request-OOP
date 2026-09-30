using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Schedule
    {
        public void InitializeDataBase()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                if (!context.Resourses.Any())
                {
                    var defaultResourses = new List<Resourse>
                    {
                        new Resourse(1, "Осцилограф цифровий"),
                        new Resourse(2, "Ардуіну"),
                        new Resourse(3, "3D-принтер"),
                        new Resourse(4, "Спектрометр оптичний"),
                        new Resourse(5, "Паяльна станція термоповітряна"), 
                        new Resourse(6, "Генератор сигналів спеціальної форми"),
                        new Resourse(7, "Випробувальний стенд мікроконтролерів"), 
                        new Resourse(8, "Фрезерний верстат з ЧПК"),
                        new Resourse(9, "Тепловізор лабораторний"),
                        new Resourse(10, "Аналізатор спектра частот")
                    };

                    context.Resourses.AddRange(defaultResourses);
                    context.SaveChanges();
                }
            }
        }

        public List<Request> GetAllRequest()
        {
            using (var context = new AppDbContext())
            {
                return context.Requests
                    .Include(r => r.Person)
                    .Include(r => r.Resourse)
                    .ToList();
            }
        }

        public List<Resourse> GetAllResourse()
        {
            using (var context = new AppDbContext())
            {
                return context.Resourses.ToList();
            }
        }

        public Person GetOrCreatePerson(string name, UserRole role)
        {
            using (var context = new AppDbContext())
            {
                var person = context.Persons.FirstOrDefault(p => p.Name == name && p.Role == role);

                if (person == null)
                {
                    person = new Person(0, name, role);
                    context.Persons.Add(person);
                    context.SaveChanges();
                }

                return person;
            }
        }

        public void AddRequestToBD(Request newRequest)
        {
            using (var context = new AppDbContext())
            {
                context.Resourses.Attach(newRequest.Resourse);
                context.Persons.Attach(newRequest.Person);

                context.Requests.Add(newRequest);
                context.SaveChanges();
            }
        }

        public void DeleteRequestFromBD(int reqId)
        {
            using (var context = new AppDbContext())
            {
                var requestToDel = context.Requests.Find(reqId);
                if (requestToDel != null) 
                {
                    context.Requests.Remove(requestToDel);
                    context.SaveChanges();
                }
            }
        }
    }
}
