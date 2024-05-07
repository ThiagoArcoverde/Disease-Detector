using DiseaseDetector.Entities;
using DiseaseDetector.Interfaces;

namespace DiseaseDetector.Services
{
    public class StartupService : IStartupService
    {
        private readonly DBContext _context;

        public StartupService(DBContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public void SetupDatabase(string datasetPath)
        {
            bool firstRead = true;
            Disease disease = new Disease();
            List<string> symptomsId = new List<string>();
            if (!_context.Diseases.Any())
            {
                using (var reader = new StreamReader(datasetPath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line != null && !firstRead)
                        {
                            var data = line.Split(',');
                            if (data.Length > 0)
                            {
                                if (!String.IsNullOrEmpty(data[0]))
                                {
                                    if (!String.IsNullOrEmpty(disease.Id))
                                    {
                                        disease.SymptomsId = symptomsId;
                                        SaveDisease(disease);
                                        symptomsId = new List<string>();
                                    }
                                    disease = CreateNewDisease(data);
                                    if (!String.IsNullOrEmpty(data[2]))
                                    {
                                        Symptom symptom = CreateNewSymptom(data);
                                        SaveSymptom(symptom);
                                        symptomsId.Add(symptom.Id);
                                    }
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(data[2]))
                                    {
                                        Symptom symptom = CreateNewSymptom(data);
                                        SaveSymptom(symptom);
                                        symptomsId.Add(symptom.Id);
                                    }
                                }
                            }
                        }
                        firstRead = false;
                    }
                }
            }
        }

        private Disease CreateNewDisease(string[] data)
        {
            string[] diseaseValues = data[0].Split("^");
            if (diseaseValues.Length > 1)
            {
                string[] diseaseNameData = diseaseValues[0].Split("_");
                string[] diseaseAliasData = diseaseValues[1].Split("_");
                return new Disease()
                {
                    Id = diseaseNameData[0],
                    Name = diseaseNameData[1],
                    AliasId = diseaseAliasData[0],
                    Alias = diseaseAliasData[1]
                };
            }
            string[] diseaseData = diseaseValues[0].Split("_");
            return new Disease()
            {
                Id = diseaseData[0],
                Name = diseaseData[1],
            };
        }

        private Symptom CreateNewSymptom(string[] data)
        {
            string[] symptomData = data[2].Split('_');
            return new Symptom()
            {
                Id = symptomData[0],
                Name = symptomData[1],
            };
        }

        private void SaveDisease(Disease disease)
        {
            if (!this._context.Diseases.Any(w => w.Id == disease.Id))
            {
                this._context.Diseases.Add(disease);
                this._context.SaveChanges();
            }
        }

        private void SaveSymptom(Symptom symptom)
        {
            if (!this._context.Symptoms.Any(w => w.Id == symptom.Id))
            {
                this._context.Symptoms.Add(symptom);
                this._context.SaveChanges();
            }
        }
    }
}
