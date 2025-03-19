namespace FTS.SimpleInventoryManagementSystem;

public class Product
{
    private string name = string.Empty;

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
        if (!IsValidObject(name, quantity, productPrice))
        {
            throw new ArgumentException("Invalid product values. Name must be alphabetic, and quantity/price must be non-negative.");
        }

        Name = name;
        AmountInStock = quantity;
        Price = productPrice;
    }

    private bool IsValidObject(string name, int quantity, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
        {
            return false;
        }
        
        if (quantity < 0 || price < 0)
        {
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Quantity: {AmountInStock}, Price: {Price}";
    }
}
