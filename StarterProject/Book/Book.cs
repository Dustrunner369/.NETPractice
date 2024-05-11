namespace StarterProject;

public class Book
{
    //Member Variables
    public String Title { get; set; }
    public double Price { get; set; } 
    public String Author { get; set; }
    public String Description { get; set; }
    public int Rank { get; set; }
    public String AmazonLink { get; set; }
    public String ImageLink { get; set; }

    
    // Created this to show you a cool feature of C#
    public Book()
    {
        
    }

    public Book(String title, double price, String author, String description, int rank, String amazonLink, String imageLink)
    {
        Title = title;
        Price = price;
        Author = author;
        Description = description;
        Rank = rank;
        AmazonLink = amazonLink;
        ImageLink = imageLink;
    }
     
    public String ToString()
    {
        string stringToReturn = "";
        stringToReturn += "Title: " + Title;
        stringToReturn += "\nPrice: " + Price;
        stringToReturn += "\nAuthor: " + Author;
        stringToReturn += "\nDescription: " + Description;
        stringToReturn += "\nRank: " + Rank;
        
        return stringToReturn;
    }
    
}