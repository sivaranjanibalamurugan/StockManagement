using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace StockManagement
{
    class StockPortfolio
    {
        public  void ReadInput()
        {
            StockManager StockManager = new StockManager();
            string filePath = @"C:\Users\user\source\repos\StockManagement\StockManagement\Stock.Json";
            StockUtilitty StockUtilitty = JsonConvert.DeserializeObject<StockUtilitty>(File.ReadAllText(filePath));
            Console.WriteLine("Total share value :{0}", StockManager.PrintReport(StockUtilitty.StockList));
        }
    }
}
