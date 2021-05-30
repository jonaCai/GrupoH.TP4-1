using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Materia
    {
        public int Codigo { get; internal set; }
        public string Nombre { get; internal set; }
        public int CargaHoraria { get; internal set; }
        public string Departamento { get; internal set; }
        public List<Materia> Correlativas { get; internal set; }
        public List<Carrera> Carreras { get; internal set; }
        public Dictionary<int, Curso> Cursos { get; internal set; }

        public bool ExisteCurso(int codCurso)
        {
            bool retorno = false;

            foreach (var curso in Cursos)
            {
                if (curso.Value.Codigo == codCurso)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
