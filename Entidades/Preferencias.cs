using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Preferencias
    {
        private int Legajo_Preferencia;
        private string Producto_Preferido;
        private string Interes_Categoria;
        private string Interes_Actividad;
        private string Interes_Comida;
        private bool Estado_Cliente;
        private int Legajo_Cliente;

        public Preferencias()
        {

        }
        public int legajo_Preferencia { get => Legajo_Preferencia; set => Legajo_Preferencia = value; }
        public string producto_Preferido { get => Producto_Preferido; set => Producto_Preferido = value; }
        public string interes_Categoria { get => Interes_Categoria; set => Interes_Categoria = value; }
        public string interes_Actividad { get => Interes_Actividad; set => Interes_Actividad = value; }
        public string interes_Comida { get => Interes_Comida; set => Interes_Comida = value; }
        public bool estado_Cliente { get => Estado_Cliente; set => Estado_Cliente = value; }
        public int legajo_Cliente { get => Legajo_Cliente; set => Legajo_Cliente = value; }
    }
}
