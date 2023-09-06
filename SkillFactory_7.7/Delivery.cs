using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal abstract class Delivery
    {
        internal string type;
        internal int price;
        internal int term;
        internal Delivery(int price, int term)
        {
            this.price = price;
            this.term = term;
        }
        internal abstract void CalculateDeliveryPrice();
    }
    internal class ShopDelivery : Delivery
    {
        public ShopDelivery (int price, int term) : base (price, term) 
        {
            type = "Shop delivery";
        }
        internal override void CalculateDeliveryPrice() {}
    }
    internal class PickPointDelivery : Delivery
    {
        public PickPointDelivery(int price, int term) : base(price, term) 
        {
            type = "Pick Point delivery";
        }
        internal override void CalculateDeliveryPrice() { }
    }
    internal class HomeDelivery : Delivery
    {
        protected Customer customer;
        internal DeliveryArea deliveryArea;
        public HomeDelivery(int price, int term, Customer customer,DeliveryArea deliveryArea) : base(price, term) 
        {
            type = "Home delivery";
            this.customer = customer;
            this.deliveryArea = deliveryArea;
        }
        internal override void CalculateDeliveryPrice() 
        {
            price = price + deliveryArea.price;
        }
    }
    internal class ExpressHomeDelivery : HomeDelivery
    {
        internal int rate;
        public ExpressHomeDelivery(int price, int term, Customer customer, int rate, DeliveryArea deliveryArea) : base(price, term,customer, deliveryArea) 
        {
            type = "Express Home delivery";
            this.rate = rate;
        }
        internal override void CalculateDeliveryPrice()
        {
            price = price + (deliveryArea.price) * rate;
        }
    }

    class DeliveryArea
    {
        internal string streetName;
        internal int price;
        public DeliveryArea(string streetName, int price)
        {
            this.streetName = streetName;
            this.price = price;
        }
    }
    class DeliveryAreaCollection
    {
        internal List<DeliveryArea> deliveryAreas;
        internal DeliveryAreaCollection(List<DeliveryArea> deliveryAreas)
        {
            this.deliveryAreas = deliveryAreas;
        }
    }
}
