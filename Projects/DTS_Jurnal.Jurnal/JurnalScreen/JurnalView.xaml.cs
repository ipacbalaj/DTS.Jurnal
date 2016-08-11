using System.Linq;
using System.Windows.Input;
using DevExpress.Xpf.Grid;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DTS.Common.DatabaseServer.EntitiesModel;

namespace DTS_Jurnal.Jurnal.JurnalScreen
{
    /// <summary>
    /// Interaction logic for JurnalView.xaml
    /// </summary>
    public partial class JurnalView : IWorkAreaView
    {
        public JurnalView()
        {
            InitializeComponent();
            DataContext = new JurnalViewModel(this);

            gridControlInt.Columns["Start"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridControlInt.Columns["Revenue"].Width = 35;
            gridControlInt.Columns["Percent"].Width = 35;
            gridControlInt.Columns["Remainder"].Width = 35;
            gridControlInt.Columns["Date"].Width = 55;
            gridControlInt.Columns["MaterialCost"].Width = 35;
            gridControlInt.Columns["End"].Width = 35;
            gridControlInt.Columns["DurataString"].Width = 35;
            gridControlInt.Columns["Start"].Width = 35;
            gridControlInt.Columns["IsSelected"].Width = 35;
            gridControlInt.Columns["WasPayed"].Width = 35;
            gridControlInt.Columns["Delete"].Width = 25;
        }

        public ShellState RegionToken { get; set; }

        private void TableView_OnCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelected")
            {
                var rwData = (InterventionModel)e.Row;
                if (rwData != null)
                    ((JurnalViewModel)DataContext).ModifySelectedTotal(!(bool)e.OldValue, rwData.Percent, rwData.Id);
            }
            if (e.Column.FieldName == "WasPayed")
            {
                var rwData = (InterventionModel)e.Row;
                if (rwData != null)
                {
                    ((JurnalViewModel)DataContext).ModifyPaymentStatus(rwData);
                }
            }
        }

        private void TableView_OnRowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            ((JurnalViewModel)DataContext).EditIntervention();
        }

        private void JurnalView_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((JurnalViewModel)DataContext).ClearSelection();
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            ((JurnalViewModel)DataContext).ClearSelectedRow();
        }

        private void GridControlInt_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((JurnalViewModel)DataContext).ClearSelectedRow();
        }

        private void TableView_OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                var activeInterventions = e.Source.SelectedRows.Cast<InterventionModel>().ToList();
                ((JurnalViewModel)DataContext).SelectedInterventions = activeInterventions;
                ((JurnalViewModel)DataContext).TotalActive = activeInterventions.Sum(item => item.Percent);

            }
        }

        private void GridControlInt_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Shift))
            {
                if (e.Key == Key.P)
                {
                    ((JurnalViewModel)DataContext).SetSelectedInverventionsPaymentStatus();
                    return;
                }

                if (e.Key == Key.S)
                {
                    ((JurnalViewModel)DataContext).SetSelectedInterventionsSelectedStatus();
                    return;
                }
            }

        }

        public void Connect(int connectionId, object target)
        {

        }
    }
}
