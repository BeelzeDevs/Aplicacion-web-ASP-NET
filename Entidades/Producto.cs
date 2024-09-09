using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int Legajo_Producto;
        private string Nombre;
        private decimal PU;
        private string Marca;
        private string Categoria;
        private int Stock;
        private string Descripcion;
        private string Imagen;
        private bool Estado;

        public Producto() { }

        public int legajo_Producto { get => Legajo_Producto; set => Legajo_Producto = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public decimal pu { get => PU; set => PU = value; }
        public string marca { get => Marca; set => Marca = value; }
        public string categoria { get => Categoria; set => Categoria = value; }
        public int stock { get => Stock; set => Stock = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
        public string imagen { get => Imagen; set => Imagen = value; }
        public bool estado { get => Estado; set => Estado = value; }
    }
}
