using IssuesTracker.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IssuesTracker.views
{
    /// <summary>
    /// Interaction logic for IssuesViews.xaml
    /// </summary>
    public partial class IssuesViews : UserControl
    {
        public IssuesViews()
        {
            InitializeComponent();
        }

        private void DgrIssues_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null || dg.ItemsSource == null) return;
            var SourceCollecton = dg.ItemsSource as ObservableCollection<Issue>;
            if (SourceCollecton == null) return;
            SourceCollecton.CollectionChanged += SourceCollecton_CollectionChanged;
        }

        private void SourceCollecton_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int maxindex = dgrIssues.Items.Count - 1;
            SelectRowByIndex(dgrIssues, maxindex);
            tbxIssueCount.Text = dgrIssues.Items.Count.ToString();
        }
        public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            if (dataGrid.Items.Count == 0)
            { }
            else
            {
                if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                    throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

                if (rowIndex > (dataGrid.Items.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

                dataGrid.SelectedItems.Clear();
                /* set the SelectedItem property */
                object item = dataGrid.Items[rowIndex]; // = Product X
                dataGrid.SelectedItem = item;

                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    /* bring the data item (Product object) into view
                     * in case it has been virtualized away */
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
            }
        }
    }
}
