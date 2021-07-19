using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTgBot
{
    class MessageLog
    {
        public string Time { get; set; }

        public long Id { get; set; }

        public string Msg { get; set; }

        public string FirstName { get; set; }

        public System.Windows.Media.Imaging.BitmapImage Photo { get; set; }

        public MessageLog() { }

        public MessageLog(string Time, string Msg, string FirstName, long Id)
        {
            this.Time = Time;
            this.Msg = Msg;
            this.FirstName = FirstName;
            this.Id = Id;
        }

        public MessageLog(string Time, System.Windows.Media.Imaging.BitmapImage Photo, string FirstName, long Id)
        {
            this.Time = Time;
            this.Photo = Photo;
            this.FirstName = FirstName;
            this.Id = Id;
        }
    }
}
