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
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:5086/");
        ApiService apiService = new ApiService(httpClient);

        Service service = new Service(apiService);
        MainPageViewModel mainPageViewModel = new MainPageViewModel(service, userId);
        this.Navigation.PushAsync(new ChatAppMainPage(mainPageViewModel));
    }
}