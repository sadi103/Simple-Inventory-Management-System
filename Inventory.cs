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

        public void EditProduct(string name)
        {
            Product? product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write($"Current product name: {product.Name}. Enter new name (or press enter to keep the same): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                product.Name = newName;
            }

            Console.Write($"Current product quantity: {product.AmountInStock}. Enter new quantity (or press enter to keep the same): ");
            string newQuantityInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newQuantityInput) && int.TryParse(newQuantityInput, out int newQuantity))
            {
                product.AmountInStock = newQuantity;
            }

            Console.Write($"Current prdouct price: {product.Price}. Enter new price (or press enter to keep the same): ");
            string newPriceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice))
            {
                product.Price = newPrice;
            }

            Console.WriteLine("Product updated successfully!");
        }
    }
}
