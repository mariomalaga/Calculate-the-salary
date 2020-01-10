using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    class Empleado
    {
        #region Variables
        int categoria;
        string nif;
        string nombre;
        int numHijos;
        int numTrienios;
        #endregion
        #region Constructores
        public Empleado()
        {
        }

        public Empleado(int categoria, string nif, string nombre, int numHijos, int numTrienios)
        {
            this.Categoria = categoria;
            this.Nif = nif;
            this.Nombre = nombre;
            this.NumHijos = numHijos;
            this.NumTrienios = numTrienios;
        }
        #endregion
        #region Propiedades
        public int Categoria { get => categoria; set => categoria = value; }
        public string Nif { get => nif; set => nif = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int NumHijos { get => numHijos; set => numHijos = value; }
        public int NumTrienios { get => numTrienios; set => numTrienios = value; }
        #endregion
    }
}
