using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class UserChat
    {
        public int UserId { get; private set; }
        public int ChatId { get; private set; }

        public UserChat(int userId, int chatId)
        {
            this.UserId = userId;
            this.ChatId = chatId;
        }
    }
}