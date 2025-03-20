namespace FTS.SimpleInventoryManagementSystem;

public class ApplicationRunner
{
    private readonly Inventory _inventory = new();

    public void Run()
    {
        DisplayHeader();

        while (true)
        {
            DisplayChoices();

            var choiceInput = Console.ReadLine();

            int.TryParse(choiceInput, out int choice);

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    _inventory.ViewProducts();
                    break;
                case 3:
                    EditProduct();
                    break;
                case 4:
                    DeleteProduct();
                    break;
                case 5:
                    SearchProduct();
                    break;
                case 6:
                    Console.WriteLine("Exitting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    public void DisplayHeader()
    {
        Console.WriteLine("**************************************");
        Console.WriteLine("******** Inventory Management ********");
        Console.WriteLine("**************************************");
        Console.WriteLine();
    }

    public void DisplayChoices()
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

    public void AddProduct()
    {
        Console.Write("Enter product name: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
        {
            Console.WriteLine("Invalid product name! It must contain only alphabetic characters and cannot be empty.");
            return;
        }

        Console.Write("Enter product quantity: ");
        if(!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity! It must be a non-negative integer.");
            return;
        }

        Console.Write("Enter product price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
        {
            Console.WriteLine("Invalid price! It must be a non-negative decimal value.");
            return;
        }

        var product = new Product(name, quantity, price);
        _inventory.AddProduct(product);
    }

    public string? InputProductName()
    {
        Console.Write("Enter product name: ");
        var name = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
        {
            Console.WriteLine("Invalid product name. Enter an alphabetical string.");
            return null;
        }

        return name;
    }

    public void EditProduct()
    {
        var name = InputProductName();
        if (name is not null)
        {
            _inventory.EditProduct(name);
        }
    }

    public void DeleteProduct()
    {
        var name = InputProductName();
        if (name is not null)
        {
            _inventory.DeleteProduct(name);
        }
    }

    public void SearchProduct()
    {
        var name = InputProductName();
        if (name is not null)
        {
            _inventory.SearchProduct(name);
        }
    }
}
