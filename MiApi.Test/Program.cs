using Api.Consummer;
using System.ComponentModel;
using MiAPI.UTN.Modelos;  // este es el que conecta con Cargo



namespace MiApp.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:7133/api/Cargos";
            Crud<Persona>.Endpoint = "https://localhost:7133/api/Personas";

            Console.WriteLine(Crud<Cargo>.Endpoint);

            //var nuevoCargo = Crud<Cargo>.Create(
            //    new Cargo { Description = "Cargo de prueba", Name = "Prueba" }
            //);

            //var nuevaPersona = Crud<Persona>.Create(new Persona
            //{
            //    Name = "Juan",
            //    Apellido = "Perez",
            //    Email = "juanperez@gmail.com",
            //    Telefono = "123456789",
            //    Direccion = "Calle Falsa 123"
            //}); 

            //Crud<Cargo>.Delete("1");
            Crud<Cargo>.Update("2", new Cargo { Id = 2, Description = "Cargo actualizado", Name = "Actualizado" });

            Console.ReadLine();
            Console.WriteLine("Registro creado correctamente");
        }
    }
}