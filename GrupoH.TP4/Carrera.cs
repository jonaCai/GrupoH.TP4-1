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

        static string nombreArchivo = "Carreras.txt";



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
        }
    }
}
