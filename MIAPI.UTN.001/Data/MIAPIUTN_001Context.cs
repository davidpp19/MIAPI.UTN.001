using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiAPI.UTN.Modelos;

namespace MiAPI.UTN._001.Data
{
    public class MIAPIUTN_001Context : DbContext
    {
        public MIAPIUTN_001Context (DbContextOptions<MIAPIUTN_001Context> options)
            : base(options)
        {
        }

        public DbSet<MiAPI.UTN.Modelos.Persona> Personas { get; set; } = default!;
        public DbSet<MiAPI.UTN.Modelos.Cargo> Cargos { get; set; } = default!;
        public DbSet<MiAPI.UTN.Modelos.Empleado> Empleados { get; set; } = default!;
    }
}
