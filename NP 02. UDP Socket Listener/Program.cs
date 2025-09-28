using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress.TryParse("127.0.0.1", out var ipAddress);
var port = 27001;

Socket listener = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp
    );

var connectEp = new IPEndPoint(ipAddress!, port);

listener.Bind(connectEp);

EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

var buffer = new byte[ushort.MaxValue];

while (true)
{
    var length = listener.ReceiveFrom(buffer, ref endPoint);
    var message = Encoding.Default.GetString(buffer, 0, length);
    Console.Write(message);
}





