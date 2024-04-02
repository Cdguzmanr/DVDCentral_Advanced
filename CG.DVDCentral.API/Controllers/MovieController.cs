using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL2.Data;
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


        /// <summary>
        /// Returns a list of movies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new MovieManager(options).Load();
        }

        /// <summary>
        /// Get a particular movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return new MovieManager(options).LoadById(id);
        }

        /// <summary>
        /// Insert a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns>New Guid</returns>
        [HttpPost("{rollback?}")]
        public Guid Post([FromBody] Movie movie, bool rollback = false)
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

        /// <summary>
        /// Update a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="rollback">Should be rollback the transaction</param>
        /// <returns></returns>
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
