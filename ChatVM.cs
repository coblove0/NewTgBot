using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Telegram.Bot;
using System.IO;
using Newtonsoft.Json;

namespace NewTgBot
{
    public class ChatVM : INotifyPropertyChanged//, ICommand
    {

        private TelegramBotClient bot;

        Serializator serializator = new Serializator();

        public long UserId { get; set; }

        public string Name { get; set; }
        public ObservableCollection<MessageModel> Messages { get; } = new ObservableCollection<MessageModel>();
        [JsonIgnore]
        public Command SendMessage { get; }

        private string textMessage;
        [JsonIgnore]
        public string TextMessage
        {
            get
            {
                return this.textMessage;
            }

            set
            {
                this.textMessage = value;
                OnPropertyChanged("TextMessage"); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ChatVM(long userId, string name, TelegramBotClient bot)
        {
            UserId = userId;
            Name = name;
            this.SendMessage = new Command(this.CanExecute, this.Execute);
            this.bot = bot;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void Execute(object parameter)
        {
            bot.SendTextMessageAsync(UserId, TextMessage);
            var message = new MessageModel(DateTime.Now.ToString(), UserId, "bot", textMessage);
            Messages.Add(message);
            
            //serializator.Selialize(ChatListVM.Chats);
            TextMessage = "";
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(textMessage);
            //return true;
        }
    }
}
