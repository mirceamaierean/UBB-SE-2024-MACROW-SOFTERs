using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RandomChatSrc_Tests.Models
{
    [TestClass]
    public class ChatUnitTests
    {
        private string mockChatFolderPath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\ChatRepoTesting\\";
        private Chat textChat = null!;

        [TestInitialize]
        public void Initialize()
        {
            // Create a mock chat folder
            Directory.CreateDirectory(mockChatFolderPath);

            // Create a new text chat
            textChat = new Chat(new List<Message>(), mockChatFolderPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Delete the mock chat folder
            if (Directory.Exists(mockChatFolderPath))
            {
                Directory.Delete(mockChatFolderPath, true);
            }
        }

        [TestMethod]
        public void Constructor_InitializesChat()
        {
            // Assert
            Assert.IsNotNull(textChat);
            Assert.IsNotNull(textChat.Id);
            Assert.AreEqual(0, textChat.Messages.Count);
            // Assert.AreEqual(mockChatFolderPath, textChat.MessagesFolderPath);
        }

        [TestMethod]
        public void AddMessage_AddsNewMessage()
        {
            // Arrange
            string senderId = "sender123";
            string messageContent = "Test message";

            // Act
            textChat.AddMessage(senderId, messageContent);

            // Assert
            Assert.AreEqual(1, textChat.Messages.Count);
            var addedMessage = textChat.Messages.First();
            Assert.AreEqual(senderId, addedMessage.SenderId);
            Assert.AreEqual(messageContent, addedMessage.Content);
        }

        [TestMethod]
        public void ExtractMessageIdFromPath_ReturnsCorrectId()
        {
            // Arrange
            var messageId = Guid.NewGuid();
            var messageFilePath = Path.Combine(mockChatFolderPath, $"message_{messageId}.xml");

            // Act
            var extractedId = textChat.ExtractMessageIdFromPath(messageFilePath);

            // Assert
            Assert.AreEqual(messageId, extractedId);
        }
    }
}
