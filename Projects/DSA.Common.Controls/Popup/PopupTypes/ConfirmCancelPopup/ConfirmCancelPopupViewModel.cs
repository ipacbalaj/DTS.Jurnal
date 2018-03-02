using System.Windows.Input;
using ConnectSuiteInstaller.Common.Controls.Popup.Contracts;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.ConfirmCancelPopup
{
    public class ConfirmCancelPopupViewModel : SimpleBasePopupViewModel
    {
        #region Constructor

        public ConfirmCancelPopupViewModel(string popupTile, string text, string confirmText, string cancelText)
        {
            PopupTitle = popupTile;
            Text = text;
            OnConfirmText = confirmText;
            OnCancelText = cancelText;
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

        private string onConfirmText = "Ok";
        public string OnConfirmText
        {
            get { return onConfirmText; }
            set
            {
                if (onConfirmText == value)
                    return;
                onConfirmText = value;
                OnPropertyChanged();
            }
        }

        private string onCancelText;
        public string OnCancelText
        {
            get { return onCancelText; }
            set
            {
                if (onCancelText == value)
                    return;
                onCancelText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        private ICommand confirmCommand;
        public ICommand ConfirmCommand
        {
            get
            {
                return confirmCommand ?? (confirmCommand = new BaseCommand(() => OnConfirm(), true));
            }
        }

        private void OnConfirm()
        {
            ActionStatus = true;
            CloseAction();
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new BaseCommand(() => OnCancel(), true));
            }
        }

        private void OnCancel()
        {
            ActionStatus = false;
            CloseAction();
        }

        #endregion
        public override bool GetResult()
        {
            return ActionStatus;
        }
    }
}
