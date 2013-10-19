using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace ConsoleReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            int recv;
            byte[] data;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1165);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);
            EndPoint Remote = (EndPoint)(ipep);
            while (true)
            {
                data = new byte[1024];
                recv = newsock.ReceiveFrom(data, ref Remote);
                s = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine( s.Substring(34, 20));
            }
        }
    }
}
