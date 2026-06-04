using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiAPI.UTN.Modelos
{
    public class Persona
    {
        [Key] //Indica que esta propiedad es la clave primaria de la entidad.
        public int Id { get; set; } //Campo que va a identificar la Primary Key.
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        // Relaciones

        public Empleado? Empleado { get; set; } // Relación uno a uno con Empleado.
    }
}
