// <copyright file="ChatroomsManagementService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.ChatroomsManagement
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Runtime.CompilerServices;
    using RandomChatSrc.Models;

    /// <summary>
    /// Service for managing chatrooms.
    /// </summary>
    public class ChatroomsManagementService : IChatroomsManagementService
    {
        private readonly HttpClient httpClient;

        public List<Chat> ActiveChats { get; private set; }

        public ChatroomsManagementService(string baseAddress)
        {
            this.httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            ActiveChats = new List<Chat>();
        }

        public async void CreateAsync()
        {
            this.ActiveChats = await this.LoadActiveChatsAsync();
        }

        public Chat CreateChat()
        {
            Chat newChat = new Chat(new List<Message>(), string.Empty); // Adjust constructor parameters as needed
            ActiveChats.Add(newChat);
            return newChat;
        }

        public void DeleteChat(Guid id)
        {
            ActiveChats.RemoveAll(chat => chat.Id == id);
        }

        public Chat GetChat()
        {
            Random random = new Random();
            int index = random.Next(ActiveChats.Count);
            return ActiveChats[index];
        }

        public Chat GetChatById(Guid id)
        {
            return ActiveChats.FirstOrDefault(chat => chat.Id == id);
        }

        public List<Chat> GetAllChats()
        {
            return ActiveChats;
        }

        private async Task<List<Chat>> LoadActiveChatsAsync()
        {
            try
            {
                var chats = await httpClient.GetFromJsonAsync<List<Chat>>("/api/Chat");
                if (chats == null)
                {
                    throw new Exception("Chats list is empty");
                }
                return chats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching chats", ex);
            }
        }
    }
}