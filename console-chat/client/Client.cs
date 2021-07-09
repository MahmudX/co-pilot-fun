using System;
using System.Net.Sockets;
using System.IO;

class Client
{
    static void Main()
    {
        Console.Title = "Chat Client";
        TcpClient client = new TcpClient();
        bool status = true;
        try
        {
            client.Connect("localhost", 1234);
            Console.WriteLine("Connected to server");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        // new netstream
        NetworkStream stream = client.GetStream();
        // new reader
        StreamReader reader = new StreamReader(stream);
        // new writer
        StreamWriter writer = new StreamWriter(stream);
        try
        {
            string clientMessage = "";
            string serverMessage = "";
            while (status)
            {
                Console.Write("Client: ");
                clientMessage = Console.ReadLine();
                if (clientMessage == "exit"
                    || clientMessage == "quit")
                {
                    status = false;
                    writer.WriteLine(clientMessage);
                    writer.Flush();
                    break;
                }
                else
                {
                    writer.WriteLine(clientMessage);
                    writer.Flush();
                    serverMessage = reader.ReadLine();
                    Console.WriteLine("Server: " + serverMessage);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            client.Close();
            writer.Close();
            reader.Close();
        }
    }
}


