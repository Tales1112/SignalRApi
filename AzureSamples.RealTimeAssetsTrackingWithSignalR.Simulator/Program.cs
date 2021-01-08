using AzureSamples.RealTimeAssetsTrackingWithSignalR.Simulator.Model;
using AzureSamples.RealTimeAssetsTrackingWithSignalR.Simulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AzureSamples.RealTimeAssetsTrackingWithSignalR.Simulator
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            List<LocationUpdate> locationUpdates = new List<LocationUpdate>
            {
             new LocationUpdate
                {
                    Latitude = -8.083573,
                    Longitude = -34.919268,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.083626,
                    Longitude = -34.919123,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.083695,
                    Longitude = -34.918909,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.083552,
                    Longitude = -34.918748,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.083313,
                    Longitude = -34.918694,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.082803,
                    Longitude = -34.918560,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                    Latitude = -8.082222,
                    Longitude = -34.918489,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.081507,
                    Longitude = -34.918503,
                    DriverName = "Tales"
                },
             ////////////////////////////////
             new LocationUpdate
                {
                     Latitude = -8.080935,
                    Longitude = -34.918508,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.080861,
                    Longitude = -34.918095,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.080843,
                    Longitude = -34.917874,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.080824,
                    Longitude = -34.917545,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.080795,
                    Longitude = -34.917259,
                    DriverName = "Tales"
                },
             new LocationUpdate
                {
                     Latitude = -8.080811,
                    Longitude = -34.916825,
                    DriverName = "Tales"
                },

            };

            var hubClient = new LiveTrackingClientService();
            await hubClient.Initialize("http://singalapi.azurewebsites.net/live-tracking");

            Observable
            .Interval(TimeSpan.FromSeconds(3))
            .Subscribe(
                async x =>
                {
                    var locationUpdate = locationUpdates.FirstOrDefault();
                    if (locationUpdate != null)
                    {
                        await hubClient.SendHubMessage("location-update", locationUpdate);
                        Console.WriteLine("SENDING LOCATION UPDATE: " + locationUpdate.DriverName + " " + locationUpdate.Latitude + " " + locationUpdate.Longitude);
                        locationUpdates.Remove(locationUpdate);
                    }
                    else
                        Console.WriteLine("UPDATES COMPLETED");
                });

            Console.ReadKey();
        }
    }
}
