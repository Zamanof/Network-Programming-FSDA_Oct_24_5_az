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
    var login = request.QueryString["login"];
    var password = request.QueryString["password"];
    StreamWriter writer = new StreamWriter(response.OutputStream);
    Console.WriteLine(request.HttpMethod);
    if (login == "admin" && password == "admin")
    {
        writer.Write($"Welcome {login}");
    }
    else
    {
        writer.Write($"Login or password incorrect");
    }

        writer.Close();
}
