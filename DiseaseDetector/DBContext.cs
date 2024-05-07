using DiseaseDetector.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
    }
}
