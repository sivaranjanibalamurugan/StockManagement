using System;

namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to stock management!");
            StockPortfolio Stock = new StockPortfolio();
            Stock.ReadInput();
            Console.Read();
        }
    }
}
