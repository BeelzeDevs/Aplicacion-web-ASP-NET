using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Admins
    {
        private int Legajo_Admin;
        private string Nombre;
        private string Contraseña;




        public Admins() { }

        public int legajo_Admin { get => Legajo_Admin; set => Legajo_Admin = value; }
        public string nombre { get => Nombre; set => Nombre = value; }
        public string contraseña { get => Contraseña; set => Contraseña = value; }
        
    }
}