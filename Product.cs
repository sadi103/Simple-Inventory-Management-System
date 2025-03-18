using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTS.SimpleInventoryManagementSystem
{
    public class Product
    {
        private string name = String.Empty;
        public int AmountInStock { get; set; }

        public decimal Price { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public Product(string name, int quantity, decimal productPrice)
        {
            Name = name;
            AmountInStock = quantity;
            Price = productPrice;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Quantity: {AmountInStock}, Price: {Price}";
        }
    }
}
