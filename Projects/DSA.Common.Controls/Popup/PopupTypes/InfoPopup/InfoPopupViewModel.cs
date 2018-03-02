using System.Windows.Input;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.InfoPopup
{
    public class InfoPopupViewModel : SimpleBasePopupViewModel
    {
        #region Constructor
        public InfoPopupViewModel(string popupTile, string text, string actionText)
        {
            PopupTitle = popupTile;
            Text = text;
            ActionName = actionText;
        }


        #endregion

        #region Properties

        private string popupTitle;
        public string PopupTitle
        {
            get { return popupTitle; }
            set
            {
                if (popupTitle == value)
                    return;
                popupTitle = value;
                OnPropertyChanged();
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                    return;
                text = value;
                OnPropertyChanged();
            }
        }

        private string actionName;
        public string ActionName
        {
            get { return actionName; }
            set
            {
                if (actionName == value)
                    return;
                actionName = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region Comands

        private ICommand closePopupCommand;
        public ICommand ClosePopupCommand
        {
            get
            {
                return closePopupCommand ?? (closePopupCommand = new BaseCommand(() => OnClose(), true));
            }
        }

        private void OnClose()
        {
            CloseAction();
        }

        #endregion

        public override bool GetResult()
        {
            return ActionStatus;
        }
    }
}
