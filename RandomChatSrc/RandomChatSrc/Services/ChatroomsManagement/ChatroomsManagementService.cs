// <copyright file="ChatroomsManagementService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.ChatroomsManagement
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Service for managing chatrooms.
    /// </summary>
    public class ChatroomsManagementService : IChatroomsManagementService
    {
        // schimba asta de fiecare data cand dai pull asta e nivelul
        private string textChatsDirectoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatroomsManagementService"/> class.
        /// </summary>
        public ChatroomsManagementService(string filePath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\ChatRepo\\")
        {
            this.ActiveChats = new List<Chat>();
            this.textChatsDirectoryPath = filePath;
            this.LoadActiveChats();
        }

        private List<Chat> ActiveChats { get; set; }

        /// <summary>
        /// Creates a new chatroom with a specified size.
        /// </summary>
        /// <param name="size">The size of the chatroom.</param>
        /// <returns>The created chatroom.</returns>
        public Chat CreateChat()
        {
            var newChat = new Chat(new List<Message>(), this.textChatsDirectoryPath);
            this.ActiveChats.Add(newChat);
            return newChat;
        }

        /// <summary>
        /// Deletes a chatroom with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom to delete.</param>
        public void DeleteChat(Guid id)
        {
            foreach (Chat chat in this.ActiveChats.ToList())
            {
                if (chat.Id == id)
                {
                    this.ActiveChats.Remove(chat);
                    return;
                }
            }
        }

        /// <summary>
        /// Retrieves a random chatroom from the active chatrooms list.
        /// </summary>
        /// <returns>A random chatroom.</returns>
        public Chat GetChat()
        {
            Random random = new Random();
            int index = random.Next(this.ActiveChats.Count);
            return this.ActiveChats[index];
        }

        /// <summary>
        /// Retrieves a chatroom by its ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom.</param>
        /// <returns>The chatroom with the specified ID.</returns>
        public Chat GetChatById(Guid id)
        {
            Chat found = null;
            foreach (Chat chat in this.ActiveChats)
            {
                if (chat.Id == id)
                {
                    found = chat;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Retrieves all active chatrooms.
        /// </summary>
        /// <returns>A list of all active chatrooms.</returns>
        public List<Chat> GetAllChats()
        {
            return this.ActiveChats;
        }

        private string GetIdFromPath(string folderPath)
        {
            string id = string.Empty;
            for (int i = folderPath.Length - 1; i >= 0 && folderPath[i] != '\\'; --i)
            {
                id += folderPath[i];
            }

            return new string(id.Reverse().ToArray());
        }

        private void LoadActiveChats()
        {
            foreach (string chatFolderPath in Directory.GetDirectories(this.textChatsDirectoryPath))
            {
                string foundId = this.GetIdFromPath(chatFolderPath);
                Chat newChat = new Chat(new List<Message>(), this.textChatsDirectoryPath, foundId);
                this.ActiveChats.Add(newChat);
            }
        }
    }
}