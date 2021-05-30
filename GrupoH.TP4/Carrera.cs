using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Carrera
    {
        public string Codigo { get; internal set; }
        public string Nombre { get; internal set; }
        public List<Materia> Materias { get; internal set; }

        public Carrera(string codigo, string nombre, List<Materia> materias)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Materias = materias;
        }
}
}
