// <copyright file="OpenChatsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Pages
{
    using System.Xml;
    using RandomChatSrc.Models;
    using RandomChatSrc.Repository;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.MapService;
    using RandomChatSrc.Services.MessageService;
    using RandomChatSrc.Services.RandomMatchingService;
    using RandomChatSrc.Services.RequestChatService;
    using RandomChatSrc.Services.UserChatListService;

    /// <summary>
    /// Represents the OpenChatsWindow view.
    /// </summary>
    public partial class OpenChatsWindow : ContentPage
    {
        private readonly ChatroomsManagementService chatService;
        private readonly User currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenChatsWindow"/> class.
        /// </summary>
        /// <param name="chatService">The chat service instance.</param>
        public OpenChatsWindow(ChatroomsManagementService chatService, User user)
        {
            this.chatService = chatService;
            this.currentUser = user;
            this.WidthRequest = 800;
            this.HeightRequest = 600;
            this.BackgroundColor = Color.FromArgb("#FFFFFF");
            this.InitializeComponent();
        }

        /// <summary>
        /// Refreshes the list of active chats displayed on the UI.
        /// </summary>
        private async void RefreshActiveChats()
        {
            // Clear the layout
            this.chatStackLayout.Children.Clear();
            // Parse the chats
            foreach (Chat chat in this.chatService.GetAllChats())
            {
                List<Message> messages = await chatService.GetMessagesAsync(chat);
                // Create a custom UI element for each chat
                var chatLayout = new StackLayout
                {
                    Margin = new Thickness(7),
                    BackgroundColor = Color.FromArgb("#E2E2E2"),
                };

                var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };
                var chatInfoLayout = new StackLayout { VerticalOptions = LayoutOptions.Center, Margin = new Thickness(8) };
                var chatIdLabel = new Label
                {
                    Text = $"Chat: {chat.Name}",
                    FontSize = 18,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.FromArgb("#000000"),
                };

                var lastMessageLabel = new Label
                {
                    Text = $"Last Message: {((messages.Count != 0) ? messages.Last().Content : "No messages yet")}",
                    FontSize = 15,
                    TextColor = Color.FromArgb("#000000"),
                };

                chatInfoLayout.Children.Add(chatIdLabel);
                chatInfoLayout.Children.Add(lastMessageLabel);
                chatHeaderLayout.Children.Add(chatInfoLayout);
                chatLayout.Children.Add(chatHeaderLayout);
                chatLayout.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    CommandParameter = chat,
                    Command = new Command(this.OpenDummyPage),
                });

                // Add the custom UI element to the stack layout
                this.chatStackLayout.Children.Add(chatLayout);
            }
        }

        /// <summary>
        /// Opens the chat page corresponding to the selected chat.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        private async void OpenDummyPage(object sender)
        {
            if (sender is Chat selectedChat)
            {
                // Open the chat page
                MessageService messageService = new (selectedChat, this.currentUser, this.chatService.GetHttpClient());
                await this.Navigation.PushAsync(new ChatRoomPage(this.currentUser, messageService));
            }
        }

        /// <summary>
        /// Handles the event when the random chat button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void RandomChatButton_Clicked(object sender, EventArgs e)
        {
            Chat selectedChat = this.chatService.GetRandomChat();
            MessageService messageService = new (selectedChat, this.currentUser, this.chatService.GetHttpClient());
            await this.Navigation.PushAsync(new ChatRoomPage(this.currentUser, messageService));
        }

        /// <summary>
        /// Handles the event when the open chat button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OpenChatButton_Clicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the event when the requests button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void RequestsButton_Clicked(object sender, EventArgs e)
        {
            RequestChatService requestService = new RequestChatService(this.currentUser, this.chatService.GetHttpClient());
            await this.Navigation.PushAsync(new RequestsPage(this.currentUser, requestService));
        }

        /// <summary>
        /// Handles the event when a chat item is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ChatItem_Clicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the event when the map button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new MapWindow(new MapService()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.RefreshActiveChats();
        }
    }
}