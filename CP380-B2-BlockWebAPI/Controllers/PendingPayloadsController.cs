using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private Pendingpay pendingp1;
        public PendingPayloadsController(Pendingpay pendingp)
        {
            pendingp1 = pendingp;
        }

        [HttpGet("/getpending")]
        public IActionResult Get()
        {
            return Ok(pendingp1.Payloads);
        }

        [HttpPost("/postpending")]
        public IActionResult Post(Payload payload)
        {
            pendingp1.Payloads.Add(payload);
            return Ok();
        }
    }
}
