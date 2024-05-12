namespace StarterProject.Views;

public class SingleBookView : IView
{
    // TODO: --- HOrrible C# Naming Conventions, bookSearchResult needs to be capped BookSearchResult
    public BookSearchResult bookSearchResult { get; set; }

    
    // TODO: Created additional method to not break existing code.  
    public void Output()
    {
        if (bookSearchResult == null)
        {
            Console.Write("Nothing to output");
            return;
        }
        
        Output(bookSearchResult);
    }

    public void Output(BookSearchResult data)
    {
        bookSearchResult = data;
        
        Console.WriteLine($@"
            The current best book right now is {data.Books[0].Title} written by {data.Books[0].Author}.
            Purchase this book today at {data.Books[0].AmazonLink}
        ");
    }
}