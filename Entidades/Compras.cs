using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compras
    {
        private int Legajo_Compra;// 
        private int Legajo_Cliente;
        private DateTime Fecha;
        private decimal Total;


        public int legajo_Compra { get => Legajo_Compra; set => Legajo_Compra = value; }
        public DateTime fecha { get => Fecha; set => Fecha = value; }
        public int legajo_Cliente { get => Legajo_Cliente; set => Legajo_Cliente = value; }
        public decimal total { get => Total; set => Total = value; }
    }
}
