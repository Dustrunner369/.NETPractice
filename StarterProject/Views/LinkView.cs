namespace StarterProject.Views;

public class LinkView : IView
{
    public BookSearchResult bookSearchResult { get; set; }
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