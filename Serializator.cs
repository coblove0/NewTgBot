using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewTgBot
{
    class Serializator
    {
        JsonSerializer serializer = new JsonSerializer();
        public void Selialize(ObservableCollection<ChatVM> Log)
        {
            using (StreamWriter sw = new StreamWriter(@"log.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Log);
            }
        }
    }
}
