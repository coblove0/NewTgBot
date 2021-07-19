using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Telegram.Bot;
using System.IO;
using Telegram.Bot.Args;
using System.Windows.Threading;
using System.Windows;

namespace NewTgBot
{
    public class ChatListVM : INotifyPropertyChanged
    {
        private TelegramBotClient bot;
        Serializator serializator = new Serializator();
        public ObservableCollection<ChatVM> Chats { get; set; } = new ObservableCollection<ChatVM>();
        private ChatVM selectedChat;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public ChatVM SelectedChat
        {
            get
            {
                return this.selectedChat;
            }

            set
            {
                this.selectedChat = value;
                OnPropertyChanged("SelectedChat"); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
            }
        }

        public ChatListVM()
        {

            this.bot = new TelegramBotClient(File.ReadAllText(@"D:\temp\token.txt"));

            bot.OnMessage += MessageListener;

            bot.StartReceiving();
        }

        private void MessageListener(object sender, MessageEventArgs e)
        {
            if (!Chats.Any(c => c.UserId == e.Message.Chat.Id))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Chats.Add(new ChatVM(e.Message.Chat.Id, e.Message.Chat.Username, bot));
                });
            }
            var chat = Chats.First(c => c.UserId == e.Message.Chat.Id);
            Application.Current.Dispatcher.Invoke(() =>
            {
                chat.Messages.Add(new MessageModel(DateTime.Now.ToString(), e.Message.Chat.Id, e.Message.Chat.FirstName, e.Message.Text));
            });
            //serializator.Selialize(Chats);
        }
    }
}
