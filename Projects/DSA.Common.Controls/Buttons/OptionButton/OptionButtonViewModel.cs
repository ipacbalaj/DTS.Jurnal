using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Buttons.OptionButton
{
    public class OptionButtonViewModel : ViewModelBase
    {


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value == isSelected)
                    return;
                isSelected = value;
               // TextForegroud = isSelected ? BackgroundColors.BackgroundLightOrangeColor : BackgroundColors.Black;
                if (isSelected)
                {
                    TextForegroud = BackgroundColors.Black;
                    TextSize = 15;
                }
                else
                {
                    TextForegroud = BackgroundColors.statusBackgroundColor;
                    TextSize = 12;
                }
                OnPropertyChanged();
            }
        }

        private int textSize=12;

        public int TextSize
        {
            get { return textSize; }
            set
            {
                if (value == textSize)
                    return;
                textSize = value;
                OnPropertyChanged();
            }
        }

        private Brush textForegroud = BackgroundColors.statusBackgroundColor;

        public Brush TextForegroud
        {
            get { return textForegroud; }
            set
            {
                if (value == textForegroud)
                    return;
                textForegroud = value;
                OnPropertyChanged();
            }
        }

        private UIElement icon;
        public UIElement Icon
        {
            get { return icon; }
            set
            {
                if (icon == value)
                    return;
                icon = value;
                OnPropertyChanged();
            }
        }

        private ICommand onClick;
        public ICommand OnClick
        {
            get { return onClick; }
            set
            {
                if (onClick == value)
                    return;
                onClick = value;
                OnPropertyChanged();
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

    }
}
