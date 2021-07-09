using System;
using System.Net.Sockets;
using System.IO;
using System.Net;

// Create Main method
public class Server
{
    public static void Main(string[] args)
    {
        Console.Title = "Chat Server";
        try
        {
            bool status = true;
            string serverMessage = "";
            string clientMessage = "";
            // new tcp listener
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 1234);
            tcpListener.Start();
            System.Console.WriteLine("Listening...");
            // new socket for incoming connection
            Socket incomingSocket = tcpListener.AcceptSocket();
            System.Console.WriteLine("Accepted connection from: " + incomingSocket.RemoteEndPoint.ToString());
            // new network stream for incoming connection
            NetworkStream networkStream = new NetworkStream(incomingSocket);
            // new stream writer for incoming connection
            StreamWriter streamWriter = new StreamWriter(networkStream);
            // new stream reader for incoming connection
            StreamReader streamReader = new StreamReader(networkStream);

            while (status)
            {
                if (incomingSocket.Connected)
                {
                    serverMessage = streamReader.ReadLine();
                    System.Console.WriteLine("Client: " + serverMessage);
                    if (serverMessage == "exit")
                    {
                        status = false;
                        streamReader.Close();
                        networkStream.Close();
                        streamWriter.Close();
                    }
                    Console.Write("Server: ");
                    clientMessage = Console.ReadLine();
                    streamWriter.WriteLine(clientMessage);
                    streamWriter.Flush();
                }
            }
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
            incomingSocket.Close();
            tcpListener.Stop();
            Console.WriteLine("Connection closed.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}

