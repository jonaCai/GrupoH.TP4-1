using System;
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
        public int Dni { get; internal set; }
        public string Mail { get; internal set; }
        public List<Carrera> Carreras { get; internal set; }
        public Dictionary<int,int> MateriasAprobadas { get; internal set; }     // KEY --> Codigo de la Materia | VALUE --> Nota
        public List<Materia> MateriasRegularizadas { get; internal set; }

        public Alumno(int registro, string nombre, int dni, string mail, List<Carrera> carreras, Dictionary<int,int> matAprobadas, List<Materia> matRegularizadas)
        {
            this.NroRegistro = registro;
            this.Nombre = nombre;
            this.Dni = dni;
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
                retorno.Add(materia.Key);
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
        internal static void UltimaCursada()
        {
            throw new NotImplementedException();
        }
    }
}
