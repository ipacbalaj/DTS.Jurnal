using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DSA.Common.Infrastructure.ViewModel;
using Microsoft.Practices.Prism.Commands;

namespace DSA.Common.Controls.Options
{
    public class OptionsViewModel : ViewModelBase
    {
        private DetailState state = DetailState.Open;

        public DetailState State
        {
            get { return state; }
            set
            {
                if (state == value)
                    return;
                state = value;
                OnPropertyChanged();
                OnPropertyChanged("PanelVisible");
                OnPropertyChanged("HeaderVisible");
            }
        }

        public Visibility PanelVisible
        {
            get { return state == DetailState.Open ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility HeaderVisible
        {
            get { return state == DetailState.Closed ? Visibility.Visible : Visibility.Collapsed; }
        }

        private UIElement content;
        /// <summary>
        /// Gets or sets the content control.
        /// </summary>
        /// <value>
        /// The content control.
        /// </value>
        public UIElement Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged();
                }
            }
        }

        public Dictionary<string, UIElement> Contents { get; set; }

        public ICommand ShowHeader { get; private set; }
        public ICommand ShowPanel { get; private set; }
       
        public OptionsViewModel()
        {
            State = DetailState.Closed;
            ShowHeader = new DelegateCommand(OnCloseCommand);
            ShowPanel = new DelegateCommand<object>(OnShowPanel);
        }
        
        private string panelName;
        public string PanelName
        {
            get { return panelName; }
            set
            {
                if (panelName == value)
                    return;
                panelName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Tab> tabs;
        public ObservableCollection<Tab> Tabs
        {
            get { return tabs; }
            set
            {
                if (tabs == value)
                    return;
                tabs = value;
                OnPropertyChanged();
            }
        }
        
        private void OnCloseCommand()
        {
            State = DetailState.Closed;
        }

        private void OnShowPanel(object panelName)
        {
            PanelName = panelName.ToString();
            Content = Contents[panelName.ToString()];
            State = DetailState.Open;
            //Tabs.First(item => item.PanelName.Equals(panelName.ToString())).Visibility = Visibility.Collapsed;
        }

        public void SetContent(Dictionary<string, UIElement> dict)
        {
            Contents = dict;
            Tabs = new ObservableCollection<Tab>();
            foreach (KeyValuePair<string, UIElement> keyValuePair in dict)
            {
                Tabs.Add(new Tab(){ PanelName = keyValuePair.Key, Visibility = Visibility.Visible });
            }
        }
    }

    public enum DetailState
    {
        Open,
        Closed
    }

    public class Tab : ViewModelBase
    {
        private string panelName;
        public string PanelName
        {
            get { return panelName; }
            set
            {
                if (panelName == value)
                    return;

                panelName = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibility = Visibility.Hidden;
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                if (visibility == value)
                    return;

                visibility = value;
                OnPropertyChanged();
            }
        }
    }
}

