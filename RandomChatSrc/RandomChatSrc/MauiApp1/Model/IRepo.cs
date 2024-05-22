using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using MauiApp1.ViewModel;

namespace MauiApp1.Model
{
    public interface IRepo
    {
        List<Chat> GetUserChats(int userId);
        Chat GetChat(int chatId);
        List<User> GetChatParticipants(int chatId);
        List<TextMessage> GetChatMessages(int chatId);
        TextMessage GetChatLastMessage(int chatId);
        void AddMessageToChat(int chatId, TextMessage message);
    }
}
