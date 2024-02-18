using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CG.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;

        public MovieController(ILogger<MovieController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new MovieManager(options).Load();
        }

        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return new MovieManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Insert(movie, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Update(movie, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
