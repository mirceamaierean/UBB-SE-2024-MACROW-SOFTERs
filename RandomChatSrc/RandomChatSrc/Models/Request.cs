// <copyright file="Request.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a request sent by a User to another User.
    /// Contains the request's identifier, the sender's and receiver's identifiers and the request's path.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The unique identifier of the request.</param>
        /// <param name="senderUserId">The unique identifier of the sender.</param>
        /// <param name="receiverUserId">The unique identifier of the receiver.</param>
        /// <param name="requestPath">The path to the request.</param>
        public Request(int senderId, int receiverId)
        {
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the request.
        /// </summary>
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}