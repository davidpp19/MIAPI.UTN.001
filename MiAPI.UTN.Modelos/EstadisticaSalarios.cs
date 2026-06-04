using System;
using System.Collections.Generic;
using System.Text;

namespace MiAPI.UTN.Modelos
{
    public class EstadisticaSalarios
    {
        public double SalarioMinimo { get; set; }
        public double SalarioMaximo { get; set; }
        public double SalarioPromedio { get; set; }

        public int CantidadEmpleados { get; set; }
        public string EmpleadoAntiguo { get; set; }
        public string EmpleadoReciente { get; set; }
        public double PagoTotal { get; set; }
    }
}
