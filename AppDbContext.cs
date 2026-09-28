using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Resourse> Resourses { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
