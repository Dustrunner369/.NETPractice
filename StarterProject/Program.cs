using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

public static class Program
{
    static void Main(string[] args)
    {
        ProcessApiAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=uGE5wW9ZHA9FGPtClBiABUICnPNrvt2w").Wait();
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
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON response
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Ignore case when deserializing
                    };

                    // Deserialize JSON to a specific class or anonymous object
                    var data = JsonSerializer.Deserialize<MyApiResponse>(json, options);
                    
                    // Access properties of the deserialized object
                    Console.WriteLine($"API response received: {data.Message}");
                    Console.WriteLine();
                }  
                else
                {
                    Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
public class MyApiResponse
{
    public string Message { get; set; }
}