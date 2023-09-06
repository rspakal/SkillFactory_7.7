using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    enum DeliveryType
    {
        ShopDelivery = 1,
        PickPointDelivery,
        HomeDelivery,
        ExpressHomeDelivery
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DeliveryArea> deliveryAreas = new List<DeliveryArea>()
            {
                new DeliveryArea("Lenina", 500),
                new DeliveryArea("Gorkogo", 500),
                new DeliveryArea("Chehova", 800),
                new DeliveryArea("Pushkina", 800),
                new DeliveryArea("Sadovaya", 1000)
            };
            List<Product> products = new List<Product>()
            {
                new Product("tv",5),
                new Product("iron",4),
                new Product("pc",7),
                new Product("phone",5)
            };

            ProductCollection productCollection = new ProductCollection(products);
            Customer customer = new Customer(default) { rubbles = new Rubble(5000), euro = new Euro(100) };
            Console.WriteLine("Enter UR name");
            customer.name = Console.ReadLine();
            Console.WriteLine("Available products");
            foreach (var item in productCollection.products)
            {
                Console.WriteLine("\t" + item.Name);
            }
            while (customer.order.product.Name == null)
            {
                Console.WriteLine("Choose the product");
               customer.order.product.Name = productCollection[Console.ReadLine().TrimAndToLower()].Name;
            }
            Console.WriteLine(productCollection[customer.order.product.Name].Quantity + " available");
            while (customer.order.product.Quantity <= 0 | customer.order.product.Quantity > productCollection[customer.order.product.Name].Quantity)
            {
                Console.WriteLine("Enter the quantity");
                customer.order.product.Quantity = int.TryParse(Console.ReadLine(), out int quantity) ? quantity : 0;
            }
            Console.WriteLine("Available delivery type");
            Console.WriteLine("\t 1 Shop delivery");
            Console.WriteLine("\t 2 Pick point delivery");
            Console.WriteLine("\t 3 Home delivery");
            Console.WriteLine("\t 4 Express home delivery");
            while (customer.order.delivery == default)
            {
                switch (int.TryParse(Console.ReadLine(), out int result) ? result : 0)
                {
                    case 1:
                        customer.order.delivery = new ShopDelivery(0, 1);
                        break;
                    case 2:
                        customer.order.delivery = new PickPointDelivery(500, 3);
                        break;
                    case 3:

                        customer.order.delivery = new HomeDelivery(1000, 3, customer, default);
                        break;
                    case 4:
                        customer.order.delivery = new ExpressHomeDelivery(1000, 2, customer, 2, default);
                        break;
                    default:
                        Console.WriteLine("Chose correct delivery number");
                        break;
                }

            }
            if (customer.order.delivery.GetType() == typeof(HomeDelivery) | customer.order.delivery.GetType() == typeof(ExpressHomeDelivery))
            {
                Console.WriteLine("Available streets for delivery");
                for (int i = 0; i < deliveryAreas.Count; i++)
                {
                    Console.WriteLine("\t" + (i + 1).ToString() + " " + deliveryAreas[i].streetName);
                }
                while (((HomeDelivery)customer.order.delivery).deliveryArea == default)
                {
                    switch (int.TryParse(Console.ReadLine(), out int result) ? result : 0)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            ((HomeDelivery)customer.order.delivery).deliveryArea = deliveryAreas[result - 1];
                            break;
                        default:
                            Console.WriteLine("Chose correct delivery number");
                            break;
                    }

                }

            }
            customer.order.ShowOrderInfo();
            Console.WriteLine("Paying method");
            Customer.Paying(customer, new PaymentRubble<Rubble>());
            ProductCollection.ChangeProductQuantity(productCollection[customer.order.product.Name], customer.order.product);
            Console.ReadKey();
        }
    }
    internal static class ExtensionString 
    {
       public static string TrimAndToLower(this string s) 
        {
            return s.Trim().ToLower();
        }
    }

}
