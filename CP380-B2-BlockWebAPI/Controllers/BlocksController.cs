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
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        // TODO

        public BlockList list_b;

        public BlocksController(BlockList blockList)
        {
            list_b = blockList;
        }


        [HttpGet("/blocks")]
        public IActionResult Get()
        {
            return Ok(list_b.Chain.Select(b => new Blocks()
            {
                Hash = b.Hash,
                PreviousHash = b.PreviousHash,
                TimeStamp = b.TimeStamp,
                Nonce = b.Nonce
            })); ;
        }

        
        [HttpGet("{hash}")]
        public IActionResult GetBlock(string hash)
        {
            var block = list_b.Chain
                .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(b => new Blocks()
                    {
                        Hash = b.Hash,
                        PreviousHash = b.PreviousHash,
                        TimeStamp = b.TimeStamp,
                        Nonce = b.Nonce
                    }
                    )
                    .First());
            }

            return null;
        }

        [HttpGet("/payloads")]
        public IActionResult GetBlockPayload(string Hash)
        {
            var block = list_b.Chain
                        .Where(block => block.Hash.Equals(Hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => block.Data
                    )
                    .First());
            }

            return null;
        }
    }
}
