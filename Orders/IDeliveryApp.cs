using Orders.Model;

namespace Orders
{
    internal interface IDeliveryApp
    {
        List<Order> ReadOrdersFromFile(string filePath);
        List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime);
        void Log(string message);
        void Run(string ordersFilePath, string district, DateTime firstDeliveryTime, string resultFilePath);
    }
}
