using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiAPI.UTN.Modelos
{
    public class Cargo
    {
        [Key] //Indica que esta propiedad es la clave primaria de la entidad.
        public int Id { get; set; } // Campo que va a identificar la Primary Key.

        public string Name { get; set; }
        public string Description { get; set; }


        // Relaciones
        public List<Empleado>? Empleados { get; set; } // Relación uno a muchos con Empleado, un cargo puede tener varios empleados asociados.
    }
}
