using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Asaitec.Fruitshop.Data
{
    public class WriteFile
    {
        public WriteFile()
        { }

        public void WriteInvoice(List<string> InvoiceLines, string InvoiceFileName)
        {
            File.WriteAllLines(InvoiceFileName, InvoiceLines, Encoding.UTF8);
        }
    }
}
