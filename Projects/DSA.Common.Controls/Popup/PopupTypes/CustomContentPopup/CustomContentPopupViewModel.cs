using System;
using ConnectSuiteInstaller.Common.Infrastructure.MVVM;
using ConnectSuiteInstaller.Common.Resource;

namespace ConnectSuiteInstaller.Common.Controls.Popup.PopupTypes.CustomContentPopup
{
    public class CustomContentPopupViewModel : BaseViewModel
    {
        private ITemplateResourceService _templateResourceService;

        #region Constructor

        public CustomContentPopupViewModel(string popupTile, ITemplateResourceService templateResourceService, BaseViewModel viewModel, Type viewType)
        {
            PopupTitle = popupTile;
            _templateResourceService = templateResourceService;
            ContentViewModel = viewModel;
            _templateResourceService.RegisterView(viewModel.GetType(), viewType);
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


        private BaseViewModel contentViewModel;
        public BaseViewModel ContentViewModel
        {
            get { return contentViewModel; }
            set
            {
                if (contentViewModel == value)
                    return;
                contentViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }

}
