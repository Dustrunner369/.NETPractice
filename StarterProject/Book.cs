namespace StarterProject;

public class Book
{
    //Member Variables
    public String Title { get; set; }
    public double Price { get; set; } 
    public String Author { get; set; }  
    public String Description { get; set; }
    public int Rank { get; set; }
    public String AmazonURL { get; set; }
    public String ImageURL { get; set; }

    public Book(String title, double price, String author, String description, int rank, String amazonURL, String imageURL)
    {
        Title = title;
        Price = price;
        Author = author;
        Description = description;
        Rank = rank;
        AmazonURL = amazonURL;
        ImageURL = imageURL;
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