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
            int codigo_materia;

            OfertaAcademica.CargarOferta();
            NominaAlumnos.CargarNomina();
            Carrera.CargarPlanesDeEstudios();
            Console.Write("Codigo de la materia?:");
            codigo_materia = int.Parse(Console.ReadLine());            
            OfertaAcademica.MostrarOfertaCursos(codigo_materia);

            
            Console.ReadLine();
            /*
            const string menuPrincipal = "Sistema de Inscripciones.";
            //const string declaracionJurada = "Ingrese ";
            int registro;
            bool registroValido = false;
            string opcionElegida;

            while (registroValido == false)
            {
                Console.WriteLine("Ingrese su Numero de Registro:");
                int.TryParse(Console.ReadLine(), out registro);

                if (!Alumno.Existe(registro))
                {
                    Console.WriteLine("No existe un alumno con ese numero de registro.");
                    Console.ReadKey();
                }
                else
                {
                    registroValido = true;
                }
            }

            Console.WriteLine($"Bienvenido {}!");
            

            do
            {
                Console.WriteLine(menuPrincipal);

            } while (true);


            SolicitudDeInscripcion.DeclaracionJurada();

            */
        }
    }
}
