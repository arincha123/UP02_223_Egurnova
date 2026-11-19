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
        private List<String> productCategories;
        private List<String> productSuppliers;
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

            LoadFormData();
            LoadProdData();

        }

        private void LoadFormData()
        {
            productCategories = Core.context.ProductCategory.Select(x => x.Name).ToList();
            ProdCat.ItemsSource = productCategories;


            productSuppliers = Core.context.Supplier.Select(x => x.Name).ToList();
            ProdSup.ItemsSource = productSuppliers;
        }

        private void LoadProdData()
        {
            if (IsNew)
            {
                Path.Text = null;
                ProdName.Text = null;
                ProdCat = null;
                ProdDesc.Text = null;
                ProdManuf.Text = null;
                ProdSup = null;
                ProdPrice.Text = null;
                ProdUnit.Text = null;
                ProdQuant.Text = null;
                ProdDis.Text = null;
            }
            else
            {
                Path.Text = CurProd.CoverPath;
                ProdName.Text = CurProd.Name;
                ProdCat.SelectedItem = ProdCat.Items.Cast<ProductCategory>().FirstOrDefault(pc => pc.Id == CurProd.ProductCategoryId);
                ProdDesc.Text = CurProd.Description;
                ProdManuf.Text = CurProd.Manufacturer.ToString();
                ProdSup.SelectedItem = ProdSup.Items.Cast<Supplier>().FirstOrDefault(pc => pc.Id == CurProd.SupplierId);
                ProdPrice.Text = CurProd.Price.ToString();
                ProdUnit.Text = CurProd.UnitOFMeasure.ToString();
                ProdQuant.Text = CurProd.QuantityInStock.ToString();
                ProdDis.Text = CurProd.Discount.ToString();
            }
        }
    }
}
