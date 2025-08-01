using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    internal class Notas
    {
        /*
         
         * 1. Para generar el modelo de la Base de Datos se ejecuta el comando Scaffold-DbContext:
        
            Scaffold-DbContext "Server=.; Database=MRodriguezProgramacionNCapas; TrustServerCertificate=True; 
            User ID=sa; Password=pass@word1;" Microsoft.EntityFrameworkCore.SqlServer

         * 2. Configurar el archivo appsettings.json de la capa PL con la cadena de conexión
            
            "ConnectionStrings": {
            "MRodriguezProgramacionNCapas": "Server=.; Database=MRodriguezProgramacionNCapas; TrustServerCertificate=True; User ID=sa; Password=pass@word1;"
            },

         * 3. Configurar el archivo Program.cs de la capa PL
             
            var connectionString = builder.Configuration.GetConnectionString("MRodriguezProgramacionNCapas");

            builder.Services.AddDbContext<DL.MrodriguezProgramacionNcapasContext>(options => 
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<BL.Usuario>();
         
        
        */
    }
}
