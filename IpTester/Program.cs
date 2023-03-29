using System.Threading;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Buffers;

namespace main
{
    public class run
    {
        public static void Main(String[] args)
        {
            int aoitc = 0;
            int i = 0;
            Console.Write("> ");
            aoitc = Convert.ToInt32(Console.ReadLine());
            while (i != aoitc)
            {
                Ping pinger = null;
                bool pingable = false;
                var random = new Random();
                var lowerBound = 0;
                var upperBound = 255;
                var rIPs1 = random.Next(lowerBound, upperBound);
                var rIPs2 = random.Next(lowerBound, upperBound);
                var rIPs3 = random.Next(lowerBound, upperBound);
                var rIPs4 = random.Next(lowerBound, upperBound);
                string ip = rIPs1 + "." + rIPs2 + "." + rIPs3 + "." + rIPs4;
                i++;
                try
                {
                    pinger = new Ping();
                    PingReply reply = pinger.Send(ip);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException)
                {
                    if (pinger != null)
                    {
                        pinger.Dispose();
                    }
                }
                Console.WriteLine("{0} | {1}", ip, pingable);
            }
            Console.WriteLine("Done");
        }
    }
}