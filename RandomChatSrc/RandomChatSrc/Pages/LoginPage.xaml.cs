using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using RandomChatSrc.Models;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly ChatroomsManagementService chatroomsManagementService;

        public LoginPage()
        {
            InitializeComponent();
            chatroomsManagementService = new ChatroomsManagementService(new User(string.Empty, string.Empty, string.Empty), "https://localhost:7076");
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Error", "Please enter a username.", "OK");
                return;
            }

            try
            {
                var user = await GetUserByUsernameAsync(username);
                if (user != null)
                {
                    await DisplayAlert("Success", $"Welcome {user.Name}", "OK");
                    // Navigate to the AppStart page and pass the logged-in user
                    await Navigation.PushAsync(new AppStart(user));
                }
                else
                {
                    await DisplayAlert("Error", "User not found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                var url = $"https://localhost:7076/api/User/Username/{username}";
                Console.WriteLine($"Fetching user data from: {url}");
                var user = await chatroomsManagementService.GetHttpClient().GetFromJsonAsync<User>(url);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }
                return user;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HttpRequestException: {httpEx.Message}");
                throw new Exception("Error fetching user", httpEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw new Exception("Error fetching user", ex);
            }
        }
    }
}
