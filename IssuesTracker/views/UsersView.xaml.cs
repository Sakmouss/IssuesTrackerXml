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
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserView addUserView = new AddUserView();

        }

        private void DgrUsers_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

            DataGrid dataGrid = (DataGrid)sender;
            tbxUserCount.Text = dataGrid.Items.Count.ToString();
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

                object item = dataGrid.Items[rowIndex];
                dataGrid.SelectedItem = item;

                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
            }
        }

        private void DgrUsers_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg == null || dg.ItemsSource == null) return;
            var SourceCollecton = dg.ItemsSource as ObservableCollection<User>;
            if (SourceCollecton == null) return;
            SourceCollecton.CollectionChanged += SourceCollecton_CollectionChanged1;
        }

        private void SourceCollecton_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int maxindex = dgrUsers.Items.Count - 1;
            SelectRowByIndex(dgrUsers, maxindex);
            tbxUserCount.Text = dgrUsers.Items.Count.ToString();
        }


        private void DgrUsers_LoadingRow(object sender, DataGridRowEventArgs e)
        {

            DataGrid dataGrid = (DataGrid)sender;
            tbxUserCount.Text = dataGrid.Items.Count.ToString();


        }
    }
}
