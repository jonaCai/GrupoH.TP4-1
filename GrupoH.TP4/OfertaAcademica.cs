using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GrupoH.TP4
{
    class OfertaAcademica
    {
        public static Dictionary<int, Materia> OfertaMateria = new Dictionary<int, Materia>();
        public static Dictionary<int, Curso> OfertaCursos = new Dictionary<int, Curso>();

        static string nombreArchivo = "Oferta.txt";

        public static void CargarOferta()
        {
            string Departamento = "";
            string Nombre_materia = "";
            int Codigo_materia = 0;
            string Catedra = "";
            string Sede = "";
            int Num_curso = 0;
            string Dia_hora = "";
            string profesor = "";
            int claveCurso=0;

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {

                    while (!reader.EndOfStream)
                    {

                        var linea = reader.ReadLine();

                        if (!linea.Contains("Virtual") && !linea.Contains("Obs.") )
                        {

                            if (linea.Equals("ADMINISTRACION"))
                            {
                                Departamento = "ADMINISTRACION";
                                continue;
                            }

                            if (linea.Equals("CONTABILIDAD"))
                            {
                                Departamento = "CONTABILIDAD";
                                continue;
                            }
                            if (linea.Equals("DERECHO"))
                            {
                                Departamento = "DERECHO";
                                continue;
                            }
                            if (linea.Equals("ECONOMIA"))
                            {
                                Departamento = "ECONOMIA";
                                continue;
                            }
                            if (linea.Equals("HUMANIDADES"))
                            {
                                Departamento = "HUMANIDADES";
                                continue;
                            }
                            if (linea.Equals("MATEMATICA"))
                            {
                                Departamento = "MATEMATICA";
                                continue;
                            }
                            if (linea.Equals("SISTEMAS"))
                            {
                                Departamento = "SISTEMAS";
                                continue;
                            }
                            if (linea.Equals("TRIBUTACION"))
                            {
                                Departamento = "TRIBUTACION";
                                continue;
                            }

                            if (linea.Contains("(")  && !linea.Contains("(h)") && !linea.Contains("(H)"))
                            {
                                //&&( (linea.Contains("1") || linea.Contains("2")|| linea.Contains("3")|| linea.Contains("4")||linea.Contains("5")
                                //|| linea.Contains("6") || linea.Contains("7") || linea.Contains("8") || linea.Contains("9")))

                                if (linea.Contains("(PARA CONTADORES)"))
                                {   
                                    linea = linea.Remove(linea.IndexOf('('),17);
                                   
                                }                                

                                string m;

                                var datos = linea.Remove(linea.IndexOf(")"));
                                var data = datos.Split('(');
                                
                                Nombre_materia = data[0].Trim();                                
                                
                                m = data[1].ToString();
                                
                                Codigo_materia = int.Parse(m);

                                var materia = new Materia(Departamento, Nombre_materia, Codigo_materia);

                                OfertaMateria.Add(Codigo_materia, materia);
                                continue;

                            }


                            if (linea.Contains("C�t"))
                            {
                                var datos = linea;

                                Catedra = datos.Trim();

                            }

                            if (linea.Equals("Avellaneda"))
                            {
                                Sede = "Avellaneda";

                            }
                            if (linea.Equals("San Isidro"))
                            {
                                Sede = "San Isidro";

                            }
                            if (linea.Equals("Pilar"))
                            {
                                Sede = "Pilar";

                            }
                            if (linea.Equals("Cordoba"))
                            {
                                Sede = "Cordoba";

                            }
                            if (linea.Equals("Paternal"))
                            {
                                Sede = "Paternal";

                            }

                            string ñ = linea.Substring(0, 4).ToString();

                            if (int.TryParse(ñ, out Num_curso))
                            {

                                Dia_hora = linea.Substring(5, 30).ToString().Trim();

                                profesor = linea.Substring(40, (linea.Length - 42)).ToString().Trim();
                                //sfd
                                claveCurso = int.Parse(Codigo_materia.ToString() + Num_curso.ToString());
                                var curso = new Curso(Sede, Catedra, claveCurso, Dia_hora, profesor,Codigo_materia);

                                OfertaCursos.Add(claveCurso, curso);

                                foreach (var materia in OfertaMateria)
                                {
                                    if (curso.cod_materia == materia.Key)
                                    {
                                        OfertaMateria[materia.Key].Cursos.Add(claveCurso, curso);
                                    }
                                }
                            }

                        }
                        else if (linea.Contains("Virtual")) 
                        {
                            reader.ReadLine();
                        }
                    }
                }

            }else { Console.WriteLine("El archivo no existe"); }

        }

        internal static void MostrarCursosxMateria(int materia)
        {
            foreach (var cursoDisponible in OfertaMateria[materia].Cursos)
            {
                Console.WriteLine($"{cursoDisponible.Key} - {cursoDisponible.Value.Profesor} {cursoDisponible.Value.DiaHorario} | {cursoDisponible.Value.Catedra}");
            }            
        }

        public static void MostrarOfertaMaterias()
        {

            Console.WriteLine("Oferta academica: ");
            
            Console.WriteLine("  Codigo Materia  |    Nombre Materia            |    Departamento ");

            foreach (var a in OfertaMateria)
            {
                string codigo = a.Value.Codigo.ToString();
                string nombre = a.Value.Nombre;
                string departamento = a.Value.Departamento;

                if (nombre.Length > 18)
                {
                    nombre = nombre.Substring(0, 17) + "...";
                };

                string linea = codigo.PadRight(18) + nombre.PadLeft(18) + departamento.PadLeft(18);

                Console.WriteLine(linea);
            }
            
        }

        public static void MostrarOfertaCursos(int codigo_materia)
        {

            Console.WriteLine("Oferta cursos de la materia : "+OfertaMateria[codigo_materia].Nombre);
       
            //Sede, Catedra, Num_curso, Dia_hora, profesor          

            foreach (var a in OfertaCursos)
            {
                string sede = a.Value.Sede;
                string catedra = a.Value.Catedra;
                string Numero_c = a.Value.Codigo.ToString();
                string dia_horario = a.Value.DiaHorario;
                string profesor = a.Value.Profesor;
                int codigo_mat = a.Value.cod_materia;
                
                if(codigo_mat==codigo_materia)
                {
                   
                    Console.WriteLine("Sede:"+sede);
                    Console.WriteLine("Catedra:" + catedra);
                    Console.WriteLine("Numero de curso:" + Numero_c);
                    Console.WriteLine("dia/horario" + dia_horario);
                    Console.WriteLine("Profesor" + profesor);
                }
                
                 //+ Numero_c.PadLeft(18)+ dia_horario.PadLeft(18) + profesor.PadLeft(18);                
              }
        }
    }
}