using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CG.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        // GET: api/<FormatController>
        [HttpGet]
        public IEnumerable<Format> Get()
        {
            return FormatManager.Load();
        }

        // GET api/<FormatController>/5
        [HttpGet("{id}")]
        public Format Get(int id)
        {
            return FormatManager.LoadById(id);
        }

        // POST api/<FormatController>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Format format, bool rollback = false)
        {
            return FormatManager.Insert(format, rollback);
        }

        // PUT api/<FormatController>/5
        [HttpPut("{id}/{rollback?}")]
        public int Put(int id, [FromBody] Format format, bool rollback = false)
        {
            return FormatManager.Insert(format, rollback);
        }

        // DELETE api/<FormatController>/5
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(int id, bool rollback = false)
        {
            return FormatManager.Delete(id, rollback);
        }
    }
}
