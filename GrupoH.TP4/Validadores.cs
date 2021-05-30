using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Validadores
    {
        public static string SoN(string textoAImprimir)
        {
            bool ok = false;
            string opcionElegida;

            do
            {
                Console.WriteLine(textoAImprimir);
                opcionElegida = Console.ReadLine().ToUpper();

                if (opcionElegida == "S")
                {
                    ok = true;
                }
                else if (opcionElegida == "N")
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine($"'{opcionElegida}' no es una opcion valida. Intente nuevamente...");
                }

            } while (ok == false);

            return opcionElegida;
        }

        public static int NumeroPositivo(string textoAImprimir)
        {
            int numero;
            bool completo = false;

            do
            {
                Console.WriteLine(textoAImprimir);

                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Debe ingresar un número. Intente nuevamente...");
                }
                else
                {
                    if (numero < 0)
                    {
                        Console.WriteLine("El número ingresado debe ser positivo. Intente nuevamente...");                        
                    }
                    else
                    {
                        completo = true;
                    }
                }

            } while (completo == false);

            return numero;
        }
    }
}
