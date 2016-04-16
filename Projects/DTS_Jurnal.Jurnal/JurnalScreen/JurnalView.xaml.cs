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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using DSA.Common.Infrastructure.Entities;
using DSA.Common.Infrastructure.Prism.EventAggregator.Events;
using DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces;
using DTS.Jurnal.V3.Database.Module.Entities;

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
                    ((JurnalViewModel)DataContext).ModifySelectedTotal(!(bool)e.OldValue, rwData.Revenue, rwData.Id);
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

        private void GridControlInt_OnLostMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void JurnalView_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((JurnalViewModel)DataContext).ClearSelectedRow();
        }

        private void GridControlInt_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((JurnalViewModel)DataContext).ClearSelectedRow();
        }

        public void Print()
        {

        }

        public void ShowPrintPreview()
        {
            DocumentPreviewWindow preview = new DocumentPreviewWindow();
            PrintableControlLink link = new PrintableControlLink(gridControlInt.View as DevExpress.Xpf.Printing.IPrintableControl);
            //            link.ExportServiceUri = "../ExportService1.svc";
            LinkPreviewModel model = new LinkPreviewModel(link);
            preview.Model = model;
            link.CreateDocument(false);
            preview.ShowDialog();
        }

        private void TableView_OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                ((JurnalViewModel)DataContext).SelectedInterventions = e.Source.SelectedRows.Cast<InterventionModel>().ToList();
            }
        }

        private void GridControlInt_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control))
            {
                if (e.Key == Key.K)
                {
                    ((JurnalViewModel)DataContext).SetSelectedInverventionsPaymentStatus();
                    return;
                }

                if (e.Key == Key.L)
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
