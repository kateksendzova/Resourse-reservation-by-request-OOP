using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    [Owned]
    internal class TimeInterval
    {
        [NotMapped]
        public TimeSpan Start { get; set; }

        [NotMapped]
        public TimeSpan End { get; set; }

        public string StartString
        {
            get => Start.ToString(@"hh\:mm");
            set => Start = TimeSpan.Parse(value);
        }

        public string EndString
        {
            get => End.ToString(@"hh\:mm");
            set => End = TimeSpan.Parse(value);
        }

        public TimeInterval() { }

        public TimeInterval(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }
    }
}
