using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Program
    {
        static void Main(string[] args)
        {          
            OfertaAcademica.CargarOferta();
            NominaAlumnos.CargarNomina();
            Carrera.CargarPlanesDeEstudios();

            
            const string menuPrincipal = "\tSistema de Inscripciones.";
            //const string declaracionJurada = "Ingrese ";
            int registro = 0;
            bool registroValido = false;
            
            while (registroValido == false)
            {
                registro = Validadores.NumeroPositivo("Ingrese su Numero de Registro:");

                if (!NominaAlumnos.Inscriptos.ContainsKey(registro))
                {
                    Console.WriteLine("No existe un alumno con ese numero de registro.");
                    Console.ReadKey();
                }
                else
                {
                    registroValido = true;
                }
            }

            Console.WriteLine($"Bienvenido {NominaAlumnos.Inscriptos[registro].Nombre}!");
            

            do
            {
                Console.WriteLine(menuPrincipal);
                new SolicitudDeInscripcion(registro);

            } while (true);


            //SolicitudDeInscripcion.DeclaracionJurada();            
        }
    }
}
