namespace StarterProject.Views;

public class LinkView : IView
{
    public BookSearchResult bookSearchResult { get; set; }

    
    // TODO: Created additional method to not break existing code.  
    public void Output()
    {
        if (bookSearchResult == null)
        {
            Console.Write("Nothing to output");
            return; 
        }

        Output( bookSearchResult );
    }
    public void Output(BookSearchResult data)
    {
        bookSearchResult = data;

        foreach (Book book in bookSearchResult.Books)
        {
            Console.WriteLine($@"
                Title:          {book.Title}
                Author:         {book.Author}
                Amazon Link:    {book.AmazonLink}
                Image Link:    {book.ImageLink}
            ");
        }
    }
}