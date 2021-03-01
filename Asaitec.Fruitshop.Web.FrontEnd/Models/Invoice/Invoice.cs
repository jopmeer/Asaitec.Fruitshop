using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models.Invoice
{
    public class Invoice : IInvoice
    {
        public decimal TotalPrice;
        public List<string> ProductsPurchased;
        public List<String> RulesApplied;
    }
}
