using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class TimeInterval
    {
        [JsonIgnore]
        public TimeSpan Start { get; set; }

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
