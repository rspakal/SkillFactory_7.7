using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal class Order <TDelivery> where TDelivery : Delivery 
    {
        internal Product product;
        internal TDelivery delivery;
        public Order(Product product, TDelivery delivery) 
        {
            this.product = product;
            this.delivery = delivery;
        }
        internal void ShowOrderInfo()
        {
            delivery.CalculateDeliveryPrice();
            Console.WriteLine("U ordered {0} pieces of {1}", product.Quantity, product.Name);
            Console.WriteLine("Ur order will be delivered in {0} days by {1}", delivery.term, delivery.type);
            Console.WriteLine("The price of delivery is {0}", delivery.price);
        }
    }
}
