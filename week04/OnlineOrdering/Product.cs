public class Product
{
    private string productName;
    private double price;

    public Product(string productName, double price)
    {
        this.productName = productName;
        this.price = price;
    }

    public string GetProductName() { return productName; }
    public double GetPrice() { return price; }
}
