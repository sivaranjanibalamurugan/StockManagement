using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class StockUtilitty
    {
        public LinkedList<Stock> StockList{ get;  set; }

        public class Stock
        {
            public String companyName { get; set; }
            public  int numberOfShare { get; set; }
            public  int sharePrice { get; set; }
        }
    }
}
