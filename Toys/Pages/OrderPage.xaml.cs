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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public List<Order> orders;
        public OrderPage()
        {
            InitializeComponent();
            PageLoad();
        }

        public void PageLoad()
        {
            orders = Core.context.Order.Where(o => o.isFrozen ==  false).ToList();
            OrdList.ItemsSource = orders;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OrdList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Order ord = listBox.SelectedItem as Order;
            if (ord != null)
            {

            }
        }
    }
}
