using Asaitec.Fruitshop.Web.FrontEnd.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models.Invoice
{
    public class InvoiceModel
    {
        public InvoiceModel()
        {
        }

        public void CreateInvoice(List<Purchase> purchaseCollection, string invoiceFileName)
        {
            Asaitec.Fruitshop.Data.WriteFile writeFile = new Data.WriteFile();
            List<string> lines = new List<string>();
            Invoice invoice = new Invoice();
            invoice.TotalPrice = 0;
            invoice.ProductsPurchased = new List<string>();
            invoice.RulesApplied = new List<string>();
            ApplyBusinessLogic(purchaseCollection);
            lines = CreateInvoiceLines(invoice);
            writeFile.WriteInvoice(lines, invoiceFileName);
        }

        public void ApplyBusinessLogic(List<Purchase> purchaseCollection)
        {
            BusinessLogic.Rules rules = new BusinessLogic.Rules();

            int applesToPay = 0;
            int freeOranges = 0;
            int invoiceDiscount = 0;

            //Buy 3 Apples Pay 2 Rule
            int numberOfApplesBought = purchaseCollection.FindAll(x => x.Product.Equals("Apple")).Count;
            applesToPay = rules.BuyTreeApplesPayTwo(numberOfApplesBought);

            //Free Oranges Rule
            int numberOfPearsBought = purchaseCollection.FindAll(x => x.Product.Equals("Pear")).Count;
            freeOranges = rules.GetFreeOrangeEveryTwoPears(numberOfPearsBought);

            //Total Invoice Discount Rule
            Asaitec.Fruitshop.Web.FrontEnd.Models.ProductModel productsCollection = new Asaitec.Fruitshop.Web.FrontEnd.Models.ProductModel("products.txt");
            decimal pearPrice = productsCollection.GetProductPrice("Pear");
            var pearsBoughtSubset = purchaseCollection.FindAll(x => x.Product.Equals("Pear"));
            decimal totalPearAmount = 0;

            foreach (Purchase _purchase in pearsBoughtSubset)
            {
                totalPearAmount = totalPearAmount + (_purchase.Quantity * productsCollection.GetProductPrice("Pear"));
            }

            decimal totalAmountSpentOnPears = 0;

            foreach (Purchase purchase in pearsBoughtSubset)
            {
                totalAmountSpentOnPears = totalAmountSpentOnPears + (purchase.Quantity * pearPrice);
            }

            invoiceDiscount = rules.FinalInvoiceDiscount(totalAmountSpentOnPears.ToString());
        }
        
        private List<string> CreateInvoiceLines(Invoice invoice)
        {
            List<string> lines = new List<string>();
            lines.Add(invoice.TotalPrice.ToString());
            lines.AddRange(invoice.ProductsPurchased);
            lines.AddRange(invoice.RulesApplied);
            return lines;
        }
    }
}
