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
        // // Get the current application
        // var app = (MauiApp)Maui.MauiContext.GetRequiredService<IApplication>();
        //
        // // Get the Service and MainPageViewModel from the ServiceProvider
        // var service = app.Services.GetRequiredService<Service>();
        // var mainPageViewModel = app.Services.GetRequiredService<MainPageViewModel>();
        //
        // // Use the service and viewModel
        // this.Navigation.PushAsync(new ChatAppMainPage(mainPageViewModel));
    }
}