using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

client.MulticastLoopback = true;

var ip = IPAddress.Parse("224.0.0.1");
var endPoint = new IPEndPoint(ip, 27001);

var minutes = 0;
var seconds = 0;

var clock = string.Empty;

while (true)
{
    if (seconds == 60)
    {
        seconds = 0;
        minutes++;
    }
    
    if (seconds < 10) clock = $"0{minutes}:0{seconds}";
    else clock = $"0{minutes}:{seconds}";

    var data = Encoding.UTF8.GetBytes(clock);
    client.Send(data, data.Length, endPoint);
    Thread.Sleep(TimeSpan.FromSeconds(1));
    seconds++;
}
