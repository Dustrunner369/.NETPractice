namespace StarterProject.Views;

public class SingleBookView : IView
{
    public BookSearchResult bookSearchResult { get; set; }

    public void Output(BookSearchResult data)
    {
        bookSearchResult = data;
        
        Console.WriteLine($@"
            The current best book right now is {data.Books[0].Title} written by {data.Books[0].Author}.
            Purchase this book today at {data.Books[0].AmazonLink}
        ");
    }
}