// <copyright file="ChatroomsManagementService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.ChatroomsManagement
{
    using System.Collections.Generic;
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
            this.ActiveChats = new List<Chat>();
        }

        public async Task CreateAsync()
        {
            this.ActiveChats = await this.LoadActiveChatsAsync();
        }

       /* public Chat CreateChat()
        {
            Chat newChat = new Chat(new List<Message>(), string.Empty); // Adjust constructor parameters as needed
            ActiveChats.Add(newChat);
            return newChat;
        } */

        public void DeleteChat(Guid id)
        {
            // ActiveChats.RemoveAll(chat => chat.Idd == id);
        }

        public Chat GetChat()
        {
            Random random = new Random();
            int index = random.Next(ActiveChats.Count);
            return ActiveChats[index];
        }

        public async Task<Chat> GetChatByIdAsync(int id)
        {
            try
            {
                var chat = await httpClient.GetFromJsonAsync<Chat>("/api/Chat/" + id);
                if (chat == null)
                {
                    throw new Exception("No chat was found.");
                }
                return chat;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching chat", ex);
            }
        }

        public List<Chat> GetAllChats()
        {
            return ActiveChats;
        }

        public Chat GetRandomChat()
        {
            Random rnd = new Random();
            int r = rnd.Next(ActiveChats.Count);
            return ActiveChats[r];
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

        public async Task<List<Message>> GetMessagesAsync(Chat chat)
        {
            try
            {
                var messages = await httpClient.GetFromJsonAsync<List<Message>>("/api/Chat/" + chat.Id + "/messages");
                if (messages == null)
                {
                    throw new Exception("There are no messages in this chat.");
                }
                return messages;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching messages", ex);
            }
        }

        public HttpClient GetHttpClient()
        {
            return httpClient;
        }
    }
}