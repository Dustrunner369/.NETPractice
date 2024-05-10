using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StarterProject.obj;
using JsonSerializer = System.Text.Json.JsonSerializer;

public static class Program
{
    static void Main(string[] args)
    {
        ProcessApiAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=uGE5wW9ZHA9FGPtClBiABUICnPNrvt2w").Wait();
        //Tester Code
        // using var client = new HttpClient(); //Why does this line have "using" in it? What does that mean?
        // client.BaseAddress = new Uri("https://httpbin.org/get");
        // //client.BaseAddress = new Uri("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=uGE5wW9ZHA9FGPtClBiABUICnPNrvt2w");
        // // Add an Accept header for JSON format.
        // client.DefaultRequestHeaders.Accept.Add(
        //     new MediaTypeWithQualityHeaderValue("application/json"));
        // // Get data response
        // var response = client.GetAsync(client.BaseAddress).Result;
        // Console.WriteLine("WE are here");
        // if (response.IsSuccessStatusCode)
        // {
        //     // Parse the response body
        //     // var dataObjects = response.Content
        //     //     .ReadAsAsync<IEnumerable<DataObject>>().Result;
        //     // foreach (var d in dataObjects)
        //     // {
        //     //     Console.WriteLine("{0}", d.Name);
        //     // }
        //     
        //     //string json = response.Content.ReadAsStringAsync();
        //     
        //     Console.WriteLine(response);
        // }
        // else
        // {
        //     Console.WriteLine("{0} ({1})", (int)response.StatusCode,
        //         response.ReasonPhrase);
        // }
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
            
            
            Console.WriteLine("Response Object: " + responseObject);
            Console.WriteLine(responseObject.num_results); 
            //Console.WriteLine(responseObject.results); 
            
            // foreach( var book in responseObject.results.books )
            // {
            //     Console.WriteLine( "Book Title: " + book.title  );
            // }
            // TODO: End of code block 
            
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                    return;
                }    
                    
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ignore case when deserializing
                };

                // Deserialize JSON to a specific class or anonymous object
                var data = JsonSerializer.Deserialize<APIResponse>(json, options);
                
                // Access properties of the deserialized object
                Console.WriteLine($"API response received: {data.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}