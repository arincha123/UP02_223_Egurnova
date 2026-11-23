using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    public partial class Products
    {
        public string CoverPath => PhotoPath == null ? "/images/picture.png" : $"/images/{PhotoPath}";
        public bool DiscountMore17 => Discount > 17;
        public bool DiscountIsExist => Discount > 0;
        public decimal ReducePrice => DiscountIsExist? Price - ((Price*Discount)/100) : Price;
        public bool ProdOutOfStock => QuantityInStock == 0;


    }
}
