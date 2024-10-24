using Orders.Model;

namespace Orders
{
    internal class DeliveryApp
    {
        public List<Order> ReadOrdersFromFile(string filePath)
        {
            var orders = new List<Order>();
            try
            {
                string allText = File.ReadAllText(filePath);
                var parts = allText.Split(',');

                // проверяем, что количество частей кратно 4 т.к. каждая запись состоит из 4 частей
                if (parts.Length % 4 != 0)
                {
                    Log("Invalid data format: incorrect number of fields.");

                    return orders;
                }

                for (int i = 0; i < parts.Length; i += 4)
                {
                    if (!double.TryParse(parts[i + 1], out double weight) || !DateTime.TryParse(parts[i + 3], out DateTime deliveryTime))
                    {
                        Log("Invalid data format: unable to parse weight or delivery time.");
                        continue;
                    }

                    orders.Add(new Order
                    {
                        OrderId = parts[i],
                        Weight = weight,
                        District = parts[i + 2],
                        DeliveryTime = deliveryTime
                    });
                }
            }
            catch (Exception ex)
            {
                Log($"Error reading file: {ex.Message}");
            }

            return orders;
        }

        public List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            DateTime endTime = firstDeliveryTime.AddMinutes(30); // 30 минут после первого заказа

            return orders.Where(x => x.District == district && x.DeliveryTime >= firstDeliveryTime && x.DeliveryTime <= endTime).ToList();
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

                File.WriteAllLines(resultFilePath, filteredOrders.Select(x => $"{x.OrderId},{x.Weight},{x.District},{x.DeliveryTime}"));
                Log("Filtering completed successfully.");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
        }
    }
}
