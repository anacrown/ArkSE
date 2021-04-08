using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ArkSE.DAL.SourceQuery;

namespace ArkSE.DAL.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "46.251.238.159:27017";

            var addressParts = address.Split(':');

            while (true)
            {
                try
                {
                    var gs = addressParts.Length == 1
                        ? new GameServer(IPAddress.Parse(address))
                        : new GameServer(new IPEndPoint(IPAddress.Parse(addressParts[0]),
                            int.Parse(addressParts[1])));

                    Console.WriteLine(gs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Нет ответа от сервера..");
                }

                Thread.Sleep(TimeSpan.FromSeconds(3));
                Console.Clear();
            }
        }
    }
}
