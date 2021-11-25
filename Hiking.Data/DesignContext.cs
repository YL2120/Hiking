using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data
{
    public class DesignContext : IDesignTimeDbContextFactory<HikingContext> // FACTORY crée notre contexte à la place de ASP NET CORE MVC 
    {
        public HikingContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder() // accès aux paramètres de configuration
                               .SetBasePath(path) //je prends le projet en cours. nuget : fileextension
                               .AddJsonFile("appsettings.json");// et je lui spécifie ma configuration. nuget : configuration.json


            var config = builder.Build();

            var connectionString = config.GetConnectionString("HikingContext"); // il lit notre appsetting
            var connectionStringProd = config.GetConnectionString("HikingContextProd"); // il lit notre appsetting

            DbContextOptionsBuilder<HikingContext> optionBuilder = new DbContextOptionsBuilder<HikingContext>();
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            //       optionBuilder.UseSqlServer(connectionStringProd);
            //else
                optionBuilder.UseSqlServer(connectionString);//c'est ici qu'on précise quel DB on va utiliser.

            return new HikingContext(optionBuilder.Options);
        }
    }
}
