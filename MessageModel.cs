using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewTgBot
{
    public class MessageModel : INotifyPropertyChanged
    {
        private string time;
        public string Time
        {
            get { return time; }
        }

        private long id;
        public long Id { get { return id; } }

        private string firstName;
        public string FirstName { get { return firstName; } }

        private string msg;
        public string Msg { get { return msg; } }

        public MessageModel(string time, long id, string firstName, string msg)
        {
            this.time = time;
            this.id = id;
            this.firstName = firstName;
            this.msg = msg;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
