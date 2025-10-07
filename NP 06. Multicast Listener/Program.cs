using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var multicastIp = IPAddress.Parse("224.0.0.1");

listener.JoinMulticastGroup(multicastIp);

var endPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var receiveBuffer = listener.Receive(ref endPoint);
    var messages = Encoding.UTF8.GetString(receiveBuffer);
    
    Console.Clear();
    Console.WriteLine(messages);
}
