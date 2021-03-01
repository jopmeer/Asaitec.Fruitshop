using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models
{
    public class Product : IProduct
    {
        public string Name = string.Empty;
        public decimal Price = 0;
    }
}
