using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.ViewsModels
{
    public class MatriculaViewsModels
    {
        public int Id { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int IdEstudiante { get; set; }
        public string TarjetaEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Profesor { get; set; }



    }
}
