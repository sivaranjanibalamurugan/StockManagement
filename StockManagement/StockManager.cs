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
        StockLinkedList stockLinkedList;
        StockUtilitty[] stocks1;
        int totalValue = 0;
        DateTime date;
        public StockManager()
        {
            this.stockLinkedList = new StockLinkedList();
        }

        public void CreateNewStock()
        {
            
            //create the new share
            StockUtilitty stock = new StockUtilitty();
            Console.WriteLine("Enter the name of company:");
            stock.companyName = Console.ReadLine();
            Console.WriteLine("Enter the number of share:");
            stock.numberOfShare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            stock.sharePrice = Convert.ToInt32(Console.ReadLine());
            date = DateTime.Now;
            stock.date = date.ToString("dd/MM/yyyy");
            stock.time = date.ToString("HH:mm:ss");
            stockLinkedList.AddLast(stock);

        }
        public void BuyShare(int amount, string company )
        {

            StockManager stockManager = new StockManager();
            //create to buy share
            StockUtilitty stock = new StockUtilitty();
            int contains = 0;
            int price = 0;
            stocks1 = this.stockLinkedList.display();
            for (int i = 0; i < stocks1.Length; i++)
            {
                if (stocks1[i].companyName.Equals(company))
                {
                    stocks1[i].numberOfShare += amount;
                    date = DateTime.Now;
                    stocks1[i].date = date.ToString("dd/MM/yyyy");
                    stocks1[i].time = date.ToString("HH:mm:ss");
                    contains = 1;
                    break;
                }
            }
            if (contains == 0)
            {
                Console.WriteLine("Stock not already available");
                Console.WriteLine("Enter the price of stock:");
                price = Convert.ToInt32(Console.ReadLine());
                stock.companyName = company;
                stock.numberOfShare = amount;
                stock.sharePrice = price;
                date = DateTime.Now;
                stock.date = date.ToString("dd/MM/yyyy");
                stock.time = date.ToString("HH:mm:ss");
                stockLinkedList.AddLast(stock);
            }

        }


        public void SellShare(int amount, string company )
        {

            StockManager stockManager = new StockManager();
            //create to shell  share
            StockUtilitty stock = new StockUtilitty();
            int contains = 0;
            for (int i = 0; i < stocks1.Length; i++)
            {
                if (stocks1[i].companyName.Equals(company) && amount < stocks1[i].numberOfShare)
                {
                    stocks1[i].numberOfShare -= amount;
                    Console.WriteLine("{0} number of shares has been sold ", amount);
                    stocks1[i].date = date.ToString("dd/MM/yyyy");
                    stocks1[i].time = date.ToString("HH:mm:ss");
                    contains = 1;
                    break;
                }
                else if (stocks1[i].companyName.Equals(company) && amount < stocks1[i].numberOfShare)
                {
                    contains = 1;
                    Console.WriteLine("since amount is less that available share enite share is sold ");
                    //if number of share is less than amount the remove the entire share
                    stockLinkedList.RemoveData(stocks1[i]);
                }
            }

            if (contains == 0)
            {
                Console.WriteLine("No share is Available"); ;
            }


        }
        //to print report
        public  int PrintReport()
        {

            string item = String.Empty;

            stocks1 = this.stockLinkedList.display();
            if (stocks1 == null)
            {
                Console.WriteLine("No shares available to display");
            }
            else
            {
                for (int i = 0; i < stocks1.Length; i++)
                {

                    item = "name:" + stocks1[i].companyName + "\nNumber of shares:" + stocks1[i].numberOfShare + "\nPrice:" + stocks1[i].sharePrice;
                    Console.WriteLine(item);
                    Console.WriteLine("Date and Time of stock update:{0}  {1}", stocks1[i].date, stocks1[i].time);
                    int stockvalue = CalculateStockValue(stocks1[i].numberOfShare, stocks1[i].sharePrice);
                    Console.WriteLine("Stock Value for {0} company is:{1}", stocks1[i].companyName, stockvalue);
                    totalValue += stockvalue;
                    
                }
            }
            return totalValue;
        }

        public static int CalculateStockValue(int num, int price)
        {
            return (num * price);
        }

    }
}
