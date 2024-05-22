// <copyright file="Chat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    using System.Text.Json.Serialization;
    using System.Xml.Linq;

    /// <summary>
    /// This class represents a text chat. It inherits from the Chat class,
    /// and contains a list of messages that have been sent in the chat.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class.
        /// </summary>
        /// <param name="messages">The initial list of messages in the chat.</param>
        /// <param name="chatFolderPath">The path to the folder where the chat is stored.</param>
        /// <param name="oldId">The ID of the chat, if it already exists.</param>
        /// <param name="maximumParticipants">The maximum number of participants allowed in the chat.</param>
        [JsonConstructor]
        public Chat(int id)
        {
            this.Id = id;
        }
        /// <summary>
        /// Gets the list of messages in the chat.
        /// </summary>
        
        public int Id { get; set; }
    }
}
