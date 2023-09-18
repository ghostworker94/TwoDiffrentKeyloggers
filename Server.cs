using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void server()
    {
        // Lyssna på en specifik port
        TcpListener server = new TcpListener(IPAddress.Any, 12345); // Välj en ledig port

        // Starta servern
        server.Start();
        Console.WriteLine("Väntar på anslutning...");

        // Acceptera anslutningar från klienter
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Ansluten!");

        // Skapa en ström för att ta emot data
        NetworkStream stream = client.GetStream();

        // Läs data från klienten
        byte[] data = new byte[1024];
        int bytesRead = stream.Read(data, 0, data.Length);
        string message = Encoding.UTF8.GetString(data, 0, bytesRead);

        // Visa meddelandet
        Console.WriteLine("Meddelande mottaget: " + message);

        // Stäng anslutningen
        client.Close();
        server.Stop();
    }
}
