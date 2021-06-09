using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Carrera
    {
        static public List<Carrera> PlanDeEstudios = new List<Carrera>();
        public string Codigo { get; internal set; }
        public string Nombre { get; internal set; }
        public List<Materia> Materias { get; internal set; }
        public Dictionary<int, List<int>> Correlatividades = new Dictionary<int, List<int>>();       // Key = Nº Materia | Value = Lista de Nº de materias 

        static string nombreArchivo = "Carreras.txt";
        static string nombreArchivo2 = "Correlatividades.txt";



        public Carrera(string codigo, string nombre, List<Materia> materias)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Materias = materias;
        }

        static public void CargarPlanesDeEstudios()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        List<Materia> materias = new List<Materia>();
                        var linea = reader.ReadLine().Split('|');
                        var separarMat = linea[2].Split(',');

                        foreach (var i in separarMat)
                        {
                            int codigo;
                            int.TryParse(i, out codigo);
                            materias.Add(OfertaAcademica.OfertaMateria[codigo]);
                        }


                        var plan = new Carrera(linea[0], linea[1], materias);
                        PlanDeEstudios.Add(plan);
                    }
                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado la tabla maestra 'Alumnos.txt' en la carpeta 'bin/debug'.");
                Console.ReadKey();
            }

            if (File.Exists(nombreArchivo2))
            {
                using (var reader = new StreamReader(nombreArchivo2))
                {                  
                    var indice = -1;
                    var carrera = "";
                    var codMateria = -1;

                    while (!reader.EndOfStream)
                    {
                        List<int> correlativas = new List<int>();
                        var linea = reader.ReadLine();

                        if (char.IsLetter(linea[0]))
                        {
                            if (carrera == "")
                            {
                                carrera = linea;
                                indice = Carrera.PlanDeEstudios.FindIndex(x => x.Codigo == carrera);
                                continue;
                            }
                            else if (carrera != "" && carrera != linea)
                            {
                                indice = Carrera.PlanDeEstudios.FindIndex(x => x.Codigo == linea);
                                continue;
                            }
                        }

                        var separado = linea.Split('|');
                        codMateria = int.Parse(separado[0]);
                        var codCorrelativas = separado[1].Split(',');
                        

                        foreach (var item in codCorrelativas)
                        {
                            correlativas.Add(int.Parse(item));
                        }

                        Carrera.PlanDeEstudios[indice].Correlatividades.Add(codMateria, correlativas);                        
                    }
                }
            }
        }

    }
}
