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
        ChatroomsManagementService cms = new ChatroomsManagementService("http://localhost:5086");
        cms.CreateAsync();
        await this.Navigation.PushAsync(new OpenChatsWindow(cms));
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