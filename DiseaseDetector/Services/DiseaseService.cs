using DiseaseDetector.Entities;
using DiseaseDetector.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly DBContext _context;

        public DiseaseService(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Disease>> GetDiseasesBySymptoms(List<string> symptomsIds)
        {
            try
            {
                var diseases = await this._context.Diseases
                    .ToListAsync();

                foreach (var id in symptomsIds)
                {
                    if (diseases.Count > 0)
                    {
                        diseases = diseases
                            .Where(w => w.SymptomsId != null && w.SymptomsId.Contains(id))
                            .ToList();
                    }
                }

                return diseases;
            }
            catch (Exception)
            {
                throw new SystemException("Internal server error");
            }
        }
    }
}
