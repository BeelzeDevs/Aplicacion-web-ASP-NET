using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        private int Legajo_Cliente;
        private string  Nombre;
        private string Contraseña;
        private string Dirección;
        private string Teléfono;
        private string Correo;
        private DateTime Fecha_nacimiento;
        private bool Estado;
        private string Imagen;


        public Clientes() { }

        public int legajo_Cliente { get => Legajo_Cliente; set => Legajo_Cliente = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public string contraseña { get => Contraseña; set => Contraseña = value; }
        public string dirección { get => Dirección; set => Dirección = value; }
        public string teléfono { get => Teléfono; set => Teléfono = value; }
        public string correo { get => Correo; set => Correo = value; }
        public DateTime fecha_nacimiento { get => Fecha_nacimiento; set => Fecha_nacimiento = value; }
        public bool estado { get => Estado; set => Estado = value; }
        public string imagen { get => Imagen; set => Imagen = value; }
    }
}