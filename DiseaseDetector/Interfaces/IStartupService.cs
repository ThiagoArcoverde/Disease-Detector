using DiseaseDetector.Entities;

namespace DiseaseDetector.Interfaces
{
    public interface IStartupService
    {
        public void SetupDatabase(string datasetPath);
    }
}
