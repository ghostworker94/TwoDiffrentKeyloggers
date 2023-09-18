using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Nätverksimplementering
{
    static void Network()
    {
        // Skapa en TCP-anslutning till en server
        TcpClient client = new TcpClient("Server IP", 12345); // Ändra "serverIP" till serverns IP-adress och portnummers

        // Skapa en ström för att skicka och ta emot data
        NetworkStream stream = client.GetStream();

        // Konvertera text till bytes
        string message = "Hej, detta är ett meddelande!";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Skicka meddelandet
        stream.Write(data, 0, data.Length);

        // Stäng anslutningen
        client.Close();
    }
}
