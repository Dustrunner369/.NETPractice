using Newtonsoft.Json;
using StarterProject;
using StarterProject.Mapper;

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
            
            // TODO: Mathew Review --- Response To Question 
            // TODO:    A Dynamic object is similar to a json object or javascript/python/undefined dynamic object
            // TODO:        you don't have to know the fields ahead of time and create the contracts like a traditional
            // TODO:        class. In this case we're accepting a unknown type of object non-predefined fields
            // TODO:        - It's a useful tool when used correctly, but try not to abuse it and develop hard to read 
            // TODO:          code 
            var responseObject = JsonConvert.DeserializeObject<dynamic>(message); 
            
            BookSearchResult searchResult = BookSearchResultMapper.MapFromResponseData(responseObject.results);
            
            Console.WriteLine($@"
                    List Name:         {searchResult.ListName}
                    Display Name:      {searchResult.DisplayName}
                    Best Seller Date:  {searchResult.BestSellersDate}
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