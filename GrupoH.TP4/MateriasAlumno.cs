using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    internal class MateriasAlumno
    {        
        public int registroAlumno { get; internal set; }
        public DateTime FechaDeCursada { get; internal set; }
        public int Nota { get; internal set; }
        public int CodigoMateria { get; internal set; }


        public MateriasAlumno(int registro,DateTime fecha, int nota, int codMateria)
        {
            this.registroAlumno = registro;
            this.FechaDeCursada = fecha;
            this.Nota = nota;
            this.CodigoMateria = codMateria;
        }
    }
}