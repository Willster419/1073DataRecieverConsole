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
            newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            newsock.Bind(ipep);
            EndPoint Remote = (EndPoint)(ipep);
            String c;
            int crecv;
            byte[] cdata;
            IPEndPoint cipep = new IPEndPoint(IPAddress.Any, 1166);
            Socket cnewsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            cnewsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            cnewsock.Bind(cipep);
            EndPoint cRemote = (EndPoint)(cipep);
            while (true)
          {
                data = new byte[1024];
                recv = newsock.ReceiveFrom(data, ref Remote);
                s = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(s.Substring(35,75));//only what we need to see
                cdata = new byte[1024];
                crecv = cnewsock.ReceiveFrom(cdata, ref cRemote);
                c = Encoding.ASCII.GetString(cdata, 0, crecv);

                //Console.ReadLine(); //this will pause the console
                //Console.WriteLine(c); //we dont want to do this quite yet
            }
        }
    }
}
