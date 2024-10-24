using Orders.Model;

namespace Orders
{
    internal class DeliveryApp
    {
        public List<Order> ReadOrdersFromFile(string filePath)
        {
            var orders = new List<Order>();
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length != 4)
                {
                    Log("Invalid data format");
                    continue;
                }

                if (!double.TryParse(parts[1], out double weight) || !DateTime.TryParse(parts[3], out DateTime deliveryTime))
                {
                    Log("Invalid data format");
                    continue;
                }

                orders.Add(new Order
                {
                    OrderId = parts[0],
                    Weight = weight,
                    District = parts[2],
                    DeliveryTime = deliveryTime
                });
            }

            return orders;
        }

        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            DateTime endTime = firstDeliveryTime.AddMinutes(30);

            return orders.Where(o => o.District == district && o.DeliveryTime >= firstDeliveryTime && o.DeliveryTime <= endTime).ToList();
        }

        public void Log(string message)
        {
            string logFilePath = GetLogFilePath();

            try
            {
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        private string GetLogFilePath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string logFileName = "delivery_log.txt";

            return Path.Combine(desktopPath, logFileName);
        }

        public void Run(string ordersFilePath, string district, DateTime firstDeliveryTime, string resultFilePath)
        {
            try
            {
                var orders = ReadOrdersFromFile(ordersFilePath);
                var filteredOrders = FilterOrders(orders, district, firstDeliveryTime);

                File.WriteAllLines(resultFilePath, filteredOrders.Select(o => $"{o.OrderId},{o.Weight},{o.District},{o.DeliveryTime}"));
                Log("Filtering completed successfully.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
        }
    }
}
