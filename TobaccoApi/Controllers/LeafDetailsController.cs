using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TobaccoApi.Ef.Entities;
using TobaccoApi.Ef.Entities.Config;

namespace TobaccoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeafDetailsController : ControllerBase
    {
        private ApiDbContext _dbcontext;
        public LeafDetailsController(ApiDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var detail = _dbcontext.LeafDetails;
            return (Ok(detail));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] LeafDetail RecivedDetail)
        {
            await _dbcontext.LeafDetails.AddAsync(RecivedDetail);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeafDetail(int id)
        {
            var leafDetail = await _dbcontext.LeafDetails.FindAsync(id);
            if (leafDetail == null)
            {
                return NotFound("No Record Found");
            }
            else
            {

                return Ok(leafDetail);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leafDetail = await _dbcontext.LeafDetails.FindAsync(id);
            if (leafDetail == null)
            {
                return NotFound("Record Not Found");
            }
            else
            {
                _dbcontext.LeafDetails.Remove(leafDetail);
                await _dbcontext.SaveChangesAsync();
                return Ok("Deleted");
            }
        }
    }
}
