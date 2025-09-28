using System.Net.Sockets;
using System.Net;
using System.Text;

var ipAddress = IPAddress.Parse("127.0.0.1");
var port = 27001;

Socket client = new(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
    );

var endPoint = new IPEndPoint(ipAddress, port);

var message = string.Empty;

try
{
    client.Connect(endPoint);
    if (client.Connected)
    {
        Console.WriteLine("Connected to Server ...");
        while (true)
        {
            message = Console.ReadLine();
            var bytes = Encoding.Default.GetBytes(message!);
            client.Send(bytes);
        }
    }
    else Console.WriteLine("Can not connect to server");
}
catch (Exception)
{
    Console.WriteLine("Can not connect to server");
}
