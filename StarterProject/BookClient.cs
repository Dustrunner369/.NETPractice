using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StarterProject;
using JsonSerializer = System.Text.Json.JsonSerializer;

public static class BookClient
{
    static void Main(string[] args)
    {
        ProcessApiAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-nonfiction.json?api-key=uGE5wW9ZHA9FGPtClBiABUICnPNrvt2w").Wait();
    }
    public static async Task ProcessApiAsync(string apiUrl)
    {
        try
        {
            // TODO: Review Notes -- Here is a quick and dirty way to work with responses
            // TODO:       To make re-useable and marshal what you receive and how it is used, 
            //              you would create a class defining the objects, the My Api Respones 
            //              should be in it's own file. You were not able to deserialize to your MyApiResponse
            //              object because you didn't know the structure.  
            //              I used postman to make the request and look at the structure of the response
            //              I didn't want to create the class because I was just looking at the fields so 
            //              a dynamic object to go through temporary data was faster. If this is a program 
            //              your going to use a lot create the response object and sub objects, 
            //              then dserialize to those objects

            //              Clean Coding habits, naming conventions are not bad,  good job. Check out the block of 
            //              testing code below for a quick example 
            //              -- uncomment out the console.writeLines to view the data without going to postman 

            // TODO:  Test Block - for review 
            HttpClient client2 = new HttpClient();
            HttpResponseMessage repo = await client2.GetAsync(apiUrl);

            string message = await repo.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<dynamic>(message); // What is the <dynamic> part of this line?
             
            
            //QUESTION
            // what is the difference between JsonConvert.DeserializeObject and JsonSerializer.Deserialize<MyApiResponse>(json, options);
            
            
            //Create a BookSearchResult object which stores data about the search including a list of books
            BookSearchResult mySearchResult = new BookSearchResult(responseObject.results);
            
            foreach (var book in mySearchResult.Books)
            {
                Console.WriteLine(book.ToString());
            }
            
            
            //TODO: End of code block 
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}