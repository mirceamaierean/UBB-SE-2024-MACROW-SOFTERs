using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public abstract class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime SentTime { get; set; }
        public string Status { get; set; }

        public Message(int id, int chatId, int userId, DateTime sentTime, string status)
        {
            this.Id = id;
            this.ChatId = chatId;
            this.UserId = userId;
            this.SentTime = sentTime;
            this.Status = status;
        }

        public abstract string GetMessageContent();
    }
}
