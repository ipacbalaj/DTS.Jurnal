using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace DSA.Common.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for ActionButtonView.xaml
    /// </summary>
    public partial class ActionButtonView : UserControl
    {
        public ActionButtonView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((ActionButtonViewModel) DataContext).ViewReference = this;
        }

        /// <summary>
        /// Called when [mouse enter].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if(DataContext!=null)
            ((ActionButtonViewModel)DataContext).MouseOn();
        }

        /// <summary>
        /// Called when [mouse leave].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((ActionButtonViewModel)DataContext).MouseOff();
        }
    }
}
