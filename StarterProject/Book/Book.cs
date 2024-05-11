namespace StarterProject;

public class Book
{
    // If you want to get rid of the ide warning for uninitialize non-nullable value assign empty string 
    //      public String Title { get; set; } = ""; 
    public String Title { get; set; }
    public double Price { get; set; } 
    public String Author { get; set; }
    public String Description { get; set; }
    public int Rank { get; set; }
    public String AmazonLink { get; set; }
    public String ImageLink { get; set; }
}