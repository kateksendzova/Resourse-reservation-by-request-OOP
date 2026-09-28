using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    internal class Schedule
    {
        private List<Request> schedule = new List<Request>();


        public void SaveToJson(string filePath = "schedule_data.json")
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(schedule, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void LoadFromJson(string filePath = "schedule_data.json")
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var loaded = JsonSerializer.Deserialize<List<Request>>(jsonString);
                if (loaded != null)
                { 
                    schedule = loaded;
                }
            }
        }

        public List<Request> GetAllRequest() => schedule;
        public void AddRequest(Request _request)
        {
            if(_request != null)
            {
                schedule.Add(_request);
            }
        }

        public void RemoveRequest(Request _request)
        {
            if (_request != null)
            {
                schedule.Remove(_request);
            }
        }


    }
}
