using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducacionEnCasa.Models;

namespace EducacionEnCasa.ViewsModels
{
    public class AcudientesViewsModels : Acudientes
    {
        public int Id { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public string TelefonoEstudiante { get; set; }
        public string DireccionEstudiante { get; set; }



    }
}
