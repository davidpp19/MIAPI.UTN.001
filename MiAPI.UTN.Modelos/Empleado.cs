using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiAPI.UTN.Modelos
{
    public class Empleado
    {
        public int Id { get; set; } // Campo que va a identificar la Primary Key.
        public double Salario { get; set; }
        public double Comision { get; set; }
        public DateTime FechaIngreso { get; set; }

        // Relaciones
        [ForeignKey("PersonaId")] // Especifica que PersonaId es la clave foránea para la relación con Persona
        public int PersonaId { get; set; } // Clave foránea para Persona
        public Persona? Persona { get; set; } // Relación uno a uno con Persona, es el objeto de navegación.
        [ForeignKey("CargoId")] // Especifica que CargoId es la clave foránea para la relación con Cargo
        public int CargoId { get; set; } // Clave foránea para Cargo
        public Cargo? Cargo { get; set; } // Relación uno a uno con Cargo, es el objeto de navegación.
    }
}
