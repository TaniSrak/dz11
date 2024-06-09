using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dz11
{
    internal class XmlTaskSerializer
    {
        public void SaveTasksToFile(List<Task> tasks, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, tasks);
            }
        }

        public List<Task> LoadTasksFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (List<Task>)serializer.Deserialize(reader);
            }
        }
    }
}
