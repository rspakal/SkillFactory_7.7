using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal class Product
    {
        string _name;
        int _quantity;
        public Product(string name, int quantity)
        {
            _name = name;
            _quantity = quantity;
        }
        internal string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        internal int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public static Product operator - (Product product1, Product product2) 
        {
            if (product1.Name == product2.Name) 
            {
                product1.Quantity -= product2.Quantity;
            }
            return product1;
        }
    }
    internal class ProductCollection
    {
        internal List <Product> products;
        public ProductCollection(List <Product> products) 
        {
            this.products = products;
        }
        public Product this [string name]
        { 
            get 
            {
                for (int i = 0; i < products.Count; i++) 
                {
                    if (products[i].Name == name) return products[i];
                }
                Console.WriteLine("There is no {0} in the shop", name);
                return new Product (default,default);
            }
            set
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name == name) products[i] = value;
                }
            }
        }
        internal static void ChangeProductQuantity(Product productInShop, Product productInOrder)
        {
            productInShop = productInShop - productInOrder; 
        }
    }

}
