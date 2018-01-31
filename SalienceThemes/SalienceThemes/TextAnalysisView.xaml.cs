using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using SalienceThemes.Models;
using SalienceThemes.ViewModels;

namespace SalienceThemes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TextAnalysisView : UserControl
    {
        Theme _theme;
        TextAnalysisViewModel _textAnalysisViewModel;

        public TextAnalysisView()
        {
            InitializeComponent();
            _textAnalysisViewModel = new TextAnalysisViewModel();
            DataContext = _textAnalysisViewModel;
        }

        private void ThemeChip_OnDeleteClick(object sender, RoutedEventArgs e)
        {
            Chip themeChip = (Chip)sender;
            _theme = (Theme)themeChip.Tag;
            _textAnalysisViewModel.Delete_Theme(_theme);
        }

        private ListSortDirection _sortDirection;
        private GridViewColumnHeader _sortColumn;

        private void ThemeListViewClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = e.OriginalSource as GridViewColumnHeader;
            if (column == null)
            {
                return;
            }

            if (_sortColumn == column)
            {
                // Toggle sorting direction
                _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                                                   ListSortDirection.Descending :
                                                   ListSortDirection.Ascending;
            }
            else
            {
                // Remove arrow from previously sorted header
                if (_sortColumn != null)
                {
                    _sortColumn.Column.HeaderTemplate = null;
                    _sortColumn.Column.Width = _sortColumn.ActualWidth - 20;
                }

                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
                column.Column.Width = column.ActualWidth + 20;
            }

            if (_sortDirection == ListSortDirection.Ascending)
            {
                column.Column.HeaderTemplate = Resources["ArrowUp"] as DataTemplate;
            }
            else
            {
                column.Column.HeaderTemplate = Resources["ArrowDown"] as DataTemplate;
            }

            string header = string.Empty;

            // if binding is used and property name doesn't match header content
            Binding b = _sortColumn.Column.DisplayMemberBinding as Binding;
            if (b != null)
            {
                header = b.Path.Path;
            }

            ICollectionView resultDataView = CollectionViewSource.GetDefaultView(ThemesTable.ItemsSource);
            resultDataView.SortDescriptions.Clear();
            resultDataView.SortDescriptions.Add(new SortDescription(header, _sortDirection));
        }
    }
}
