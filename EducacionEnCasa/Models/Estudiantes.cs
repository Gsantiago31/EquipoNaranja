using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionEnCasa.Models
{
    public class Estudiantes
    {
        public int Id { get; set; }

        public string Tarjeta_identidad { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Id_Acudiente { get; set; }
        public string Id_Docente { get; set; }

    }
}
