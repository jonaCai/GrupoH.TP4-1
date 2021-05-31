using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class NominaAlumnos
    {
        
        static public Dictionary<int, Alumno> Inscriptos = new Dictionary<int, Alumno>();
        public static Dictionary<string, MateriasAlumno> MateriasCursadas = new Dictionary<string, MateriasAlumno>();
        static string nombreArchivo = "Alumnos.txt";

        public static void CargarNomina()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        List<Materia> materiasAprobadas = new List<Materia>();
                        List<Materia> materiasRegularizadas = new List<Materia>();
                        List<Materia> totalmaterias = new List<Materia>();
                        List<Carrera> carreraAlumno = new List<Carrera>();

                        var linea = reader.ReadLine().Split('|');
                        var numeroReg = int.Parse(linea[0]);
                        var carrerasImportadas = linea[3].Split(',');                                                                      
                        var materiasImportadas = linea[4].Split(',');
                        var materiasImportadas2 = linea[5].Split(',');
                        var fecha_inscripto = linea[6].Split(',');
                        var notas = linea[7].Split(',');
                        
                        foreach (var j in carrerasImportadas)
                        {
                            if (j != "")
                            {
                                carreraAlumno.Add(Carrera.PlanDeEstudios.Find(x => x.Codigo == j));
                            }                            
                        }

                        foreach (var i in materiasImportadas)
                        {
                            int codigo;
                            int.TryParse(i, out codigo);

                            if (i != "")
                            {
                                materiasAprobadas.Add(OfertaAcademica.OfertaMateria[codigo]);
                            }
                                                        
                        }
                        
                        
                        foreach (var k in materiasImportadas2)
                        {
                            int codigo;
                            int.TryParse(k, out codigo);

                            if (k != "")
                            {
                                materiasRegularizadas.Add(OfertaAcademica.OfertaMateria[codigo]);
                            }                            
                        }

                        totalmaterias.AddRange(materiasAprobadas);
                        totalmaterias.AddRange(materiasRegularizadas);

                        var alumnoImportado = new Alumno(numeroReg, linea[1], linea[2], carreraAlumno, materiasAprobadas, materiasRegularizadas);

                        Inscriptos.Add(alumnoImportado.NroRegistro, alumnoImportado);

                        int contador = 0;
                        foreach (var i in totalmaterias)
                        {
                            var matAlumno = new MateriasAlumno(numeroReg,DateTime.Parse(fecha_inscripto[contador]),int.Parse(notas[contador]),i.Codigo);

                            var keymaAlumno = alumnoImportado.NroRegistro.ToString()+ i.Codigo.ToString();

                            MateriasCursadas.Add(keymaAlumno, matAlumno);
                            //validaciones para fecha y notas?
                            contador =contador +1;
                                
                        }
                     



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
