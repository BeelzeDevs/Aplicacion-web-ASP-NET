using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_usuario
{
    public partial class Us_SoportealUsuario : System.Web.UI.Page
    {
        private Clientes cli = new Clientes();
        private DateTime date = new DateTime();
        private Interacciones interac = new Interacciones();
        private PedidoLogico pl = new PedidoLogico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((Clientes)Session["Cliente"] != null)
                {
                    cli = (Clientes)Session["Cliente"];
                }
                cargarFecha();
                cargarOpciones();
            }
        }
        public void cargarFecha()
        {
            date = DateTime.Now;
            lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void cargarOpciones()
        {

            lblTipo.Text = "Web";
            string[] Motivos = { "Consulta", "Soporte Técnico" };
            foreach (string motivo in Motivos)
            {
                ddlMotivo.Items.Add(motivo);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(args.Value.Length <= 255)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                cli = (Clientes)Session["Cliente"];
                interac.legajo_Cliente = cli.legajo_Cliente;
                interac.tipo = lblTipo.Text;
                interac.motivo = ddlMotivo.SelectedValue;
                interac.descripcion = txtComentario.Text;
                interac.fecha = Convert.ToDateTime(lbl_Fecha.Text);
                
                pl.agregarInteraccion(interac);

                vaciarCampos();
                lblMensaje.Text = $"Enviado con éxito, gracias por contar con nosotros {cli.nombre}";

            }
        }
        public void vaciarCampos()
        {
            lblTipo.Text = "";
            ddlMotivo.SelectedIndex = 0;
            txtComentario.Text = "";
        }
    }
}