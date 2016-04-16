using System;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Buttons
{
    public class ActionButtonViewModel : ViewModelBase
    {
        public ICommand ButtonCommand { get; set; }
        public ActionButtonViewModel(String text, ICommand receivedCommand,String imagePath)
        {
            Text = text;
            ButtonCommand = receivedCommand;
            ImagePath = imagePath;
        }

        #region Properties

        public ActionButtonView ViewReference { get; set; }

        private String text;
        public String Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private string imagePath=Infrastructure.ImagePath.SaveIconPath;
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

        private bool isEnable = true;
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged();
            }
        }

        private double opacity = 1;
        public double Opacity
        {
            get { return opacity; }
            set
            {
                opacity = value;
                OnPropertyChanged();
            }
        }

        private Brush buttonBackground = BackgroundColors.White;
        public Brush ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                buttonBackground = value;
                OnPropertyChanged();
            }
        }

        private Brush textColor = BackgroundColors.statusBackgroundColor;
        public Brush TextColor
        {
            get { return textColor; }
            set
            {
                if (textColor != value)
                {
                    textColor = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// When mouse on, the BackGround and TextColor properties are changed.
        /// </summary>
        public void MouseOn()
        {
            ButtonBackground = BackgroundColors.BackgroundMediumColor;
            TextColor = BackgroundColors.Black;
        }

        /// <summary>
        /// When mouse off, the BackGround and TextColor properties are changed.
        /// </summary>
        public void MouseOff()
        {
            if (IsEnable)
            {
                ButtonBackground = BackgroundColors.White;
                TextColor = BackgroundColors.statusBackgroundColor;
            }
        }

        /// <summary>
        /// Set the button IsEnable property.
        /// </summary>
        /// <param name="shouldEnable">if set to <c>true</c> the button will be enable.</param>
        public void MakeEnable(bool shouldEnable)
        {
            IsEnable = shouldEnable;
            if (!shouldEnable)
            {
                Opacity = 0.5;
                ButtonBackground = BackgroundColors.ButtonUnenable;
                TextColor = BackgroundColors.TextUnenable;
            }
            else
            {
                Opacity = 1;
                ButtonBackground = BackgroundColors.White;
                TextColor = BackgroundColors.Black;
            }
        }

        #endregion

    }
}
