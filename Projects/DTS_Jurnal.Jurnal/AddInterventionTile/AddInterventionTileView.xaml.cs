using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Editors;

namespace DTS_Jurnal.Jurnal.AddInterventionTile
{
    /// <summary>
    /// Interaction logic for AddInterventionTileView.xaml
    /// </summary>
    public partial class AddInterventionTileView : UserControl
    {
        public AddInterventionTileView()
        {
            InitializeComponent();
        }

        private void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.RightCtrl ||e.Key==Key.LeftCtrl)
            {
//                 ((AddInterventionTileViewModel)DataContext).Save();
            }
        }

     //   private int count = 1;

        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == PatientComboBoxEdit)
            {
                ComboBoxEdit editor = (ComboBoxEdit)e.Source;
                string displayText = editor.DisplayText;
                if (!string.IsNullOrEmpty(displayText))
                {
                    ((AddInterventionTileViewModel)DataContext).AddPatient(displayText);

                }
               // DurataTextBox.Text = "";
                //IncasariTextBox.Text = "";   
            }
        }


        private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.RightCtrl || e.Key == Key.LeftCtrl)
            {
                ((AddInterventionTileViewModel)DataContext).OnSave();
            }
        }
    }

    public static class FocusExtension
    {
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }


        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }


        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
             "IsFocused", typeof(bool), typeof(FocusExtension),
             new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));


        private static void OnIsFocusedPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement)d;
            if ((bool)e.NewValue)
            {
                uie.Focus(); // Don't care about false values.
            }
        }
    }
}
