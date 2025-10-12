using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

TcpListener listener = default;
var port = 27001;
var ip = IPAddress.Parse("10.2.22.1");

ConcurrentBag<TcpClient> clients = new();

listener = new TcpListener(ip, port);

listener.Start();

Console.WriteLine($"Listening on {listener.LocalEndpoint}");

_ = Task.Run(() =>
{
	while (true)
	{
		var message = Console.ReadLine();
		foreach (var client in clients)
		{
			try
			{
				var stream = client.GetStream();
				var bw = new BinaryWriter(stream);

				bw.Write(message!);
				bw.Flush();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Client send message failed. Skipping.");
			}
		}

	}
});

while (true)
{
    var client = listener.AcceptTcpClient();
    clients.Add(client);
    Console.WriteLine($"{client.Client.RemoteEndPoint} connected");
    
	_ = Task.Run(() =>
    {
		try
		{
			var stream = client.GetStream();
			var br = new BinaryReader(stream);
			while (true)
			{
				var message = br.ReadString();
                Console.WriteLine($"{client.Client.RemoteEndPoint}: {message}");
			}
		}
		catch (Exception ex)
		{
            Console.WriteLine($"Client {client.Client.RemoteEndPoint} disconnected");
		}

    });
}




