using MauiApp1.ViewModel;

namespace MauiApp1.Model
{
    public interface IService
    {
        List<ChatSummary> GetUserChatSummaries(int userId, string participantName);
        ChatSummary GetChatSummary(int userId, int chatId);
        List<MessageModel> GetChatMessageModels(int chatId, int userId);
        void AddTextMessageToChat(int chatId, int senderId, string text);
    }
}