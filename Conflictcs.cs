using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Conflictcs
    {
        public Request existingRequest {  get; set; }
        public Request newRequest {  get; set; }
        public string message {  get; set; }

        public Conflictcs(Request _existingRequest, Request _newRequest) 
        {
            existingRequest = _existingRequest;
            newRequest = _newRequest;
            message = $"Накладка по часу! Для обладнання: '{newRequest.Resourse.NAME}' не можна вибрати час {newRequest.Interval.Start:hh\\:mm} - {newRequest.Interval.End:hh\\:mm}";
        }
    }
}
