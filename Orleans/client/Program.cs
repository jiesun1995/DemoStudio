using Interfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const int initializeAttemptsBeforeFailing = 5;
        private static int attempt = 0;
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }
        public static async Task<int> RunMainAsync()
        {
            try
            {
                using (var client=await StartClientWithRetries())
                {
                    await DoClientWork(client);
                    Console.ReadKey();
                }
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return 1;
            }
        }
        private static async Task<IClusterClient> StartClientWithRetries()
        {
            attempt = 0;
            IClusterClient client;
            client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();
            await client.Connect(RetryFilter);
            Console.WriteLine();
            return client;
        }
        private static async Task<bool> RetryFilter(Exception exception)
        {
            if (exception.GetType() != typeof(SiloUnavailableException))
            {
                Console.WriteLine($"Cluster client failed to connect to cluster with unexpected error.  Exception: {exception}");
                return false;                
            }
            attempt++;
            Console.WriteLine($"Cluster client attempt {attempt} of {initializeAttemptsBeforeFailing} failed to connect to cluster. Exception: {exception}");
            if (attempt > initializeAttemptsBeforeFailing)
            {
                return false;
            }
            await Task.Delay(TimeSpan.FromSeconds(4));
            return true;
        }

        private static async Task DoClientWork(IClusterClient client)
        {
            var friend = client.GetGrain<IMath>(0);
            var t1 = Task.Factory.StartNew(async () =>
            {
                await Add(client);
            });
            var t2 = Task.Factory.StartNew(async () =>
            {
                await Add(client);
            });
            var t3 = Task.Factory.StartNew(async () =>
            {
                await Add(client);
            });

            Task.WaitAll(t1, t2, t3);
            
            await Task.Delay(400);
            var count = await friend.CountAsync();
            Console.WriteLine("\n\n{0}\n\n",count);
        }

        private static async Task Add(IClusterClient client)
        {
            var test = client.GetGrain<IMath>(0);
            for (int i = 0; i < 200; i++)
            {
                await test.AddAsync();
            }            
        }
    }
}
