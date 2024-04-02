using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CG.DVDCentral.API.Controllers

{
    /// <summary>
    /// DirectorController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly ILogger<DirectorController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;

        /// <summary>
        /// DirectorController Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="options"></param>
        public DirectorController(ILogger<DirectorController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Director> Get()
        {
            logger.LogWarning("Directors-->");
            return new DirectorManager(logger, options).Load();
        }

        /// <summary>
        /// DirectorController Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Director Get(Guid id)
        {
            return new DirectorManager(logger, options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public Guid Post([FromBody] Director director, bool rollback = false)
        {
            try
            {
                return new DirectorManager(options).Insert(director, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Director director, bool rollback = false)
        {
            try
            {
                return new DirectorManager(options).Update(director, rollback);
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
                return new DirectorManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
