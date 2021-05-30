using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    public class Curso
    {
        

        

        public int Codigo { get;  set; }
        public string Profesor { get;  set; }
        public string DiaHorario { get; set; }
        public string Catedra { get;  set; }
        public string Sede { get; set; }
        public int cod_materia { get; set; }

        public Curso(string sede, string catedra, int num_curso, string dia_hora, string profesor, int codigo_materia)
        {
            Sede = sede;
            Catedra = catedra;
            Codigo = num_curso;
            DiaHorario = dia_hora;
            Profesor = profesor;
            cod_materia = codigo_materia;
        }

    }
}
