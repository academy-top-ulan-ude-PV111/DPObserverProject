namespace DPObserverProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new();

            Bank bank1 = new("Сбербанк", stock);
            Bank bank2 = new("ВТБ", stock);

            Broker broker1 = new("Иванов", stock);

            for(int i = 0; i < 5; i++) 
            {
                Console.WriteLine($"Auction #{i + 1}");
                stock.Auction();
                Console.WriteLine();
            }

            bank2.StopStock();
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Auction #{i + 1}");
                stock.Auction();
                Console.WriteLine();
            }
        }
    }
}