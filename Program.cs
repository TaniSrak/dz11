using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            // Добавление задач
            taskManager.AddTask(new Task { Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now.AddDays(1), Priority = 1 });
            taskManager.AddTask(new Task { Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now.AddDays(2), Priority = 2 });

            // Сохранение задач в XML
            XmlTaskSerializer xmlSerializer = new XmlTaskSerializer();
            xmlSerializer.SaveTasksToFile(taskManager.FilterTasksByPriority(1).ToList(), "tasks.xml");

            // Загрузка задач из XML
            List<Task> loadedTasksFromXml = xmlSerializer.LoadTasksFromFile("tasks.xml");

            // Сохранение задач в JSON
            JsonTaskSerializer jsonSerializer = new JsonTaskSerializer();
            jsonSerializer.SaveTasksToFile(taskManager.FilterTasksByPriority(1).ToList(), "tasks.json");

            // Загрузка задач из JSON
            List<Task> loadedTasksFromJson = jsonSerializer.LoadTasksFromFile("tasks.json");

            // Сохранение задач в CSV
            CsvTaskSerializer csvSerializer = new CsvTaskSerializer();
            csvSerializer.SaveTasksToFile(taskManager.FilterTasksByPriority(1).ToList(), "tasks.csv");

            // Загрузка задач из CSV
            List<Task> loadedTasksFromCsv = csvSerializer.LoadTasksFromFile("tasks.csv");

            // Фильтрация задач по приоритету
            var highPriorityTasks = taskManager.FilterTasksByPriority(1);

            // сортировка задач по дате завершения
            var sortedTasksByDueDate = taskManager.SortTasksByDueDate();

            // группировка задач по приоритету
            var groupedTasksByPriority = taskManager.GroupTasksByPriority();

        }
    }

    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
        }
    }
}
