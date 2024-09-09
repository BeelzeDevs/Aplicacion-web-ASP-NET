using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompra
    {
        private int Legajo_DetalleCompra;
        private int Legajo_Compra;
        private int Legajo_Producto;
        private decimal PU;
        private int Cantidad;
        private decimal Subtotal;

        public DetalleCompra()
        { 
        }
        public int legajo_DetalleCompra { get => Legajo_DetalleCompra; set => Legajo_DetalleCompra = value; }
        public int legajo_Compra { get => Legajo_Compra; set => Legajo_Compra = value; }
        public int legajo_Producto { get => Legajo_Producto; set => Legajo_Producto = value; }
        public decimal pu { get => PU; set => PU = value; }
        public int cantidad { get => Cantidad; set => Cantidad = value; }
        public decimal subtotal { get => Subtotal; set => Subtotal = value; }
    }
}
