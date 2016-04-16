using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DSA.Common.Controls.Buttons.SymbolButton
{
    /// <summary>
    /// Interaction logic for SymbolIconButtonView.xaml
    /// </summary>
    public partial class SymbolIconButtonView : UserControl
    {
        public SymbolIconButtonView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }


        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((SymbolIconButtonViewModel)DataContext).ViewReference = this;
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ((SymbolIconButtonViewModel)DataContext).MouseOn();
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((SymbolIconButtonViewModel)DataContext).MouseOff();
        }
    }
}
