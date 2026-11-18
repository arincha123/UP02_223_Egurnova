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

namespace Toys.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Products> products;
        public List<String> suppliers;
        public List<String> sort;
        public List<Products> SearchedList;
        public MainPage()
        {
            InitializeComponent();

            products = Core.context.Products.ToList();
            ProdList.ItemsSource = products;

            suppliers = Core.context.Supplier.Select(x => x.Name).ToList();
            suppliers.Insert(0, "Все поставщики");
            FiltrBox.ItemsSource = suppliers;

            sort = new List<String>()
            {
                "Без сортировки",
                "По возрастанию",
                "По убыванию",
                "По цене"
            };
            SortBox.ItemsSource = sort;

            FiltrBox.SelectedIndex = 0;
            SortBox.SelectedIndex = 0;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
            UserData.curUser = null;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GlobalSearch();
        }

        private void FiltrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalSearch();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalSearch();
        }

        public void GlobalSearch()
        {
            var SearchedText = SearchBox.Text;
            SearchedList = products;

            if (!string.IsNullOrEmpty(SearchedText))
            {
                SearchedList = SearchedList.Where(l => l.Name.ToLower().Contains(SearchedText.ToLower())).ToList();
            }

            //if (SortBox.SelectedItem is ComboBoxItem comboBoxItem && comboBoxItem.Content.ToString() != "Без сортировки")
            if (SortBox.SelectedItem is string SortType && SortType != "Без сортировки")
            {
                //string SortrType = comboBoxItem.Content.ToString();
                switch (SortType)
                {
                    case "По возрастанию":
                        SearchedList = SearchedList.OrderBy(l => l.QuantityInStock).ToList();
                        break;
                    case "По убыванию":
                        SearchedList = SearchedList.OrderByDescending(l => l.QuantityInStock).ToList();
                        break;
                    case "По цене":
                        SearchedList = SearchedList.OrderBy(l => l.Price).ToList();
                        break;

                }
            }

            //if (FiltrBox.SelectedItem is ComboBoxItem comboBoxItem1 && comboBoxItem1.Content.ToString() != "Все поставщики")
            if (FiltrBox.SelectedItem is string FiltrType && FiltrType != "Все поставщики")
            {
                //var FiltrType = comboBoxItem1.Content.ToString();
                SearchedList = SearchedList.Where(s => s.Supplier.Name.ToLower() == FiltrType.ToLower()).ToList();
            }


            ProdList.ItemsSource = SearchedList;

        }
    }
}
