using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Interacciones
    {
        private DateTime Fecha;
        private string Tipo;
        private string Motivo;
        private string Descripcion;
        private int Legajo_Cliente;

        public Interacciones() 
        {

        }

        public DateTime fecha { get => Fecha; set => Fecha = value; }
        public string tipo { get => Tipo; set => Tipo = value; }
        public string motivo { get => Motivo; set => Motivo = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
        public int legajo_Cliente { get => Legajo_Cliente; set => Legajo_Cliente = value; }
    }
}
