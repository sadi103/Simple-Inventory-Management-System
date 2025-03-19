namespace FTS.SimpleInventoryManagementSystem;

public class Inventory
{
    public List<Product> Products { get; } = [];

    public void AddProduct(Product product)
    {
        try
        {
            Products.Add(product);
            Console.WriteLine("Product added successfully!");
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding product: {ex.Message}");
        }
    }

    public void ViewProducts()
    {
        Console.WriteLine();

        if (Products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("Inventory List:");
        foreach (var product in Products)
        {
            Console.WriteLine(product);
        }
    }

    public void EditProduct(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write($"Current product name: {product.Name}. Enter new name (or press enter to keep the same): ");
        var newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            product.Name = newName;
        }

        Console.Write($"Current product quantity: {product.AmountInStock}. Enter new quantity (or press enter to keep the same): ");
        var newQuantityInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newQuantityInput) && int.TryParse(newQuantityInput, out int newQuantity))
        {
            product.AmountInStock = newQuantity;
        }

        Console.Write($"Current prdouct price: {product.Price}. Enter new price (or press enter to keep the same): ");
        var newPriceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice))
        {
            product.Price = newPrice;
        }

        Console.WriteLine("Product updated successfully!");
    }
        
    public void DeleteProduct(string name)
    {
        var index = Products.FindIndex(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
        if (index is not -1)
        {
            Products.RemoveAt(index);
            Console.WriteLine($"Successfully deleted the {name.ToLower()} product");
        }
        else
        {
            Console.WriteLine("Product was not found");
        }
    }

    public void SearchProduct(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.WriteLine("\nSearch Result:");
        Console.WriteLine(product);
    }
}
