using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymptomController : ControllerBase
    {
        private readonly DBContext _context;

        public SymptomController(DBContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetSymptoms")]
        public async Task<IActionResult> GetSymptoms()
        {
            var diseases = await _context.Symptoms.ToListAsync();
            return Ok(diseases);
        }
    }
}
