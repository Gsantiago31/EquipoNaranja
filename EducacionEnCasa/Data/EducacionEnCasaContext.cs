using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducacionEnCasa.Models;

namespace EducacionEnCasa.Data
{
    public class EducacionEnCasaContext : DbContext
    {
        public EducacionEnCasaContext (DbContextOptions<EducacionEnCasaContext> options)
            : base(options)
        {
        }

        public DbSet<EducacionEnCasa.Models.Estudiantes> Estudiantes { get; set; }

        public DbSet<EducacionEnCasa.Models.Acudientes> Acudientes { get; set; }

        public DbSet<EducacionEnCasa.Models.Docentes> Docentes { get; set; }
    }
}
