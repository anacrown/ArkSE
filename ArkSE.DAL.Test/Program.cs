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
            while (true)
            {
                try
                {
                    var gs = GameServer.Create("46.251.238.159:27017");

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
