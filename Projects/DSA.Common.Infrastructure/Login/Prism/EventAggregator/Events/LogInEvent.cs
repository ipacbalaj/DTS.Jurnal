using System;
using DSA.Common.Infrastructure.ViewModel;
using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Infrastructure.Prism.EventAggregator.Events
{
    // we can use this event after login
    public class LogInEvent : CompositePresentationEvent<UserToken> { }

    public class AppNameChangeEvent : CompositePresentationEvent<string> { }
    public class UpdateNotificationsEvent : CompositePresentationEvent<UserToken> { }

    // we can use this class for the entire user info
    public class UserToken : ViewModelBase
    {
        public Guid Id { get; set; }

        private string displayName;
        public string DisplayName 
        { 
            get { return displayName; }
            set
            {
                displayName = value;

                OnPropertyChanged();
            } 
        }
        public int WorkbookId { get; set; }
        public int Notifications { get; set; }
        public int Alerts { get; set; }

        public Action Callback;

        public override string ToString()
        {
            return string.Format("Alerts: {0}, DisplayName: {1}, Id: {2}, Notifications: {3}, WorkbookId: {4}", Alerts, displayName, Id, Notifications, WorkbookId);
        }
    }
}
