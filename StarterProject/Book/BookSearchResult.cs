using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
namespace StarterProject;

public class BookSearchResult
{
    public String ListName { get; set; }
    public List<Book> Books { get; set; }
    public JObject ResponseData { get; set; }
    public BookSearchResult(JObject responseData)
    {
        ResponseData = responseData;
        ListName = (string)ResponseData["list_name"];
        
        //Loop through all books and create a list of Book objects
        Books = new List<Book>();
        JArray booksArray = (JArray)responseData["books"];
        foreach (var item in booksArray)
        {
            Books.Add(new Book((string)item["title"], (double)item["price"], (string)item["author"], 
                (string)item["description"], (int)item["rank"],(string)item["amazon_product_url"], (string)item["book_image"]));
        }
    }
}