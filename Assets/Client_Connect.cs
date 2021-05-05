using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;



public class Client_Connect : MonoBehaviour
{
    public const String IP = "127.0.0.1";
    public const int PORT = 3020;
    public const String BYTE_FORMAT = "utf-8";
    public const int HEADER_SIZE = 10;
    public const int BYTE_SIZE = 16;

    // Start is called before the first frame update
    void Start()
    {
        StartClient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StartClient()  
    {  
        byte[] bytes = new byte[1024];  
  
        try  
        {  
            // Connect to a Remote server  
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            
            IPHostEntry host = Dns.GetHostEntry("localhost");
            for(int i = 0; i < host.AddressList.Length; i++){
                Debug.Log(host.AddressList[i]);
            }
            
            IPAddress ipAddress = host.AddressList[1];
            //IPAddress ipAddress = IPAddress.Parse(IP);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);

            Debug.Log("Connecting to " + ipAddress + ":" + PORT);

            // Create a TCP/IP  socket.    
            Socket sender = new Socket(ipAddress.AddressFamily,  
                SocketType.Stream, ProtocolType.Tcp);  
  
            // Connect the socket to the remote endpoint. Catch any errors.    
            try  
            {  
                Debug.Log("Starting connect");
                // Connect to Remote EndPoint  
                sender.Connect(remoteEP);  
  
                Debug.Log("All done");
                // Console.WriteLine("Socket connected to {0}",  
                //     sender.RemoteEndPoint.ToString());  
  
                // // Encode the data string into a byte array.    
                // byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");  
  
                // // Send the data through the socket.    
                // int bytesSent = sender.Send(msg);  
  
                // // Receive the response from the remote device.    
                // int bytesRec = sender.Receive(bytes);  
                // Console.WriteLine("Echoed test = {0}",  
                //     Encoding.ASCII.GetString(bytes, 0, bytesRec));  
  
                // // Release the socket.    
                // sender.Shutdown(SocketShutdown.Both);  
                // sender.Close();  
  
            }  
            catch (ArgumentNullException ane)  
            {  
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());  
            }  
            catch (SocketException se)  
            {  
                Console.WriteLine("SocketException : {0}", se.ToString());  
            }  
            catch (Exception e)  
            {  
                Console.WriteLine("Unexpected exception : {0}", e.ToString());  
            }  
  
        }  
        catch (Exception e)  
        {  
            Console.WriteLine(e.ToString());  
        }  
    }  
}
