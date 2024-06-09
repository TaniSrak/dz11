using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11
{
    internal class CsvTaskSerializer
    {
        public void SaveTasksToFile(List<Task> tasks, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,Title,Description,DueDate,Priority");
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id},{task.Title},{task.Description},{task.DueDate},{task.Priority}");
                }
            }
        }

        public List<Task> LoadTasksFromFile(string filePath)
        {
            var tasks = new List<Task>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    var task = new Task
                    {
                        Id = Guid.Parse(values[0]),
                        Title = values[1],
                        Description = values[2],
                        DueDate = DateTime.Parse(values[3]),
                        Priority = int.Parse(values[4])
                    };
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }
}
