using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly DBContext _context;

        public DiseaseController(DBContext context) 
        {
            _context = context;
        }

        [HttpGet(Name = "GetDiseases")]
        public async Task<IActionResult> GetDiseases()
        {
            var diseases = await _context.Diseases.ToListAsync();
            return Ok(diseases);
        }
    }
}
