using EducacionEnCasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.ViewsModels
{
    public class EstudiantesViewsModels : Estudiantes
    {
        public string NombresDocente { get; set; }

        public string ApellidosDocente { get; set; }

        public string TelefonoDocente { get; set; }

        public string DireccionDocente { get; set; }

        public string NivelEducativo { get; set; }

        public string CC { get; set; }

        public string CC_Acudiente { get; set; }

        public string NombreAcudiente { get; set; }

        public string ApellidoAcudiente { get; set; }

        public string TelefonoAcudiente { get; set; }

        public string DireccionAcudiente { get; set; }

    }
}
