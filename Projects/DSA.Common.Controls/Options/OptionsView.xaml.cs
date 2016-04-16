using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DSA.Common.Controls.Options
{
    /// <summary>
    /// Interaction logic for OptionsView.xaml
    /// </summary>
    public partial class OptionsView : UserControl
    {
       public OptionsViewModel ViewModel { get; set; }

       public OptionsView()
        {
            InitializeComponent();
            this.DataContextChanged += FilterViewDataContextChanged;
        }

        private void FilterViewDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = (OptionsViewModel) e.NewValue;
        }

        private void FilterCollapseMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.ShowHeader.Execute(null);
        }

        private void CollapseTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.ShowHeader.Execute(null);
        }
    }
}
