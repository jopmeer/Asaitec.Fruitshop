using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Asaitec.Fruitshop.Web.FrontEnd.Models
{
    public class ProductModel
    {
        private List<Product> productCollection;

        public ProductModel(string fileName)
        {
            productCollection = new List<Product>();
            productCollection = readProducts(fileName);
        }

        public decimal GetProductPrice(string productName)
        {
            return productCollection.Find(x => x.Name.Equals(productName)).Price;
        }

        private List<Product> readProducts(string fileName)
        {
            Product product;
            List<Product> products = new List<Product>();
            Asaitec.Fruitshop.Data.ReadFile readFile = new Asaitec.Fruitshop.Data.ReadFile();
            var productLines = readFile.ReadProducts(fileName);

            foreach (string line in productLines)
            {
                product = new Product();
                var splitResult = line.Split(';');
                product.Name = splitResult[0];
                product.Price = Convert.ToDecimal(splitResult[1]);
                products.Add(product);
            }

            return products;
        }
    }
}
