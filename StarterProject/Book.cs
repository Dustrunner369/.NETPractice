namespace StarterProject;

public class Book
{
    //Member Variables
    public String Name { get; set; }
    public double Price { get; set; } 
    public String AmazonLink { get; set; }
    public String ImageString { get; set; }

    public Book(String name, double price, String amazonLink, String imageString)
    {
        this.Name = name;
        this.Price = price;
        this.AmazonLink = amazonLink;
        this.ImageString = imageString;
    }
}