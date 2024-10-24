namespace Orders
{
    internal class Program
    {
        public void Run(string ordersFilePath, string district, DateTime firstDeliveryTime, string resultFilePath)
        {
            try
            {
                var orders = ReadingFromFile.ReadOrdersFromFile(ordersFilePath);
                var filteredOrders = Filtering.FilterOrders(orders, district, firstDeliveryTime);

                File.WriteAllLines(resultFilePath, filteredOrders.Select(o => $"{o.OrderId},{o.Weight},{o.District},{o.DeliveryTime}"));
                Logging.Log("Filtering completed successfully");
            }
            catch (Exception ex)
            {
                Logging.Log($"Error: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: app.exe <ordersFilePath> <district> <firstDeliveryTime> <resultFilePath>");

                return;
            }

            string ordersFilePath = args[0];
            string district = args[1];

            if (!DateTime.TryParse(args[2], out DateTime firstDeliveryTime))
            {
                Console.WriteLine("Invalid date format for firstDeliveryTime");

                return;
            }

            string resultFilePath = args[3];
            var app = new Orders();

            app.Run(ordersFilePath, district, firstDeliveryTime, resultFilePath);
        }
    }
}
