using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    public class ChatSummary
    {
        public string PaticipantsNames { get; }
        public string PhotoUrl { get; }
        public string LastMessage { get; }
        public string LastMessageTime { get; }
        public string LastMessageStatus { get; }

        public int ChatId { get; }

        public ChatSummary(string participantsNames, string photoUrl, string lastMessage, string lastMessageTime, string lastMessageStatus, int chatId)
        {
            PaticipantsNames = participantsNames;
            PhotoUrl = photoUrl;
            LastMessage = lastMessage;
            LastMessageTime = lastMessageTime;
            LastMessageStatus = lastMessageStatus;
            ChatId = chatId;
        }
    }
}
