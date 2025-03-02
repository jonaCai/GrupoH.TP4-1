﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Alumno
    {
        public int NroRegistro { get; internal set; }
        public string Nombre { get; internal set; }
        public string Mail { get; internal set; }
        public List<Carrera> Carreras { get; internal set; }
        public List<Materia> MateriasAprobadas { get; internal set; }
        public List<Materia> MateriasRegularizadas { get; internal set; }
        

        public Alumno(int registro, string nombre, string mail, List<Carrera> carreras, List<Materia> matAprobadas, List<Materia> matRegularizadas)
        {
            this.NroRegistro = registro;
            this.Nombre = nombre;
            this.Mail = mail;
            this.Carreras = carreras;
            this.MateriasAprobadas = matAprobadas;
            this.MateriasRegularizadas = matRegularizadas;
        }

        internal static bool Existe(int registro)
        {
            throw new NotImplementedException();
        }

        public List<int> ObtenerMateriasAprobadas()
        {
            List<int> retorno = new List<int>();

            foreach (var materia in MateriasAprobadas)
            {
                retorno.Add(materia.Codigo);
            }

            return retorno;
        }

        public List<int> ObtenerMateriasRegularizadas()
        {
            List<int> retorno = new List<int>();

            foreach (var materia in MateriasRegularizadas)
            {
                retorno.Add(materia.Codigo);
            }

            return retorno;
        }

        // Recorre Alumnno/Materia y clasifica las materias del ultimo cuatrimestre en Alumno.MateriasAprobadas o Alumno.MateriasRegularizadas.
        internal static List<int> UltimaCursada(int registro)
        {
            List<int> retorno = new List<int>();
            
            foreach (var materia in NominaAlumnos.MateriasCursadas)
            {                

                if (materia.Key.Contains(registro.ToString()))
                {
                    TimeSpan timeSpan = DateTime.Now - materia.Value.FechaDeCursada;

                    if (DateTime.Now.Month <= 6)
                    {
                        if (timeSpan.Days <= 11 * 30)
                        {
                            retorno.Add(materia.Value.CodigoMateria);
                        }
                    }
                    else
                    {
                        if (timeSpan.TotalDays <= 7 * 30)
                        {
                            retorno.Add(materia.Value.CodigoMateria);
                        }
                    }

                }
                
            }

            return retorno;
        }
    }
}
