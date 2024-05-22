using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class Repository : IRepository
    {
        public Chat GetChat(int chatId)
        {
            // Generate mock chat data
            return new Chat(chatId);
        }

        public List<Chat> GetUserChats(int userId)
        {
            // Generate mock user chats
            return new List<Chat>
            {
                new Chat(1),
                new Chat(2),
                new Chat(3)
            };
        }

        public List<User> GetChatParticipants(int chatId)
        {
            if (chatId == 1)
            {
                return new List<User>
                {
                    new User(1, "User 1", "david.png"),
                    new User(2, "User 2", "razvan.png")
                };
            }
            else if (chatId == 2)
            {
                return new List<User>
                {
                    new User(1, "User 1", "david.png"),
                    new User(2, "User 3", "iulius.png")
                };
            }
            else
            {
                return new List<User>
                {
                    new User(1, "User 1", "david.png"),
                    new User(2, "User 4", "teo.png")
                };
            }
        }

        public List<Message> GetChatMessages(int chatId)
        {
            // Generate mock chat messages
            return new List<Message>
            {
                new TextMessage(1, chatId, 1, DateTime.Now, "Delivered", "Hello"),
                new TextMessage(2, chatId, 2, DateTime.Now.AddMinutes(5), "Read", "Hi there")
            };
        }

        public void AddMessage(Message message)
        {
            // Add message to the chat
            Console.WriteLine("Message added: " + message.GetMessageContent());
        }

        public Message GetChatLastMessage(int chatId)
        {
            // Get the last message from the chat
            return new TextMessage(2, chatId, 2, DateTime.Now.AddMinutes(5), "Read", "Hi there");
        }

        public void AddMessageToChat(int chatId, Message message)
        {
            // Add message to the specified chat
            Console.WriteLine("Message added to chat " + chatId + ": " + message.GetMessageContent());
        }
    }
}
