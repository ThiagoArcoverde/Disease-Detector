using DiseaseDetector.Entities;
using DiseaseDetector.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IDiseaseService _service;

        public DiseaseController(DBContext context, IDiseaseService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiseases()
        {
            var diseases = await _context.Diseases.ToListAsync();
            return Ok(diseases);
        }

        [HttpGet]
        [Route("DiseasesBySymptoms")]
        public async Task<IActionResult> GetDiseasesBySymptoms([FromQuery]List<string> symptomsId)
        {
            var diseases = await _service.GetDiseasesBySymptoms(symptomsId);
            return Ok(diseases);
        }
    }
}