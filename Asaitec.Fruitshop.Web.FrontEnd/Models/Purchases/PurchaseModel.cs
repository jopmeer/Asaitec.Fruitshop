using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models.Purchases
{
    public class PurchaseModel
    {
        private List<Purchase> purchaseCollection;

        public PurchaseModel(string fileName)
        {
            purchaseCollection = new List<Purchase>();
            purchaseCollection = readPurchases(fileName);
        }

        private List<Purchase> readPurchases(string fileName)
        {
            Purchase purchase;
            List<Purchase> purchases = new List<Purchase>();
            Asaitec.Fruitshop.Data.ReadFile readFile = new Asaitec.Fruitshop.Data.ReadFile();
            var purchaseLines = readFile.ReadPurchases(fileName);

            foreach (string line in purchaseLines)
            {
                purchase = new Purchase();
                var splitResult = line.Split(';');
                purchase.Product = splitResult[0];
                purchase.Quantity = Convert.ToInt32(splitResult[1]);
                purchases.Add(purchase);
            }

            return purchases;
        }
    }
}
