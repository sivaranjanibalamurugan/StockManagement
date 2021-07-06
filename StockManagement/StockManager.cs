using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockManagement
{
    class StockManager
    {
        int totalValue = 0;
        public int PrintReport(LinkedList<StockUtilitty.Stock> Stock)
        {
            string item = string.Empty;
            foreach (StockUtilitty.Stock i in Stock)
            {

                item = "name:" + i.companyName + "\nnumberOfShares:" + i.numberOfShare + "\nPrice:" + i.sharePrice;
                Console.WriteLine(item);
                int stockvalue = CalculateStockValue(i.numberOfShare, i.sharePrice);
                Console.WriteLine("Stock Value for {0} company is:{1}", i.companyName, stockvalue);
                totalValue = totalValue+stockvalue;
               
            }
            return totalValue;
        }

        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);
        }
    }
}

    



