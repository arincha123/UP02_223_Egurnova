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
using System.Windows.Shapes;

namespace Toys.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {
        private Products CurProd;
        private bool IsNew;
        public EditForm(Products prod)
        {
            InitializeComponent();

            if (prod == null)
            {
                IsNew = true;
                CurProd = new Products();
            }
            else
            {
                IsNew = false;
                CurProd = prod;
            }

            LoadData();

        }


        private void LoadData()
        {
            if (IsNew)
            {

            }
            else
            {

            }
        }
    }
}
