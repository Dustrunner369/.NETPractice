
namespace StarterProject;

public class BookSearchResult
{
    public string ListName { get; set; }
    public string ListNameEncoded { get; set; }
    public DateTime BestSellersDate { get; set; }
    public string Updated { get; set; } 
    public string DisplayName { get; set; }
    public List<Book> Books { get; set; }
}