﻿using FTS.SimpleInventoryManagementSystem;

class Program
{
    static Inventory inventory = new();

    static void Main()
    {

        DisplayHeader();

        while (true)
        {
            DisplayChoices();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    inventory.ViewProducts();
                    break;
                case "3":
                    EditProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    SearchProduct();
                    break;
                case "6":
                    Console.WriteLine("Exitting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void DisplayHeader()
    {
        Console.WriteLine("**************************************");
        Console.WriteLine("******** Inventory Management ********");
        Console.WriteLine("**************************************");
        Console.WriteLine();
    }

    static void DisplayChoices()
    {
        Console.WriteLine();
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Edit a product");
        Console.WriteLine("4. Delete a product");
        Console.WriteLine("5. Search for a product");
        Console.WriteLine("6. Exit");

        Console.Write("Choose an option: ");
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter product price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        inventory.AddProduct(new Product(name, quantity, price));
    }

    static string GetProductName()
    {
        Console.Write("Enter product name: ");
        return Console.ReadLine().Trim();
    }

    static void EditProduct()
    {
        string name = GetProductName();
        inventory.EditProduct(name);
    }

    static void DeleteProduct()
    {
        string name = GetProductName();
        inventory.DeleteProduct(name);
    }

    static void SearchProduct()
    {
        string name = GetProductName();
        inventory.SearchProduct(name);
    }
}
