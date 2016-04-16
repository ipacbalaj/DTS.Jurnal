using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Loading.MetroLoading
{
    public class MetroLoadingViewModel:ViewModelBase
    {
        #region Constructor

        public MetroLoadingViewModel(bool shallContinue)
        {
            ShouldContinueAnimation = shallContinue;
        }

        #endregion Constructor

        #region Properties

        private string usetName;

        public string UserName
        {
            get { return usetName; }
            set
            {
                if (value == usetName)
                    return;
                usetName = value;
                OnPropertyChanged();
            }
        }

        public MetroLoadingView MetroLoadingViewReference { get; set; }

        private Visibility controlVisibility=Visibility.Visible;

        public Visibility ControlVisibility
        {
            get { return controlVisibility; }
            set
            {
                if (value == controlVisibility)
                    return;
                controlVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool shouldContinueAnimation;

        public bool ShouldContinueAnimation
        {
            get { return shouldContinueAnimation; }
            set
            {
                if (value == shouldContinueAnimation)
                    return;
                shouldContinueAnimation = value;
                ControlVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged();
            }
        }
        
        #endregion Properties


        #region Methods


        #endregion Methods
    }
}
