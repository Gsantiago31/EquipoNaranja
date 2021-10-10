using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.Models
{
    public class Matricula
    {

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdEstudiante { get; set; }

        public int IdCurso { get; set; }
    }
}
