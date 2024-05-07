namespace DiseaseDetector.Entities
{
    public class Disease
    {
        public string? Name { get; set; }
        public string? Id { get; set; }
        public string? Alias { get; set; }
        public string? AliasId { get; set; }
        public List<string>? SymptomsId { get; set; }
    }
}
