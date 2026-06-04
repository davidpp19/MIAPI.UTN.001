using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Consummer;
using MiAPI.UTN.Modelos;

namespace Mi.App.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:44324/api/cargo";

            var nuevoCargo = Crud<Cargo>.Create(new Cargo { Name = "Prueba" , Description = "Cargo de Prueba" }
            );
        }
    }
}
