using System.Collections.ObjectModel;
using MauiApp1.Model;
using MauiApp1.ViewModel;

namespace MauiApp1
{
    public partial class ChatAppMainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;

        public ChatAppMainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            this.BindingContext = viewModel;
        }

        public void OnSearchBarTextChanged(object sender, TextChangedEventArgs eventArguments)
        {
            string text = eventArguments.NewTextValue;
            viewModel.FilterContacts(text);
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs eventArguments)
        {
            if (eventArguments.CurrentSelection.FirstOrDefault() is ChatSummary selectedContact)
            {
                // string route = $"///ChatPage?chatId={selectedContact.ChatId}";
                // await Shell.Current.GoToAsync(route);
                int userId = 1;
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:5086/");
                HttpRepository apiService = new HttpRepository(httpClient);

                Service service = new Service(apiService);

                ChatPageViewModel chatPageViewModel = new ChatPageViewModel(service, userId);
                chatPageViewModel.SetChatId(selectedContact.ChatId);
                ChatPage chatPage = new ChatPage(chatPageViewModel);
                chatPage.ChatId = selectedContact.ChatId;
                this.Navigation.PushAsync(chatPage);
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs arguments)
        {
            base.OnNavigatedTo(arguments);

            viewModel.FilterContacts(string.Empty);
        }
    }
}
