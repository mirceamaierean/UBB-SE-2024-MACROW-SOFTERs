using RandomChatSrc.Services.ChatroomsManagement;
using MauiApp1;
using MauiApp1.ViewModel;
using MauiApp1.Model;
namespace RandomChatSrc.Pages;

public partial class AppStart : ContentPage
{
	public AppStart()
	{
		InitializeComponent();
	}

    private async void RandomChats_Clicked(object sender, EventArgs e)
    {
        Models.User testUser = new Models.User(1, "hori273", string.Empty);
        ChatroomsManagementService cms = new ChatroomsManagementService(testUser, "http://localhost:5086");
        await cms.CreateAsync();
        await this.Navigation.PushAsync(new OpenChatsWindow(cms, testUser));
    }

    private void Chats_Clicked(object sender, EventArgs e)
    {
        int userId = 1;
        string usersFilePath = "C:\\GitHub_Repos\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\MauiApp1\\Data\\users.xml";
        string chatsFilePath = "C:\\GitHub_Repos\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\MauiApp1\\Data\\chats.xml";
        IRepository repository = new UsersChatsRepository(usersFilePath, chatsFilePath);
        Service service = new Service(repository);
        MainPageViewModel mainPageViewModel = new MainPageViewModel(service, userId);
        this.Navigation.PushAsync(new ChatAppMainPage(mainPageViewModel));
    }
}