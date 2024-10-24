using Orders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class Filtering
    {
        public static List<Order> FilterOrders(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            DateTime endTime = firstDeliveryTime.AddMinutes(30);

            return orders.Where(x => x.District == district && x.DeliveryTime >= firstDeliveryTime && x.DeliveryTime <= endTime).ToList();
        }
    }
}
