using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Grid;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DTS.Jurnal.Database.SQLServer.Module.EntitiesModel.Local;

namespace DSA.Module.PersonalInfo.PersonalInfoScreen
{
    /// <summary>
    /// Interaction logic for PersonalInfoScreenView.xaml
    /// </summary>
    public partial class PersonalInfoScreenView : UserControl,IWorkAreaView
    {
        public PersonalInfoScreenView()
        {
            InitializeComponent();
            DataContext = new PersonalInfoScreenViewModel();
            ViewPatientGrid.Columns["Start"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            ViewPatientGrid.Columns["Revenue"].Width = 35;
            ViewPatientGrid.Columns["Percent"].Width = 35;
            ViewPatientGrid.Columns["Remainder"].Width = 35;
            ViewPatientGrid.Columns["Date"].Width = 55;
            ViewPatientGrid.Columns["End"].Width = 35;
            ViewPatientGrid.Columns["DurataString"].Width = 35;
            ViewPatientGrid.Columns["Start"].Width = 35;
            ((PersonalInfoScreenViewModel) DataContext).ViewReference = this;
        }

        public ShellState RegionToken { get; set; }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
          //  ((PersonalInfoScreenViewModel)DataContext).OnShowInterventions();
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!DataContext.ToString().Equals("{DisconnectedItem}"))
            {
                ((PersonalInfoScreenViewModel)DataContext).MouseOff();
            }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ((PersonalInfoScreenViewModel)DataContext).MouseOn();
        }

        public void BestFitColums()
        {
            tableView12.BestFitColumns();
        }

        private void TableView12_OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                ((PersonalInfoScreenViewModel)DataContext).SelectedLocalPatients = e.Source.SelectedRows.Cast<LocalPatient>().ToList();
            }
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control))
            {
                if (e.Key == Key.K)
                {
                    ((PersonalInfoScreenViewModel)DataContext).MergePatients();
                    return;
                }
            }
        }
    }
}
