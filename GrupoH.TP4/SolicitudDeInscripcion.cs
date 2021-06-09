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
        List<Materia> Oferta = new List<Materia>();
        bool UltimasCuatro;
        bool SegundoLlamado;
        List<Curso> CursosPrincipales = new List<Curso>();
        List<Curso> CursosAlternativos = new List<Curso>();


        // CONSTRUCTOR que solicita los datos al momento de su creacion.
        public SolicitudDeInscripcion(int registro)
        {
            const string menu= "1 - Ver Materias Disponibles\n2 - Elegir Materia\n9 - Volver al menu principal";
            bool seguirEligiendoMaterias = true;
            bool salir = false;
            string opcionElegida;
            List<int> ultimaCursada = new List<int>();
            this.RegistroAlumno = registro;

            ultimaCursada = Alumno.UltimaCursada(registro);

            foreach (var materia in ultimaCursada)
            {
                if (Validadores.SoN($"Usted Aprobo '{OfertaAcademica.OfertaMateria[materia].Nombre}' S/N?") == "S")
                {
                    NominaAlumnos.Inscriptos[registro].MateriasAprobadas.Add(OfertaAcademica.OfertaMateria[materia]);
                }
                else
                {
                    if (Validadores.SoN($"Usted Regularizo '{OfertaAcademica.OfertaMateria[materia].Nombre}' S/N?") == "S")
                    {
                        NominaAlumnos.Inscriptos[registro].MateriasRegularizadas.Add(OfertaAcademica.OfertaMateria[materia]);
                    }
                }
            }

            if (Validadores.SoN("Ultimas 4 materias? S/N") == "S")
            {
                this.UltimasCuatro = true;
            }
            else
            {
                this.UltimasCuatro = false;
            }

            Oferta = CrearOfertaPersonalizada(registro, UltimasCuatro);
            
            do
            {
                Console.WriteLine(menu);
                Console.Write("Elección:");
                opcionElegida = Console.ReadLine();
                int materiaElegida;
                int cursoElegido;
                int alternativaElegida;
                bool ok=false;
                switch (opcionElegida)
                {
                    
                    case "1":
                        Console.WriteLine("\tMaterias Disponibles:");
                        foreach (var materia in Oferta)
                        {
                            Console.WriteLine(materia.Codigo + " - " + materia.Nombre);
                        }
                        break;
                    case "2":
                        int contadorCursosElegidos = 0;
                          while (seguirEligiendoMaterias == true)
                            {
                                if (contadorCursosElegidos == 4)
                                {
                                Console.WriteLine("Ya ingreso los 4 cursos.");

                                    seguirEligiendoMaterias = false;
                                    break;
                                }
                            
                                materiaElegida = Validadores.NumeroPositivo("Ingrese el codigo de la materia a la que desea inscribirse o 0 para salir:");
                                Console.WriteLine();
                                if (materiaElegida == 0) { break; }

                                if (!OfertaAcademica.OfertaMateria.ContainsKey(materiaElegida))
                                {
                                    Console.WriteLine("El codigo de la materia ingresada no existe.");
                                    continue;
                                }
                                foreach(var mat in Oferta)
                                {
                                    if (mat.Codigo == materiaElegida) { ok = true; }
                                }
                                
                                if (ok == false) { Console.WriteLine("El codigo ingresado pertenece a otra carrera.");continue; }
                                foreach (var materia in Oferta)
                                {
                                    if (materia.Codigo == materiaElegida)
                                    {
                                        Console.WriteLine($"\tCursos disponibles para {materia.Nombre}: ");

                                        foreach (var curso in materia.Cursos)
                                        {
                                            //Console.WriteLine(curso.Value.Codigo + " - " + curso.Value.Profesor + " - " + curso.Value.Horario + " - " + curso.Value.Catedra);
                                            OfertaAcademica.MostrarCursosxMateria(materia.Codigo);
                                        }

                                        do
                                        {
                                            cursoElegido = Validadores.NumeroPositivo("Elija un curso principal:");

                                            if (materia.Cursos.ContainsKey(cursoElegido))
                                            {
                                                CursosPrincipales.Add(materia.Cursos[cursoElegido]);
                                                contadorCursosElegidos= contadorCursosElegidos+1;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("El codigo de curso ingresado no existe.");
                                            }
                                        } while (true);

                                        do
                                        {
                                            alternativaElegida = Validadores.NumeroPositivo("Elija un curso alternativo:");

                                            if (materia.Cursos.ContainsKey(alternativaElegida) || alternativaElegida!=cursoElegido)
                                            {
                                                CursosAlternativos.Add(materia.Cursos[alternativaElegida]);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("El codigo de curso ingresado no existe o ya lo selecciono como curso principal.");
                                            }
                                        } while (true);

                                        if (Validadores.SoN("Desea agregar otra materia? S o N (Maximo 4)") == "N")
                                        {
                                        seguirEligiendoMaterias=false;
                                        break ;
                                        }
                                    }
                                }
                            };                         
                        break;
                    case "9":
                        salir = true;
                        Console.WriteLine("Volviendo al menu, Hasta la proxima!.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Debe ingresar: 1, 2 o 9");
                        Console.ReadLine();
                        break;
                }

            } while (salir == false);
        }


        private static List<Materia> CrearOfertaPersonalizada(int registro, bool ultimasCuatro)
        {
            List<Materia> retorno = new List<Materia>();
            int opcionElegida;
            string carreraElegida="";
            bool ok = false;

            do
            {
                Console.WriteLine("Elija la Carrera:\n" +
                    "1 - CONTADOR\n" +
                    "2 - ADMINISTRACIÓN\n" +
                    "3 - SISTEMAS\n" +
                    "4 - ECONOMÍA\n" +
                    "5 - ACTUARIO ADMINISTRACIÓN\n" +
                    "6 - ACTUARIO ECONOMÍA\n");                
                opcionElegida = Validadores.NumeroPositivo("Elección:");

                switch (opcionElegida)
                {
                    case 1:
                        carreraElegida = "CP";
                        ok = true;
                        break;
                    case 2:
                        carreraElegida = "LA";
                        ok = true;
                        break;
                    case 3:
                        carreraElegida = "LS";
                        ok = true;
                        break;
                    case 4:
                        carreraElegida = "LE"; 
                        ok = true;
                        break;
                    case 5:
                        carreraElegida = "ACA";
                        ok = true;
                        break;
                    case 6:
                        carreraElegida = "ACE";
                        ok = true;
                        break;
                    default:
                        Console.WriteLine("La opcion ingresada no es valida, ingrese un numero entre 1 y 6.");
                        Console.ReadLine();
                        break;
                }
                
            } while (ok == false);

            var carrera = Carrera.PlanDeEstudios.Find(x => x.Codigo == carreraElegida);
            var indiceCarrera = Carrera.PlanDeEstudios.FindIndex(x => x.Codigo == carreraElegida);
            Console.WriteLine($"La carrera elegida fue: {carrera.Nombre}");

            foreach (var materia in carrera.Materias)
            {
                if (!NominaAlumnos.Inscriptos[registro].MateriasAprobadas.Contains(materia))
                {
                    if (!NominaAlumnos.Inscriptos[registro].MateriasRegularizadas.Contains(materia))
                    {
                        if (ultimasCuatro == true)
                        {
                            retorno.Add(materia);                            
                        }
                        else
                        {
                            if (!Carrera.PlanDeEstudios[indiceCarrera].Correlatividades.ContainsKey(materia.Codigo))
                            {
                                retorno.Add(materia);                                
                            }
                            else
                            {
                                bool corAprobadas = true;

                                foreach (var item in Carrera.PlanDeEstudios[indiceCarrera].Correlatividades[materia.Codigo])
                                {
                                    if (!(NominaAlumnos.Inscriptos[registro].MateriasAprobadas.Exists(x => x.Codigo == item)) && !(NominaAlumnos.Inscriptos[registro].MateriasRegularizadas.Exists(x => x.Codigo == item)))
                                    {
                                        corAprobadas = false;
                                    }
                                }

                                if (corAprobadas == true)
                                {
                                    retorno.Add(materia);
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            return retorno;
        }
    }
}
