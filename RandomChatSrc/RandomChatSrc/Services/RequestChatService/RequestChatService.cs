// <copyright file="RequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc.Services.RequestChatService
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Repositories;
    using System.Net.Http.Json;

    /// <summary>
    /// Service responsible for managing chat requests.
    /// </summary>
    public class RequestChatService
    {
        private readonly User user;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestChatService"/> class.
        /// </summary>
        /// <param name="requestsChatRepo">The chat request repository.</param>
        /// <param name="globalServices">The global services.</param>
        public RequestChatService(User user, HttpClient httpClient)
        {
            this.user = user;
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of requests.</returns>
        public async Task<List<Request>> GetAllRequests()
        {
            try
            {
                var requests = await httpClient.GetFromJsonAsync<List<Request>>("/api/Request");
                if (requests == null)
                {
                    throw new Exception("There are no requests.");
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching requests", ex);
            }
        }

        public async Task<List<Request>> GetRequestsByUserAsync()
        {
            try
            {
                var requests = await httpClient.GetFromJsonAsync<List<Request>>("/api/Request");
                if (requests == null)
                {
                    throw new Exception("There are no requests.");
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching requests", ex);
            }
        }
        public async Task<List<Request>> GetSentRequestsByUserAsync()
        {
            try
            {
                var requests = await httpClient.GetFromJsonAsync<List<Request>>("/api/Request/SentByUser/" + user.Id);
                if (requests == null)
                {
                    throw new Exception("There are no requests sent by this user.");
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching requests", ex);
            }
        }

        public async Task<List<Request>> GetReceivedRequestsByUserAsync()
        {
            try
            {
                var requests = await httpClient.GetFromJsonAsync<List<Request>>("/api/Request/ReceivedByUser/" + user.Id);
                if (requests == null)
                {
                    throw new Exception("There are no requests received by this user.");
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching requests", ex);
            }
        }
        public async Task<User> GetUserFromIdAsync(int userId)
        {
            try
            {
                var user = await httpClient.GetFromJsonAsync<User>("/api/User/" + userId);
                if (user == null)
                {
                    throw new Exception("No user with this id was found.");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user", ex);
            }
        }

        /// <summary>
        /// Adds a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AddRequest(Guid senderId, Guid receiverId)
        {
            // this.chatRequestRepository.AddRequest(senderId, receiverId);
        }

        /// <summary>
        /// Declines a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void DeclineRequest(Guid senderId, Guid receiverId)
        {
            // this.chatRequestRepository.RemoveRequest(senderId, receiverId);
        }

        /// <summary>
        /// Accepts a chat request and creates a new text chat.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AcceptRequest(Guid senderId, Guid receiverId)
        {
            // Chat newChat = this.globalServices.ChatroomsManagementService.CreateChat();
            // newChat.AddParticipant(this.globalServices.UserRepository.GetUserById(senderId));
            // newChat.AddParticipant(this.globalServices.UserRepository.GetUserById(receiverId));
            // this.chatRequestRepository.RemoveRequest(senderId, receiverId);
        }
    }
}
