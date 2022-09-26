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
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        public ProjectsView()
        {
            InitializeComponent();
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


        private void DgrProjects_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null || dg.ItemsSource == null) return;
            var SourceCollecton = dg.ItemsSource as ObservableCollection<Project>;
            if (SourceCollecton == null) return;
            SourceCollecton.CollectionChanged += SourceCollecton_CollectionChanged; ;
        }

        private void SourceCollecton_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int maxindex = dgrProjects.Items.Count - 1;
            SelectRowByIndex(dgrProjects, maxindex);
            tbxProjectCount.Text = dgrProjects.Items.Count.ToString();
            // tbxProjectCount.Text = maxindex.ToString();
        }

        private void DgrProjects_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            tbxProjectCount.Text = dataGrid.Items.Count.ToString();
        }
    }
}
