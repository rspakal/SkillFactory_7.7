using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal class Customer
    {
        internal string name;
        internal Rubble rubbles;
        internal Euro euro;
        internal Order<Delivery> order;
        public Customer(string name)
        {
            this.name = name;
            order = new Order<Delivery>(new Product(default, default), default);
        }
        internal static void Paying(Customer customer, Payment <Rubble> payment)
        {
           
        }
    }
}
