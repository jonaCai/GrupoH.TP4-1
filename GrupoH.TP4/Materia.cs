using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Materia
    {
        

        

        public string Departamento { get; set; }
        public int Codigo { get;  set; }
        public string Nombre { get; set; }
        public Dictionary<int, Curso> Cursos { get;  set; }
        
        

        

        public Materia(string departamento, string nombre_materia, int codigo_materia)
        {
            Departamento = departamento;
            this.Nombre = nombre_materia;
            this.Codigo = codigo_materia;

           
        }


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
