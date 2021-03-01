using System;
using System.Collections.Generic;
using System.Text;

namespace Asaitec.Fruitshop.BusinessLogic
{
    public class Rules
    {
        public Rules()
        { }

        public int BuyTreeApplesPayTwo(int applesBought)
        {
            if (applesBought == 3)
                return 2;
            else
                return 0;
        }

        public int GetFreeOrangeEveryTwoPears(int numberOfPearsBought)
        {
            if (numberOfPearsBought < 2)
                return 0;
            else
                return (numberOfPearsBought / 2);
        }

        public int FinalInvoiceDiscount(string amountSpentOnPears)
        {
            if (Convert.ToDecimal(amountSpentOnPears) < 4)
                return 0;
            else
                return (Convert.ToInt32(amountSpentOnPears) / 4);
        }
    }
}
