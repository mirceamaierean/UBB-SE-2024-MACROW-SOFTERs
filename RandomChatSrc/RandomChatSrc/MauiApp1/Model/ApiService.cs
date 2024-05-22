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
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            Test();
        }

        private async void Test()
        {
            var response = await httpClient.GetAsync($"api/chat/getAllMessagesExample");
            response.EnsureSuccessStatusCode();
            var messages = await response.Content.ReadFromJsonAsync<List<TextMessage>>();
        }

        public List<Chat> GetUserChats(int userId)
        {
            var response = httpClient.GetAsync($"api/user/{userId}/chats").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<Chat>>().Result;
        }

        public Chat GetChat(int chatId)
        {
            var response = httpClient.GetAsync($"api/chat/{chatId}").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<Chat>().Result;
        }

        public List<User> GetChatParticipants(int chatId)
        {
            var response = httpClient.GetAsync($"api/chat/{chatId}/participants").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<User>>().Result;
        }

        public List<TextMessage> GetChatMessages(int chatId)
        {
            var response = httpClient.GetAsync($"api/chat/{chatId}/messages").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<List<TextMessage>>().Result;
        }

        public TextMessage GetChatLastMessage(int chatId)
        {
            var response = httpClient.GetAsync($"api/chat/{chatId}/lastmessage").Result;
            response.EnsureSuccessStatusCode();
            string str = response.Content.ReadAsStringAsync().Result;
            return response.Content.ReadFromJsonAsync<TextMessage>().Result;
        }

        public void AddMessageToChat(int chatId, TextMessage message)
        {
            var response = httpClient.PostAsJsonAsync($"api/chat/{chatId}/addmessage", message).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
