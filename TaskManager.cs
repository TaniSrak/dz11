using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dz11
{
    internal class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks =new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(Guid taskId)
        {
            tasks.RemoveAll(t => t.Id == taskId);
        }

        public void UpdateTask(Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.Priority = updatedTask.Priority;
            }
        }

        public IEnumerable<Task> FilterTasksByPriority(int priority)
        {
            return tasks.Where(t => t.Priority == priority);
        }

        public IEnumerable<Task> FilterTasksByDueDate(DateTime dueDate)
        {
            return tasks.Where(t => t.DueDate.Date == dueDate.Date);
        }

        public IEnumerable<Task> SortTasksByDueDate()
        {
            return tasks.OrderBy(t => t.DueDate);
        }

        public IEnumerable<Task> SortTasksByPriority()
        {
            return tasks.OrderBy(t => t.Priority);
        }

        public IEnumerable<IGrouping<int, Task>> GroupTasksByPriority()
        {
            return tasks.GroupBy(t => t.Priority);
        }

    }
}
