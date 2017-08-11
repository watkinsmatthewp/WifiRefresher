using SimpleWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WifiRefresher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        private static void Run()
        {
            var wifi = new Wifi();
            if (wifi.NoWifiAvailable)
            {
                Console.WriteLine("No WiFi available");
                return;
            }

            if (wifi.ConnectionStatus == WifiStatus.Disconnected)
            {
                Console.WriteLine("WiFi not connected");
                return;
            }

            var connectedNetwork = wifi.GetAccessPoints().FirstOrDefault(n => n.IsConnected);
            if (connectedNetwork == null)
            {
                Console.WriteLine("Not connected to any WiFi network");
                return;
            }

            if (CanReachInternet())
            {
                Console.WriteLine($"Internet access working");
                return;
            }

            Console.WriteLine($"No internet access detected. Disconnecting from {connectedNetwork.Name}");
            wifi.Disconnect();

            Console.WriteLine("Waiting 15 seconds");
            Thread.Sleep(15000);

            Console.WriteLine($"Reconnecting to {connectedNetwork.Name}");
            connectedNetwork.Connect(new AuthRequest(connectedNetwork));
        }

        private static bool CanReachInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.msftncsi.com/ncsi.txt"))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
