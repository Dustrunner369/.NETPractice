namespace StarterProject.Mapper;

public class BookMapper
{
    public static Book MapToBook(dynamic bookData)
    {
        return new Book()
        {
            Title = bookData.title,
            Price = bookData.price,
            Author = bookData.author,
            Description = bookData.description,
            Rank = bookData.rank,
            AmazonLink = bookData.amazon_product_url,
            ImageLink = bookData.book_image
        };
    }
}