public class Address
{
    private string street;
    private string city;
    private string country;

    public Address(string street, string city, string country)
    {
        this.street = street;
        this.city = city;
        this.country = country;
    }


    public string GetFullAddress()
    {
        return $"{street}, {city}, {country}";
    }
}
