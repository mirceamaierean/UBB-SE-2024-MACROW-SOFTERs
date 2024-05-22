using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using MauiApp1.ViewModel;

namespace MauiApp1.Model
{
    public class Service : IService
    {
        private ApiService apiService;

        public Service(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public List<ChatSummary> GetUserChatSummaries(int userId, string participantName)
        {
            // Initialize the result.
            List<ChatSummary> result = new List<ChatSummary>();

            // Get all the user's chats and sort them based on the last message time.
            List<Chat> chats = apiService.GetUserChats(userId);
            chats = SortChatsByLastMessageTime(chats);

            // Filter the chats based on the given name.
            chats = FilterChatsByName(chats, participantName);

            // Go through all the chats.
            foreach (Chat chat in chats)
            {
                ChatSummary chatSummary = GetChatSummary(userId, chat.Id);
                if (chatSummary != null)
                {
                    result.Add(chatSummary);
                }
            }

            return result;
        }

        public ChatSummary GetChatSummary(int userId, int chatId)
        {
            // Get the chat by ID.
            Chat chat = apiService.GetChat(chatId);
            if (chat == null)
            {
                return null;
            }

            // Get a list of all the chat participants.
            List<User> chatUsers = apiService.GetChatParticipants(chat.Id);

            // Remove the current user.
            chatUsers.RemoveAll(u => u.Id == userId);

            // Concatenate participant names.
            string participantNames = string.Join(", ", chatUsers.Select(u => u.Name));

            // Get the profile picture of the first participant that is not the current user.
            string profilePhotoUrl = chatUsers.FirstOrDefault()?.ProfilePhotoUrl ?? string.Empty;

            // Get the last message.
            Message lastChatMessage = apiService.GetChatLastMessage(chat.Id);
            string messageContent = lastChatMessage.GetMessageContent();

            // Prepend "You: " if the current user is the sender.
            if (lastChatMessage.UserId == userId)
            {
                messageContent = "You: " + messageContent;
            }

            // Truncate message content if it exceeds 20 characters.
            if (messageContent.Length > 20)
            {
                messageContent = messageContent.Substring(0, 17) + "...";
            }

            // Format the timestamp.
            DateTime dateTime = lastChatMessage.SentTime;
            string time = $"{dateTime.Day.ToStringWithLeadingZero()}.{dateTime.Month.ToStringWithLeadingZero()}\n{dateTime.Hour.ToStringWithLeadingZero()}:{dateTime.Minute.ToStringWithLeadingZero()}";

            // Create and return a new ChatSummary object.
            ChatSummary chatSummary = new ChatSummary(participantNames, profilePhotoUrl, messageContent, time, lastChatMessage.Status, chat.Id);
            return chatSummary;
        }

        public List<MessageModel> GetChatMessageModels(int chatId, int userId)
        {
            // Initialize the result.
            List<MessageModel> result = new List<MessageModel>();

            // Get all the chat messages from the database.
            List<TextMessage> messages = apiService.GetChatMessages(chatId);
            foreach (Message message in messages)
            {
                if (message is Message)
                {
                    MessageModel model = new MessageModel(type: "text", incoming: message.UserId != userId, text: message.GetMessageContent());
                    result.Add(model);
                }
            }

            return result;
        }

        private List<Chat> FilterChatsByName(List<Chat> chats, string participantName)
        {
            if (string.IsNullOrWhiteSpace(participantName))
            {
                return chats;
            }

            participantName = participantName.ToLower();
            List<Chat> filteredChats = new List<Chat>();

            foreach (Chat chat in chats)
            {
                List<User> chatUsers = apiService.GetChatParticipants(chat.Id);

                // Check if any participant's name matches the given participant name.
                if (chatUsers.Any(user => user.Name.ToLower().Contains(participantName)))
                {
                    filteredChats.Add(chat);
                }
            }

            return filteredChats;
        }

        private List<Chat> SortChatsByLastMessageTime(List<Chat> chats)
        {
            return chats.OrderByDescending(async chat => apiService.GetChatLastMessage(chat.Id).SentTime).ToList();
        }

        public void AddTextMessageToChat(int chatId, int senderId, string text)
        {
            apiService.AddMessageToChat(chatId, new TextMessage(0, chatId, senderId, DateTime.Now, string.Empty, text));
        }
    }
}
