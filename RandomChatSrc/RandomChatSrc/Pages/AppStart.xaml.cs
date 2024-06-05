using RandomChatSrc.Services.ChatroomsManagement;
using MauiApp1;
using MauiApp1.ViewModel;
using MauiApp1.Model;
namespace RandomChatSrc.Pages;

public partial class AppStart : ContentPage
{
    private readonly Models.User loggedInUser;
    private Models.User user;

    public AppStart(User user)
    {
        InitializeComponent();
        loggedInUser = user;
    }

    public AppStart(Models.User user)
    {
        this.user = user;
    }

    private async void RandomChats_Clicked(object sender, EventArgs e)
    {
        ChatroomsManagementService cms = new ChatroomsManagementService(loggedInUser, "http://localhost:7076");
        await cms.CreateAsync();
        await this.Navigation.PushAsync(new OpenChatsWindow(cms, loggedInUser));
    }

    private void Chats_Clicked(object sender, EventArgs e)
    {
        int userId = int.Parse(loggedInUser.Id);
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:7076/");
        ApiService apiService = new ApiService(httpClient);

        Service service = new Service(apiService);
        MainPageViewModel mainPageViewModel = new MainPageViewModel(service, userId);
        this.Navigation.PushAsync(new ChatAppMainPage(mainPageViewModel));
    }
}
