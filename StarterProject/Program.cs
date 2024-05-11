using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StarterProject;
using StarterProject.Mapper;
using JsonSerializer = System.Text.Json.JsonSerializer;

public static class Program
{
    static void Main(string[] args)
    {
        ProcessApiAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-nonfiction.json?api-key=uGE5wW9ZHA9FGPtClBiABUICnPNrvt2w").Wait();
    }
    public static async Task ProcessApiAsync(string apiUrl)
    {
        try
        { 
            HttpClient client2 = new HttpClient();
            HttpResponseMessage repo = await client2.GetAsync(apiUrl);

            string message = await repo.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(message); // What is the <dynamic> part of this line?
            
            
            // BookSearchResult mySearchResult = new BookSearchResult(responseObject.results);

            BookSearchResult searchResult = BookSearchResultMapper.MapFromResponseData(responseObject.results);
            
            Console.WriteLine($@"
                    List Name:         {searchResult.ListName}
                    Display Name:      {searchResult.DisplayName}
                    Best Seller Date : {searchResult.BestSellersDate}
                    Amount of books:   {searchResult.Books.Count}
                    ----------------------------------------------
            ");
            
            // can format toString to represent the same way if you don't want to type so much
            foreach (var book in searchResult.Books)
            {
                Console.WriteLine($@"
                    Title:          {book.Title}
                    Author:         {book.Author}
                    Price:          {book.Price}
                    Amazon Link:    {book.AmazonLink}
                ");
            }


        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}