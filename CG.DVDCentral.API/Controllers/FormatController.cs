using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CG.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly ILogger<FormatController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;

        public FormatController(ILogger<FormatController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Format>>> Get()
        {

            try
            {
                return Ok(await new FormatManager(logger, options).LoadAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public Format Get(Guid id)
        {
            return new FormatManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public async Task<ActionResult> Post([FromBody] Format format, bool rollback = false)
        {
            try
            {
                await new FormatManager(options).InsertAsync(format, rollback);
                return Ok(format.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Format format, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Update(format, rollback);
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
                return new FormatManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
