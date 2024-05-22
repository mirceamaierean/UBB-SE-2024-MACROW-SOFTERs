// <copyright file="ChatRoomPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Pages
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.MessageService;
    using RandomChatSrc.Services.RequestChatService;

    /// <summary>
    /// The ChatRoomPage class represents a page that displays a chat room.
    /// It inherits from ContentPage which represents a single screen of content.
    /// </summary>
    public partial class RequestsPage : ContentPage
    {
        private readonly User user;
        private RequestChatService requestService;

        public RequestsPage(User user, RequestChatService requestService)
        {
            this.InitializeComponent();
            this.user = user;
            this.requestService = requestService;
            this.LoadRequests();
        }

        /// <summary>
        /// Loads the conversation from the message service into the UI.
        /// </summary>
        private async void LoadRequests()
        {
            List<Request> requests = await requestService.GetRequestsByUserAsync();
            this.RequestsContainer.Children.Clear();
            foreach (Request request in requests)
            {
                User senderuser = await requestService.GetUserFromIdAsync(request.SenderId);
                User receiveruser = await requestService.GetUserFromIdAsync(request.ReceiverId);

                var messageLabel = new Label
                {
                    Text = senderuser.Id == user.Id ? $"Request sent to: {receiveruser.Name}" : $"Request received from: {senderuser.Name}",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.FromArgb("#ADD8E6"),
                    TextColor = Color.FromArgb("#000000"),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5, 10, 5),
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                this.RequestsContainer.Children.Add(messageLabel);
            }
        }

        private async void ReceivedRequests_Clicked(object sender, EventArgs e)
        {
            List<Request> requests = await requestService.GetReceivedRequestsByUserAsync();
            this.RequestsContainer.Children.Clear();
            foreach (Request request in requests)
            {
                User senderuser = await requestService.GetUserFromIdAsync(request.SenderId);
                User receiveruser = await requestService.GetUserFromIdAsync(request.ReceiverId);

                var messageLabel = new Label
                {
                    Text = senderuser.Id == user.Id ? $"Request sent to: {receiveruser.Name}" : $"Request received from: {senderuser.Name}",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.FromArgb("#ADD8E6"),
                    TextColor = Color.FromArgb("#000000"),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5, 10, 5),
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                this.RequestsContainer.Children.Add(messageLabel);
            }
        }

        private async void SentRequests_Clicked(object sender, EventArgs e)
        {
            List<Request> requests = await requestService.GetSentRequestsByUserAsync();
            this.RequestsContainer.Children.Clear();
            foreach (Request request in requests)
            {
                User senderuser = await requestService.GetUserFromIdAsync(request.SenderId);
                User receiveruser = await requestService.GetUserFromIdAsync(request.ReceiverId);

                var messageLabel = new Label
                {
                    Text = senderuser.Id == user.Id ? $"Request sent to: {receiveruser.Name}" : $"Request received from: {senderuser.Name}",
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.FromArgb("#ADD8E6"),
                    TextColor = Color.FromArgb("#000000"),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5, 10, 5),
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                this.RequestsContainer.Children.Add(messageLabel);
            }
        }
    }
}