using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    public class MainPageViewModel
    {
        private int userId;
        private readonly IService service;
        public ObservableCollection<ChatSummary> Contacts { get; private set; }

        public MainPageViewModel(Service service, int userId)
        {
            this.service = service;
            this.userId = userId;
            this.Contacts = new ObservableCollection<ChatSummary>(service.GetUserChatSummaries(userId, string.Empty));
        }

        public void FilterContacts(string searchText)
        {
            // Clear the contacts list.
            Contacts.Clear();

            // Get a list with all the contacts and add them individually to the observable collection.
            List<ChatSummary> contactMessages = service.GetUserChatSummaries(userId, searchText ?? string.Empty);
            foreach (ChatSummary contactMessage in contactMessages)
            {
                Contacts.Add(contactMessage);
            }
        }
    }
}
