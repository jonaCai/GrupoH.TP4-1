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
            const string menuPrincipal = "Sistema de Inscripciones.";
            //const string declaracionJurada = "Ingrese ";
            int registro;
            bool registroValido = false;
            string opcionElegida;

            while (registroValido = false)
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
        }
    }
}
