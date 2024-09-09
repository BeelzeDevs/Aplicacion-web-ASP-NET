using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12
{
    public partial class Crear_usuario : System.Web.UI.Page
    {
        private PedidoLogico pl = new PedidoLogico();
        private Clientes cli = new Clientes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cv_Contraseña_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string data = args.Value;
            args.IsValid = false;
            bool uc = false;
            bool longitud = true;
            if(data.Length < 6 || data.Length > 10) { longitud = false;  }
            //Mayuscula o uppercase
            foreach (char c in data)

                if (c >= 'A' && c <= 'Z')
                {
                    uc = true; break;
                }
            if (!uc) return;
            //numero
            bool num = false;
            foreach (char c in data)
            {
                if (c >= '0' && c <= '9')
                {
                    num = true; break;
                }
            }
            if (!num) return;
            if (uc && num && longitud) { args.IsValid = true; }



        }

        protected void lbl_CrearUsuario_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Page.Validate();
            if (Page.IsValid) { 
                cli.nombre = txt_Nombre.Text;
                cli.contraseña = txt_Contraseña1.Text;
                cli.correo = txt_Correo.Text;
                cli.dirección = txt_Direccion.Text;
                cli.teléfono = txt_Telefono.Text;
                cli.fecha_nacimiento = Convert.ToDateTime(txt_Fechanac.Text);
                bool podriaCrearCliente = pl.podriaCrearCliente(cli);
                bool correoExiste = pl.correoExiste(cli);
                string mensaje = "";

                mensaje = correoExiste ? "El correo ya existe" : "";
                if(correoExiste && !podriaCrearCliente) mensaje = "El correo ya existe </br>El nombre de usuario ya existe";
                if(!correoExiste && !podriaCrearCliente) mensaje = "El nombre de usuario ya existe";



                if (podriaCrearCliente && !correoExiste)
                {
                    int filasAgregadas = pl.nuevoCliente(cli);
                    if (filasAgregadas == 1)
                    {
                        lblMensaje.ForeColor= Color.Green;
                        lblMensaje.Text = "Usuario agregado con exito";
                        vaciarControles();
                    }
                }
                else
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = mensaje;
                    vaciarControles();
                }
            }
        }
        public void vaciarControles()
        {
            txt_Contraseña1.Text = "";
            txt_Contraseña2.Text = "";
            txt_Correo.Text = "";
            txt_Direccion.Text = "";
            txt_Fechanac.Text = "";
            txt_Nombre.Text = "";
            txt_Telefono.Text = "";
            
        }
    }
}
