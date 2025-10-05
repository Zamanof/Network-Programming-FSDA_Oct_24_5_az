using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add("http://localhost:27001/");
listener.Prefixes.Add("http://localhost:27002/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request);
    //Console.WriteLine(request.RawUrl);

    // ?login=moguda&password=123456 -> QueryString
    // (?key1=value1&key2=value2&...
    var rawUrl = request.RawUrl;
    //var queryString = rawUrl.Split('?')[1];
    //var queryString = rawUrl[2..];
    //var datas = queryString.Split("&");
    //for (int i = 0; i < datas.Length; i++)
    //{
    //    var data = datas[i].Split("=");
    //    Console.WriteLine($"{data[0]} -> {data[1]}");
    //}
    var queryString = request.QueryString;

    //foreach (string key in queryString.Keys)
    //{
    //    Console.WriteLine($"{key} -> {queryString[key]}");
    //}

    //response.AddHeader("Content-Type", "text/html");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.Write($"Salam {queryString["login"]}");
    var login = queryString["login"];

    //writer.WriteLine($"<h1 style='color:red;'>Salam {login}</h1>");
    //writer.WriteLine($"<a href='https://google.com/search?q={login}'>Search</a>");
    //writer.WriteLine($"<img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>");
    var html = $"""
        <h1 style='color:red;'>Salam {login}</h1>
        <a href='https://google.com/search?q={login}'>Search</a>
        <img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>
        """;
    writer.WriteLine(html);
    writer.Close();
}
