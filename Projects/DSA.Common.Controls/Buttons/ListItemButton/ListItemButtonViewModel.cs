using System;
using System.Windows.Input;
using System.Windows.Media;
using DSA.Common.Infrastructure.Styles;
using DSA.Common.Infrastructure.ViewModel;

namespace DSA.Common.Controls.Buttons.ListItemButton
{
    public class ListItemButtonViewModel : BindableObjectListBase<ListItemButtonViewModel>
    {
        public ICommand ButtonCommand { get; set; }
        public ListItemButtonViewModel(long id, String text, ICommand receivedCommand)
        {
            Id = id;
            Text = text;
            ButtonCommand = receivedCommand;
        }

        #region Properties

        public ActionButtonView ViewReference { get; set; }

        public long Id { get; set; }

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

        private Brush buttonBackground = BackgroundColors.ButtonUnenable;
        public Brush ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                buttonBackground = value;
                OnPropertyChanged();
            }
        }

        private Brush textColor = BackgroundColors.ButtonUnenable;
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

        public override void OnClick(bool shouldSelect)
        {
            IsSelected = shouldSelect;
            if (IsSelected)
            {
                
                TextColor = BackgroundColors.ButtonMouseOnColor;
            }
            else
            {
                
                TextColor = BackgroundColors.ButtonUnenable;
            }
        }

        public void OnSelected()
        {
            ListOfElements.OnSelectedObject(this);

            ButtonCommand.Execute(Text);
        }

        /// <summary>
        /// When mouse on the BackGround and TextColor properties are changed.
        /// </summary>
        public void MouseOn()
        {
            if (!IsSelected)
            {
                ButtonBackground = BackgroundColors.BackgroundMediumColor;
                TextColor = BackgroundColors.ButtonUnenable;
            }
        }

        /// <summary>
        /// When mouse of the BackGround and TextColor properties are changed.
        /// </summary>
        public void MouseOff()
        {
            if (!IsSelected)
            {
                ButtonBackground = BackgroundColors.White;
                TextColor = BackgroundColors.Black;
            }
        }

    }
}
