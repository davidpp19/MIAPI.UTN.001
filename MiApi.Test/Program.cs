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

            Console.WriteLine(Crud<Cargo>.Endpoint);

            var nuevoCargo = Crud<Cargo>.Create(
                new Cargo { Description = "Cargo de prueba", Name = "Prueba" }
            );
            Console.WriteLine("Registro creado correctamente");
        }
    }
}