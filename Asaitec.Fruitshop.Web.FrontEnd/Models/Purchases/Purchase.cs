using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models.Purchases
{
    public class Purchase : IPurchase
    {
        public string Product;
        public int Quantity;
    }
}
