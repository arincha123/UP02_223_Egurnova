using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Products CurProd {  get; set; }
        private bool IsNew;
        private List<String> productCategories;
        private List<String> productSuppliers;
        private List<String> productManufs;
        public EditForm(Products prod)
        {
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
            
            InitializeComponent();
            DataContext = this;
            

            LoadFormData();
            LoadProdData();

        }

        private void LoadFormData()
        {
            productCategories = Core.context.ProductCategory.Select(x => x.Name).ToList();
            ProdCat.ItemsSource = productCategories;

            productManufs = Core.context.Manufacturer.Select(x => x.Name).ToList();
            ProdManuf.ItemsSource = productManufs;

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
                ProdManuf = null;
                ProdSup = null;
                ProdPrice.Text = null;
                ProdUnit.Text = null;
                ProdQuant.Text = null;
                ProdDis.Text = null;
            }
            else
            {
                Path.Text = CurProd.PhotoPath ;
                ProdName.Text = CurProd.Name;
                ProdCat.SelectedItem = ProdCat.Items.Cast<String>().FirstOrDefault(pc => CurProd.ProductCategory.Name == pc);
                ProdDesc.Text = CurProd.Description;
                ProdManuf.SelectedItem = ProdManuf.Items.Cast<String>().FirstOrDefault(pm => pm == CurProd.Manufacturer.Name);


                ProdSup.SelectedItem = ProdSup.Items.Cast<String>().FirstOrDefault(pc => pc == CurProd.Supplier.Name);
                ProdPrice.Text = CurProd.Price.ToString();
                ProdUnit.Text = CurProd.UnitOFMeasure.ToString();
                ProdQuant.Text = CurProd.QuantityInStock.ToString();
                ProdDis.Text = CurProd.Discount.ToString();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            //{
            //    Filter = "*.png;*.jpg"
            //};  //pitipiwpiw wiwwiw
            //if(dlg.ShowDialog() == true)
            //{


            //    MessageBox.Show("sdas");
            //}

            try
            {
                CurProd.PhotoPath = Path.Text;
                CurProd.Name = ProdName.Text;
                CurProd.ProductCategoryId = Core.context.ProductCategory.FirstOrDefault(pc => pc.Name == ProdCat.SelectedItem.ToString()).Id;
                CurProd.Description = ProdDesc.Text;
                //Manufacturer man = Core.context.Manufacturer.FirstOrDefault(m => m.Name == ProdManuf.Text);
                //if (man == null)
                //{
                //    Manufacturer manNew = new Manufacturer() { Name = ProdManuf.Text };
                //    Core.context.Manufacturer.Add(manNew);
                //    Core.context.SaveChanges();
                //    CurProd.ManufacturerId = manNew.Id;
                //}
                //else
                //{
                //    CurProd.ManufacturerId = man.Id;
                //}

                CurProd.ManufacturerId = Core.context.Manufacturer.FirstOrDefault(pm => pm.Name == ProdManuf.SelectedItem.ToString()).Id;
                CurProd.SupplierId = Core.context.Supplier.FirstOrDefault(pc => pc.Name == ProdSup.SelectedItem.ToString()).Id;
                CurProd.Price = Decimal.Parse(ProdPrice.Text);
                CurProd.UnitOFMeasure = ProdUnit.Text;
                CurProd.QuantityInStock = int.Parse(ProdQuant.Text);
                CurProd.Discount = int.Parse(ProdDis.Text);
                Core.context.SaveChanges();

            }
            catch ( Exception ex)
            {
                MessageBox.Show("Слушай, произошло какое-то недоразумение и программа вызвала ошибку, короче введи данные нормальные");
            }

            MessageBox.Show("Все изменения сохранены", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (MessageBox.Show("Вы уверены, что хотите закрыть форму?\n Все несохранённые изменения исчезнут", "Закрытие формы", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите удалить товар", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                CurProd.isFrozen = true;
                    
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
          Close();  
        }
    }
}
