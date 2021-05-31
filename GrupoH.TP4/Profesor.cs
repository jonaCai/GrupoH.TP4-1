using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Profesor
    {
        string Nombre { get; }
        int Dni { get; }
        string Mail { get; }
        string Catedra { get; }
        int Materia { get; }
        int Curso { get; }


        public Profesor(string nombre, int dni, string mail, string catedra, int materia, int curso)
        {
            this.Nombre = nombre;
            this.Dni = dni;
            this.Mail = mail;
            this.Catedra = catedra;
            this.Materia = materia;
            this.Curso = curso;
        }
    }
}
