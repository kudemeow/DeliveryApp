using Orders.Model;

namespace Orders
{
    internal class ReadingFromFile
    {
        public static List<Order> ReadOrdersFromFile(string path)
        {
            var orders = new List<Order>();

            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(',');

                if (parts.Length != 4)
                {
                    Logging.Log("Invalid data format");
                    continue;
                }

                if (!double.TryParse(parts[1], out double weight) || !DateTime.TryParse(parts[3], out DateTime deliveryTime))
                {
                    Logging.Log("Invalid data format");
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
    }
}
