using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTS.SimpleInventoryManagementSystem
{
    class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully!");
        }

        public void ViewProducts()
        {
            Console.WriteLine();

            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return;
            }

            Console.WriteLine("Inventory List:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
