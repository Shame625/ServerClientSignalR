using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuricaInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace JuricaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHubContext<Info> _info;
        public ValuesController(IHubContext<Info> info)
        {
            _info = info;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var model = new InfoModel { Time = DateTime.Now, Message = "Pozdrav, iz ApiKontrolera"};
            await _info.Clients.All.SendAsync("ReciveInfo", JsonConvert.SerializeObject(model));

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
