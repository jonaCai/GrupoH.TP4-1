using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Catedra
    {
        public string Nombre { get; internal set; }
        public string Titular { get; internal set; }
        public List<Materia> Materias { get; internal set; }
        public List<Profesor> Profesores { get; internal set; }

        public Catedra(string nombre, string titular, List<Materia> materias, List<Profesor> profesores)
        {
            this.Nombre = nombre;
            this.Titular = titular;
            this.Materias = materias;
            this.Profesores = profesores;
        }
    }
}
