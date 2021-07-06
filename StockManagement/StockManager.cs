using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;



namespace StockManagement
{
    class StockManager
    {
        int totalValue = 0;
        DateTime date;
        public void CreateNewStock(LinkedList<StockUtilitty.Stock> stockList)
        {
            StockManager stockManager = new StockManager();
            //create the new share
            StockUtilitty.Stock stock = new StockUtilitty.Stock();
            Console.WriteLine("Enter the name of company:");
            stock.companyName = Console.ReadLine();
            Console.WriteLine("Enter the number of share:");
            stock.numberOfShare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            stock.sharePrice = Convert.ToInt32(Console.ReadLine());
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockList.AddLast(stock);
            stockManager.SaveStock(stockList);
        }
        public void BuyShare(int amount, string company, LinkedList<StockUtilitty.Stock> stockList)
        {

            StockManager stockManager = new StockManager();
            //create to buy share
            StockUtilitty.Stock stock = new StockUtilitty.Stock();
            int contains = 0;
            int price = 0;
            foreach (StockUtilitty.Stock i in stockList)
            {
                if (i.companyName.Equals(company))
                {
                    amount += i.numberOfShare;
                    price = i.sharePrice;
                    company = i.companyName;
                    contains = 1;
                    stockList.Remove(stockList.Find(i));
                    break;
                }
            }
            if (contains == 0)
            {
                Console.WriteLine("Stock not already available");
                Console.WriteLine("Enter the price of stock:");
                price = Convert.ToInt32(Console.ReadLine());
            }
            stock.companyName = company;
            stock.numberOfShare = amount;
            stock.sharePrice = price;
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockList.AddLast(stock);
            stockManager.SaveStock(stockList);
        }

        public void SellShare(int amount, string company, LinkedList<StockUtilitty.Stock> stockList)
        {

            StockManager stockManager = new StockManager();
            //create to shell  share
            StockUtilitty.Stock stock = new StockUtilitty.Stock();
            int contains = 0;
            int price = 0;
            foreach (StockUtilitty.Stock i in stockList)
            {
                if (i.companyName.Equals(company) && amount < i.numberOfShare)
                {
                    amount = i.numberOfShare - amount;
                    price = i.sharePrice;
                    company = i.companyName;
                    contains = 1;
                    stockList.Remove(stockList.Find(i));
                    break;
                }
            }
            if (contains == 1)
            {
                stock.companyName = company;
                stock.numberOfShare = amount;
                stock.sharePrice = price;
                date = DateTime.Now;
                stock.date = date.ToString("dd/MM/yyyy");
                stock.time = date.ToString("HH:mm:ss");
                stockList.AddLast(stock);
                stockManager.SaveStock(stockList);
            }

            else
            {
                Console.WriteLine("No share is Available"); ;
            }

        }
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
        public void SaveStock(LinkedList<StockUtilitty.Stock> stocks)
        {
            string filePath = @"C:\Users\user\source\repos\StockManagement\StockManagement\Stock.Json";
            StockUtilitty StockUtilitty = new StockUtilitty();
            StockUtilitty.StockList = stocks;


            File.WriteAllText(filePath, JsonConvert.SerializeObject(StockUtilitty));
        }

        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);
        }

    }
}
