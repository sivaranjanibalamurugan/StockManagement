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


            bool CONTINUE = true;

            while (CONTINUE)
            {
                Console.WriteLine("1.Print Report\n2.Add new Share\n3.Buy shares\n4.Sell share");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Total share value :{0}", StockManager.PrintReport(StockUtilitty.StockList));
                        break;
                    case 2:
                        StockManager.CreateNewStock(StockUtilitty.StockList);
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of Share:");
                        string companyName = Console.ReadLine();
                        Console.WriteLine("Enter the number:");
                        int numberOfShare = Convert.ToInt32(Console.ReadLine());
                        StockManager.BuyShare(numberOfShare, companyName, StockUtilitty.StockList);
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of Share to be sold:");
                        string company = Console.ReadLine();
                        Console.WriteLine("Enter the number:");
                        int numOfShare = Convert.ToInt32(Console.ReadLine());
                        StockManager.SellShare(numOfShare, company, StockUtilitty.StockList);
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        CONTINUE = false;
                        break;
                }
            }
        }
    }
}
    

