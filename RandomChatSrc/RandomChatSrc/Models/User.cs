// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a User in the chat application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name of the User.</param>
        /// <param name="interests">A list of the User's interests. If null, an empty list will be assigned.</param>
        public User(int id, string name, string profilePhotoUrl)
        {
            this.Id = id;
            this.Name = name;
            this.ProfilePhotoUrl = profilePhotoUrl;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the User.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the User.
        /// </summary>
        public string Name { get; set; }
        public string ProfilePhotoUrl { get; set; }
    }
}