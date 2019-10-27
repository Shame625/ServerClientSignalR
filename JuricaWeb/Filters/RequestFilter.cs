using JuricaInfrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuricaWeb.Filters
{
    public class RequestFilter : IActionFilter
    {
        private readonly IHubContext<Info> _info;
        public RequestFilter(IHubContext<Info> info)
        {
            _info = info;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var model = new InfoModel { Time = DateTime.Now, Message = context.HttpContext.Request.Path.ToString() };
            _info.Clients.All.SendAsync("ReciveInfo", JsonConvert.SerializeObject(model));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
