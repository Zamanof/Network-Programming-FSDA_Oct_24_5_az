using System.Text.Json;

var client = new HttpClient();

var uri = new Uri("https://jsonplaceholder.typicode.com/posts");

var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = uri
};


//var response = await client.SendAsync(message);
// .GetAsync(), PostAsync(), PutAsync(), PatchAsync(), DeleteAsync()
var response = await client.GetAsync(uri);

var json = await response.Content.ReadAsStringAsync();

var posts = JsonSerializer.Deserialize<List<Post>>(json);

posts!.ForEach(Console.WriteLine);