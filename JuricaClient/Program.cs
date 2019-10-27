using JuricaInfrastructure;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;

namespace JuricaClient
{
    class Program
    {
        private static void Main(string[] args)
        {
            var Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:59686/InfoHub")
                .Build();

            Connection.StartAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            Connection.On<string>("ReciveInfo", obj => {

                var deserializedObj = JsonConvert.DeserializeObject<InfoModel>(obj);
                Console.WriteLine(deserializedObj.ToString());
            });



            Console.Read();
            Connection.StopAsync().Wait();
        }
    }
}
