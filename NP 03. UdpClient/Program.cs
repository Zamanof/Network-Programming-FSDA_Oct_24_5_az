using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var connectEndPoint = new IPEndPoint(IPAddress.Loopback, 27001);

List<string> messages = [
    @"__________",
    @"\_________",
    @"/\________",
    @"_/\_______",
    @"__/\______",
    @"___/\_____",
    @"____/\____",
    @"_____/\___",
    @"______/\__",
    @"_______/\_",
    @"________/\",
    @"_________/"
];

var i = 0;
byte[] bytes = null!;

while (true)
{
    bytes = Encoding.UTF8.GetBytes(messages[i++ % messages.Count]);
    client.Send(bytes, bytes.Length, connectEndPoint);
    Thread.Sleep(100);
}
