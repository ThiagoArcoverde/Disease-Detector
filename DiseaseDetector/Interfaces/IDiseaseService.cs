using DiseaseDetector.Entities;

namespace DiseaseDetector.Interfaces
{
    public interface IDiseaseService
    {
        public Task<List<Disease>> GetDiseasesBySymptoms(List<string> symptoms);
    }
}
