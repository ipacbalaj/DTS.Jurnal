using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Infrastructure.Login
{
    public enum LoginStatus
    {
        Successful, Unsuccessful
    }

    /// <summary>
    /// this will store the Server's response after client tries to login
    /// </summary>
    public class LoginResponse : ViewModelBase
    {

        /// <summary>
        /// Property of type <see cref="LoginStatus"/>
        /// </summary>
        private LoginStatus status;
        public LoginStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }

        private string userName;

        public string Username
        {
            get { return userName; }
            set
            {
                if (value == userName)
                    return;
                userName = value;
                OnPropertyChanged();
            }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set
            {
                if (value == userId)
                    return;
                userId = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Property of type <see cref="UserRole"/>
        /// </summary>
        private string userRole;
        public string UserRole
        {
            get { return userRole; }
            set
            {
                if (userRole != value)
                {
                    userRole = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Depending on server's response a specific description will be set.
        /// </summary>
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isMasterClient;
        public bool IsMasterClient
        {
            get { return isMasterClient; }
            set
            {
                if (isMasterClient != value)
                {
                    isMasterClient = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
