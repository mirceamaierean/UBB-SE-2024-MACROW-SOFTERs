using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private int userId;
        private int chatId;
        private readonly IService service;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string chatTitle;
        public string ChatTitle
        {
            get => chatTitle;
            private set
            {
                if (chatTitle != value)
                {
                    chatTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        private string chatPictureUrl;
        public string ChatPictureUrl
        {
            get => chatPictureUrl;
            private set
            {
                if (value != chatPictureUrl)
                {
                    chatPictureUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MessageModel> Messages { get; private set; }

        public ChatPageViewModel(Service service, int userId)
        {
            this.service = service;
            this.userId = userId;
            Messages = new ObservableCollection<MessageModel>();
        }

        public void SetChatId(int chatId) // This is called from the ChatPage whenever the chatId is changed there.
        {
            this.chatId = chatId;
            ChatTitle = service.GetChatSummary(userId, chatId).PaticipantsNames;
            ChatPictureUrl = service.GetChatSummary(userId, chatId).PhotoUrl;
            // ChatPictureUrl = @"https://ironvalley.netlify.app/LOGOIV.png";
            RefreshChatMessages();
        }

        private void RefreshChatMessages() // Refresh the list with the messages based on the chat id.
        {
            // Clear the list with the old messages and add the ones from returned by the service.
            Messages.Clear();
            foreach (MessageModel messageModel in service.GetChatMessageModels(chatId, userId))
            {
                Messages.Add(messageModel);
            }
        }

        public void AddTextMessageToChat(string text)
        {
            service.AddTextMessageToChat(chatId, userId, text);
            RefreshChatMessages();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
