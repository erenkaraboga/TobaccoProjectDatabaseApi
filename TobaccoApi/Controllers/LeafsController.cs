using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TobaccoApi.Ef.Entities.Config;
using TobaccoApi.Entities;

namespace TobaccoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeafsController : ControllerBase
    {
        private ApiDbContext _dbcontext;
        public LeafsController(ApiDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> getLeaf()
        {
           var detail=   _dbcontext.Leafs.Include(a => a.LeafDetails).ToList();
            return(Ok(detail));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Leaf RecivedLeaf)
        {  
                await _dbcontext.Leafs.AddAsync(RecivedLeaf);
                await _dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrands(int id)
        {
            var leaf = await _dbcontext.Leafs.Include(a => a.LeafDetails).FirstOrDefaultAsync(i => i.LeafId == id);

            if (leaf == null)
            {
                return NotFound("No Record Found");
            }
            else
            {
       
                return Ok(leaf);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leaf = await _dbcontext.Leafs.FindAsync(id);
            if (leaf == null)
            {
                return NotFound("Record Not Found");
            }
            else
            {
                _dbcontext.Leafs.Remove(leaf);
                await _dbcontext.SaveChangesAsync();
                return Ok("Deleted");
            }
        }
    }
}
