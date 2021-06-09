using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GrupoH.TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            OfertaAcademica.CargarOferta();
            NominaAlumnos.CargarNomina();
            Carrera.CargarPlanesDeEstudios();


            const string menuPrincipal = "Sistema de Inscripciones 1.0";
            int registro = 0;
            bool registroValido = false;

            while (registroValido == false)
            {
                registro = Validadores.NumeroPositivo("Ingrese su Numero de Registro: ");

                if (!NominaAlumnos.Inscriptos.ContainsKey(registro))
                {
                    Console.WriteLine("No existe un alumno con ese numero de registro.");
                    Console.ReadLine();
                }
                else
                {
                    registroValido = true;
                }
            }

            Console.WriteLine($"Bienvenido {NominaAlumnos.Inscriptos[registro].Nombre}! al {menuPrincipal} ");
            Console.WriteLine();
            if (File.Exists("SolicitudesInscripcion.txt"))
            {
                using (var reader = new StreamReader("SolicitudesInscripcion.txt"))
                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        if (linea.Contains(registro.ToString()))
                        {
                            Console.WriteLine("Su numero de registro ya cuenta con una solicitud de inscripcion realizada.");
                            Console.ReadKey();
                            registroValido = false;
                            break;
                        }
                        
                    }
                }
                
            }
            if (registroValido == true) { new SolicitudDeInscripcion(registro); }
            
        }
    }
}
