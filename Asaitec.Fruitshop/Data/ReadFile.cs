using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Asaitec.Fruitshop.Data
{
    public class ReadFile
    {
        public ReadFile()
        {
        }

        public string[] ReadProducts(string fileName)
        {
            return ReadLines(fileName);
        }

        public string[] ReadPurchases(string fileName)
        {
            return ReadLines(fileName);
        }

        private string[] ReadLines(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found.");
            }
            else
            {
                return File.ReadAllLines(fileName);
            }
        }
    }
}
