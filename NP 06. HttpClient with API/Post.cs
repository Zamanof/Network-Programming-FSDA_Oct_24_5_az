using System.Text.Json.Serialization;

public class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("body")]
    public string Message { get; set; }

    public override string ToString()
    {
        return $"""
                    Id: {Id}
                Title: {Title}
            Body: {Message}

            """;
    }
}
