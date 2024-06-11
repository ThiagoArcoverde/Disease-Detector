using DiseaseDetector.Handler;
using DiseaseDetector.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDetector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddServices();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlite(connectionString));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var startupService = services.GetRequiredService<IStartupService>();
                string datasetPath = "Dataset" + "/" + "Diseases.csv";
                 startupService.SetupDatabase(datasetPath);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
