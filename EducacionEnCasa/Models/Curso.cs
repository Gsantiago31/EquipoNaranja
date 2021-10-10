using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.Models
{
    public class Curso
    {
        public int Id { get; set; }

        public string NombreCurso { get; set; }

        public int IdDocente { get; set; }
    }
}
