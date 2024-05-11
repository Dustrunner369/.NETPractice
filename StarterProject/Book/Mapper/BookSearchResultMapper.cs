using Newtonsoft.Json.Linq;

namespace StarterProject.Mapper;

public class BookSearchResultMapper
{
    
    // if complicated object, may call other methods to parse or clean specific fields
    //      static because this object does not require state.  If it was a builder instead of a mapper
    //      it may require state and an instance would be instantiated 
    public static BookSearchResult MapFromResponseData(dynamic data)
    {
        // acquiring a reference to a list of dynamics to be able to use linq to map bookList instead of foreach loop
        JArray bookDataList = data.books;
        
        // using select to map to different return type
        List<Book> bookList = bookDataList.Select(b => BookMapper.MapToBook(b)).ToList();

        DateTime bestSellerDate = DateTime.Parse(data.bestsellers_date.ToString());

        // using the default constructor, I can construct the item here using the setters similar to a builder pattern 
        return new BookSearchResult()
        {
            ListName = data.list_name,
            ListNameEncoded = data.list_name_encoded ?? "" ,
            BestSellersDate = bestSellerDate,
            Updated = data.updated ?? "",
            DisplayName = data.display_name ?? "" ,
            Books = bookList
        };
    }

    
}