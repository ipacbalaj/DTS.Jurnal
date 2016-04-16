using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace ClientShell.Views.Tabs.HorizontalTab
{
    public class HorizontalTabViewModel:BindableObjectListBase<HorizontalTabViewModel>
    {
        #region Constructor

        public HorizontalTabViewModel(Brush background)
        {
            ContentBackground = background;
        }

        #endregion Constructor

        #region Properties

        private UIElement icon;
        public UIElement Icon
        {
            get { return icon; }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    OnPropertyChanged();
                }
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (value == imagePath)
                    return;
                imagePath = value;
                OnPropertyChanged();
            }
        }

        public ICommand Command { get; set; }

        private String name;
        public String Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private Brush contentBackground;
        public Brush ContentBackground
        {
            get { return contentBackground; }
            set
            {
                if (contentBackground != value)
                {
                    contentBackground = value;
                    OnPropertyChanged();
                }
            }
        }



        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                if (isOpen != value)
                {
                    isOpen = value;

                    OpenVisibility = OpenVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    CloseVisibility = CloseVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

                    OnPropertyChanged();
                }
            }
        }

        private Visibility openVisibility = Visibility.Visible;
        public Visibility OpenVisibility
        {
            get { return openVisibility; }
            set
            {
                if (openVisibility != value)
                {
                    openVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility closeVisibility = Visibility.Collapsed;
        public Visibility CloseVisibility
        {
            get { return closeVisibility; }
            set
            {
                if (closeVisibility != value)
                {
                    closeVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Thickness borderThickness = new Thickness(0,0,0,2);
        public Thickness BorderThickness
        {
            get { return borderThickness; }
            set
            {
                if (value == borderThickness)
                    return;
                borderThickness = value;
                OnPropertyChanged();
            }
        }

        private Thickness bottomBorderThickness=new Thickness(0,0,0,0);
        public Thickness BottomBorderThickness
        {
            get { return bottomBorderThickness; }
            set
            {
                if (value == bottomBorderThickness)
                    return;
                bottomBorderThickness = value;
                OnPropertyChanged();
            }
        }

        private Brush borderColor = BackgroundColors.titleForeground;
        public Brush BorderColor
        {
            get { return borderColor; }
            set
            {
                if (value == borderColor)
                    return;
                borderColor = value;
                OnPropertyChanged();
            }
        }

        private int zIndex=1;

        public int ZIndex
        {
            get { return zIndex; }
            set
            {
                if (value == zIndex)
                    return;
                zIndex = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Methods

        public override void OnClick(bool shouldSelect)
        {
            IsSelected = shouldSelect;
            if (IsSelected)
            {
              //  ContentBackground = BackgroundColors.orange;
                Command.Execute(null);
                BorderThickness = new Thickness(2, 2, 2, 0);
                BottomBorderThickness = new Thickness(0,0,0,3);
                ZIndex = 100;
            }
            else
            {
                BorderThickness = new Thickness(0,0,0, 2);
                BottomBorderThickness = new Thickness(0, 0, 0, 0);
                ZIndex = 1;
                // ContentBackground = BackgroundColors.gray;
            }
        }

        public void MouseOn()
        {
            if (!IsSelected)
            {
               // ContentBackground = BackgroundColors.addInformationTitleCompleted;
            }
        }

        public void MouseOff()
        {
            if (!IsSelected)
            {
                //ContentBackground = BackgroundColors.gray;
            }
        }



        #endregion Methods

    }
}
