namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: Orders.exe <ordersFilePath> <district> <firstDeliveryTime> <resultFilePath>");

                return;
            }

            string ordersFilePath = args[0];
            string district = args[1];

            if (!DateTime.TryParse(args[2], out DateTime firstDeliveryTime))
            {
                Console.WriteLine("Invalid date format for firstDeliveryTime.");

                return;
            }

            string resultFilePath = args[3];
            var app = new DeliveryApp();

            app.Run(ordersFilePath, district, firstDeliveryTime, resultFilePath);
        }
    }
}
