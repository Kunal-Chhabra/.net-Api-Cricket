using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cricket1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly cricketContext _cricket;
        public MatchesController(cricketContext cricketcs)
        {
            _cricket = cricketcs;
        }
        // GET: api/Country
        [HttpGet]
        public IActionResult Get2()
        {
            var country = _cricket.Matches.ToList();
            return Ok(country);
        }
        // GET: api/Matches
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET: api/Matches/5
         [HttpGet("{id}", Name = "Get")]
         public string Get(int id)
         {
             return "value";
         }

         // POST: api/Matches
         [HttpPost]
         public void Post([FromBody] string value)
         {
         }

         // PUT: api/Matches/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE: api/ApiWithActions/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
