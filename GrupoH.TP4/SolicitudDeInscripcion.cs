using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    public class SolicitudDeInscripcion
    {
        int Codigo;
        int RegistroAlumno;
        List<Materia> Oferta;
        bool UltimasCuatro;
        bool SegundoLlamado;
        List<Curso> CursosPrincipales;
        List<Curso> CursosAlternativos;



        internal static bool DeclaracionJurada()
        {
            throw new NotImplementedException();
        }

        // CONSTRUCTOR que solicita los datos al momento de su creacion.
        public SolicitudDeInscripcion()
        {
            const string menu= "1 - Ver Materias Disponibles\n2 - Elegir Materia\n9 - Volver al menu principal";
            bool seguirEligiendoMaterias = true;
            bool salir = false;
            int opcionElegida;

            Alumno.UltimaCursada();

            if (Validadores.SoN("Ultimas 4 materias? S o N") == "S")
            {
                UltimasCuatro = true;
            }
            else
            {
                UltimasCuatro = false;
            }

            Oferta = CrearOfertaPersonalizada();
            
            do
            {
                Console.WriteLine(menu);
                opcionElegida = int.Parse(Console.ReadLine());
                int materiaElegida;
                int cursoElegido;
                int alternativaElegida;

                switch (opcionElegida)
                {
                    case 1:
                        Console.WriteLine("\tMaterias Disponibles:");
                        foreach (var materia in Oferta)
                        {
                            Console.WriteLine(materia.Codigo + " - " + materia.Nombre);
                        }
                        break;
                    case 2:
                        int contadorCursosElegidos = 1;
                        do
                        {
                            if (contadorCursosElegidos == 4)
                            {
                                seguirEligiendoMaterias = false;
                                break;
                            }

                            materiaElegida = Validadores.NumeroPositivo("Ingrese el codigo de la materia a la que desea inscribirse:");

                            foreach (var materia in Oferta)
                            {
                                if (materia.Codigo == materiaElegida)
                                {
                                    Console.WriteLine($"\tCursos disponibles para {materia.Nombre}");

                                    foreach (var curso in materia.Cursos)
                                    {
                                        //Console.WriteLine(curso.Value.Codigo + " - " + curso.Value.Profesor + " - " + curso.Value.Horario + " - " + curso.Value.Catedra);
                                        OfertaAcademica.MostrarCursosxMateria(materia);
                                    }

                                    do
                                    {
                                        cursoElegido = Validadores.NumeroPositivo("Elija un curso principal:");

                                        if (materia.Cursos.ContainsKey(cursoElegido))
                                        { 
                                            CursosPrincipales.Add(materia.Cursos[cursoElegido]);
                                            materia.Cursos.Remove(cursoElegido);            // Se quita para evitar que no se vuelva a elegir.
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("El curso seleccionado no existe.");
                                        }
                                    } while (true);

                                    do
                                    {
                                        alternativaElegida = Validadores.NumeroPositivo("Elija un curso alternativo:");

                                        if (materia.Cursos.ContainsKey(alternativaElegida))
                                        {
                                            CursosAlternativos.Add(materia.Cursos[alternativaElegida]);
                                            materia.Cursos.Remove(alternativaElegida);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("El curso seleccionado no existe.");
                                        }
                                    } while (true);

                                    if (Validadores.SoN("Desea agregar otra materia? S o N (Maximo 4)") == "N")
                                    {
                                        break;
                                    }
                                }
                            }

                            contadorCursosElegidos++;
                            
                        } while (seguirEligiendoMaterias == true);                        
                        break;
                    case 9:
                        salir = true;
                        Console.WriteLine("Saliendo...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("No ha ingresado un numero, intente nuevamente");
                        Console.ReadKey();
                        break;
                }

            } while (salir == false);
        }


        private static List<Materia> CrearOfertaPersonalizada()
        {
            List<Materia> retorno = new List<Materia>();
            int opcionElegida;
            string carreraElegida="";
            bool ok = false;

            do
            {
                Console.WriteLine("Elija la Carrera:\n" +
                    "1 - CONTADOR\n" +
                    "2 - ADMINISTRACION\n" +
                    "3 - SISTEMAS\n" +
                    "4 - ECONOMIA\n" +
                    "5 - ACTUARIO");
                opcionElegida = int.Parse(Console.ReadLine());

                switch (opcionElegida)
                {
                    case 1:
                        carreraElegida = "CONTADOR";
                        ok = true;
                        break;
                    case 2:
                        carreraElegida = "ADMIN";
                        ok = true;
                        break;
                    case 3:
                        carreraElegida = "SISTEMAS";
                        ok = true;
                        break;
                    case 4:
                        carreraElegida = "ECONOMIA"; 
                        ok = true;
                        break;
                    case 5:
                        carreraElegida = "ACTUARIO";
                        ok = true;
                        break;
                    default:
                        Console.WriteLine("La opcion ingresada no es valida, ingrese un numero entre 1 y 5.");
                        Console.ReadKey();
                        break;
                }



            } while (ok == false);

            Console.WriteLine("La carrera elegida fue: "+ carreraElegida);
            //                              //
            //                              //
            //  ------A DESARROLLAR------   //
            //                              //
            //                              //
            
            return retorno;
        }
    }
}
