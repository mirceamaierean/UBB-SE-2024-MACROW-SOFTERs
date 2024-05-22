// <copyright file="MessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.MessageService
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System;
    using RandomChatSrc.Models;

    /// <summary>
    /// Service for sending messages to a text chat.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly Chat chat;
        private readonly User user;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="textChat">The text chat to which messages will be sent.</param>
        /// <param name="userId">The ID of the user sending the messages.</param>
        public MessageService(Chat chat, User user, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.chat = chat;
            this.user = user;
        }

        /// <summary>
        /// Sends a message to the text chaSt.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public async Task SendMessage(string content)
        {
            try
            {
                Message message = new Message(content, user.Id, chat.Id, DateTime.Now, string.Empty);
                var sentMessage = await httpClient.PostAsJsonAsync("/api/Chat/" + chat.Id + "/addmessage", message);
                if (sentMessage == null)
                {
                    throw new Exception("The message could not be sent.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending the message", ex);
            }
        }

        /// <summary>
        /// Gets the text chat to which messages are sent.
        /// </summary>
        /// <returns>The text chat.</returns>
        public Chat GetChat()
        {
            return this.chat;
        }

        public async Task<List<Message>> GetMessagesAsync()
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
    }
}
