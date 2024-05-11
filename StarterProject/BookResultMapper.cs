using Newtonsoft.Json.Linq;

namespace StarterProject;

public class BookResultMapper
{
    public JObject Data { get; set; }

    public BookResultMapper(JObject data)
    {
        Data = data;
    }
    
    
    
    
}