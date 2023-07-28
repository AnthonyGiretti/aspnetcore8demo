var product1 = new Product(); // Gives: Name = "Default", CategoryId = -1
var product2 = new Product("Basic"); // Gives: Name = "Basic", CategoryId = 0
var product3 = new Product("My product", 1); // Gives: Name = "Default", CategoryId = -1

Console.ReadLine();

public class Product(string name, int categoryId)
{
    public Product() : this("Default", -1) { ProductDescription = "InvalidProductId"; }
    public Product(string name) : this(name, 0) { }

    public string Name => name;
    public int CategoryId => categoryId;
    public string ProductDescription { get; private set; }
}

public record struct Product2(string Name)
{
    public Product2() : this("Disk") { CategoryId = int.MinValue; } // Uses internally the primary constructor

    public Product2(int categoryId) : this("Disk") { CategoryId = categoryId; } // Uses internally the primary constructor

    public int CategoryId { get; set; } = int.MinValue;
}