using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/// <summary>
/// Class Client Socket
///   Using Synchronous sockets 
///   Written by Kris Sielski
///   9/7/2021
/// </summary>
namespace SocketDev
{
    class ClientSocket
    {

        //member variables
        private readonly Socket tcpSocket = null;


        //Constructor
        public ClientSocket()
        {
            Console.WriteLine("In ClientSocket Constructor");

            //Create IPV4 TCP/IP Socket
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }


        public bool OpenSocket(string ipAddr, int port)
        {

            // Connect to a remote device.  
            try
            {

                IPAddress ipAddress = IPAddress.Parse( ipAddr );
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    tcpSocket.Connect(ipEndPoint);

                    Console.WriteLine("Socket connected to {0}", tcpSocket.RemoteEndPoint.ToString());

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


            return false;
        }

        public void CloseSocket()
        {
            // Release the socket.  
            //tcpSocket.Shutdown(SocketShutdown.Both);

            if( tcpSocket.Connected )
            {
                tcpSocket.Close();
                Console.WriteLine("Socket Closed!");
            }

        }


        public bool SendSocket(byte[] data, int size )
        {

            if (!tcpSocket.Connected) return false;


            try
            {
                int bytesSent = tcpSocket.Send(data,size,SocketFlags.None);
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
                return false;
            }

            return true;
        }



        //ReadSocket - Read ONE byte from a socket
        //Inputs:
        //  data = ref byte to put received data
        //Output:
        //  If data was valid
        public bool ReadSocket(ref byte data )
        {

            //Check if connected
            if (!tcpSocket.Connected) return false;

            // Check if any data available
            if (tcpSocket.Available == 0) return false;


            // Data buffer for incoming data.  
            byte[] bytes = new byte[1];

            try
            {
                // Receive the response from the remote device.  
                //          Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);
                int bytesRec = tcpSocket.Receive(bytes,0,1,SocketFlags.None);

                if (bytesRec == 1)
                {
                    Console.WriteLine("REC = 1!");

                    data = bytes[0];

                    return true;
                }

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
                return false;
            }

            return true;
        }



        //ReadSocket - Read ALL data in a socket
        //Inputs:
        //  data = byte array buffer to put received data
        //Output:
        //  Num Bytes Received
        public int ReadSocket(byte[] data)
        {

            //Check if connected
            if (!tcpSocket.Connected) return 0;

            // Check if any data available
            if (tcpSocket.Available == 0) return 0;


            try
            {
                // Receive the response from the remote device.  
                int bytesRec = tcpSocket.Receive(data);
                return bytesRec;
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

            return 0;
        }


        public bool IsConnected()
        {
            return tcpSocket.Connected;
        }


    }   //End Class ClientSocket
}
