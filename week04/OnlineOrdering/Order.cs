public class Order
{
    private string productName;
    private int quantity;
    private Customer customer;

    public Order(string productName, int quantity, Customer customer)
    {
        this.productName = productName;
        this.quantity = quantity;
        this.customer = customer;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Order Details:");
        Console.WriteLine($"Customer: {customer.GetName()}");
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Quantity: {quantity}");
        Console.WriteLine($"Shipping Address: {customer.GetAddress().GetFullAddress()}");
    }
}
