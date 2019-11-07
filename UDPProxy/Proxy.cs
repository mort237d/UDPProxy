using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModelLib;

namespace UDPProxy
{
    class Proxy
    {
        private const int PORT = 10100;

        public void Start()
        {
            //"server" egentlig receiver
            UdpClient client = new UdpClient(PORT);

            Console.WriteLine("UDP receiver startet på port " + PORT);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = client.Receive(ref remote);
                string str = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("Modtaget " + str);
                string upperStr = str.ToUpper();
                byte[] buffer = Encoding.UTF8.GetBytes(upperStr.ToCharArray(), 0, upperStr.Length);

                client.Send(buffer, buffer.Length, remote);

                PostSensorDataAsync(str);
            }
        }
        public async void PostSensorDataAsync(string jsonString)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage content = await client.PostAsync("http://localhost:4727/api/sensors", strContent);
            }
        }
    }
}
