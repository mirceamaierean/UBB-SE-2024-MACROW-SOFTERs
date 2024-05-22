namespace MauiApp1.Model
{
    public interface IRepository
    {
        Chat GetChat(int chatId);
        List<Chat> GetUserChats(int userId);
        List<User> GetChatParticipants(int chatId);
        List<Message> GetChatMessages(int chatId);
        void AddMessage(Message message);
        Message GetChatLastMessage(int chatId);
        void AddMessageToChat(int chatId, Message message);
    }
}