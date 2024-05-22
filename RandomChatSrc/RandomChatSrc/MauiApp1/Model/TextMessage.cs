namespace MauiApp1.Model
{
    public class TextMessage : Message
    {
        public string Content { get; set; }

        public TextMessage(int id, int chatId, int userId, DateTime sentTime, string status, string content) : base(id, chatId, userId, sentTime, status)
        {
            this.Content = content;
        }

        public override string GetMessageContent()
        {
            return Content;
        }
    }
}
