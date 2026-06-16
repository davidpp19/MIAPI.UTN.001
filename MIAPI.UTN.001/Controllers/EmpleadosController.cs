using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiAPI.UTN._001.Data;
using MiAPI.UTN.Modelos;

namespace MiAPI.UTN._001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly MIAPIUTN_001Context _context;

        public EmpleadosController(MIAPIUTN_001Context context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context
                .Empleados
                .Include(e => e.Persona) // Incluye la entidad relacionada Persona
                .Include(c => c.Cargo)   // Incluye la entidad relacionada Cargo
                .ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context
                .Empleados
                .Include(e => e.Persona) // Incluye la entidad relacionada Persona
                .Include(e => e.Cargo)   // Incluye la entidad relacionada Cargo
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        //Ponemos un metodo async porque async hace que el hilo de ejecución no se bloquee mientras se espera la respuesta de la base de datos, lo que mejora el rendimiento y la capacidad de respuesta de la aplicación. Al usar async, el hilo puede manejar otras solicitudes o tareas mientras espera la respuesta, lo que es especialmente útil en aplicaciones web donde múltiples usuarios pueden estar haciendo solicitudes simultáneamente.

        [HttpGet("EstadisticaSalarios")]
        public async Task<ActionResult<EstadisticaSalarios>> EstadisticaSalarios()
        {
            var salarioMaximo = await _context.Empleados
                .MaxAsync(e => e.Salario + e.Comision);
            var salarioMinimo = await _context.Empleados
                .MinAsync(e => e.Salario + e.Comision);
            var salarioPromedio = await _context.Empleados
                .AverageAsync(e => e.Salario + e.Comision);
            var cantidadEmpleados = await _context.Empleados
                .CountAsync();
            var empleadoAntiguo = await _context.Empleados
                .Include(e => e.Persona)
                .OrderBy(e => e.FechaIngreso)
                .FirstOrDefaultAsync();
            var pagoTotal = await _context.Empleados
                .SumAsync(e => e.Salario + e.Comision);

            var empleadoReciente = await _context.Empleados
                .Include(e => e.Persona)
                .OrderByDescending(e => e.FechaIngreso)
                .FirstOrDefaultAsync();

            var resultado = new EstadisticaSalarios
            {
                SalarioMaximo = salarioMaximo,
                SalarioMinimo = salarioMinimo,
                SalarioPromedio = salarioPromedio,
                CantidadEmpleados = cantidadEmpleados,
                EmpleadoAntiguo = empleadoAntiguo != null ? $"{empleadoAntiguo.Persona.Name} {empleadoAntiguo.Persona.Apellido}" : "N/A",
                EmpleadoReciente = empleadoReciente != null ? $"{empleadoReciente.Persona.Name} {empleadoReciente.Persona.Apellido}" : "N/A",
                PagoTotal = pagoTotal
            };

            return resultado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
