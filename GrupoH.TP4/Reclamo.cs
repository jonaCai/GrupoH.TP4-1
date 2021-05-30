using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH.TP4
{
    class Reclamo
    {
        public int Codigo { get; internal set; }
        public string Descripcion { get; internal set; }
        public bool Cerrado { get; internal set; }

        public Reclamo(string descripcion)
        {
            var aleatorio = new Random();

            this.Codigo = aleatorio.Next(1, 999999);
            this.Descripcion = descripcion;
            this.Cerrado = false;
        }

        public void Cerrar()
        {
            this.Cerrado = true;
        }
}
}
