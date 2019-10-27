using JuricaInfrastructure;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace JuricaWeb
{
    public class InfoHub : Hub
    {
        public async Task Send(InfoModel model)
        {
            await Clients.All.SendAsync("Send", JsonConvert.SerializeObject(model));
        }
    }
}