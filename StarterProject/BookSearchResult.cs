using System.Runtime.InteropServices.JavaScript;

namespace StarterProject;

public class BookSearchResult
{
    public String ListName { get; set; }
    public List<String> Books { get; set; }

    public BookSearchResult(List<String> books)
    {
        //this.ListName = listName;
        this.Books = books;
    }
    
}