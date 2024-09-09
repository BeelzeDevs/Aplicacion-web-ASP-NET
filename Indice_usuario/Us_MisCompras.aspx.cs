using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_usuario
{
    public partial class Us_MisCompras : System.Web.UI.Page
    {
        private Clientes cli = new Clientes();
        private PedidoLogico pl = new PedidoLogico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((Clientes)Session["Cliente"] != null)
                {
                    cli = (Clientes)Session["Cliente"];
                    cargarGridView();
                }
                
            }
        }
        private void cargarGridView()
        {
            gvMisCompras.DataSource = pl.obtenerTablaCompras(cli);
            gvMisCompras.DataBind();
        }

        protected void gvMisCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "eventoVerDetalles")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                ResetAllButtons();
                handleButtons_Mostrar_Ocultar(e, true);
                
                int Legajo_Compra = Convert.ToInt32(((Label)gvMisCompras.Rows[index].FindControl("lblLegajoCompra")).Text);
                Compras compra = new Compras();
                compra.legajo_Compra = Legajo_Compra;
                gvDetalleCompra.DataSource = pl.obtenerTablaDetalleCompras(compra);
                gvDetalleCompra.DataBind();
                gvDetalleCompra.Visible = true;

            }
            if (e.CommandName == "eventoOcultarDetalles")
            {
                handleButtons_Mostrar_Ocultar(e, false);
                gvDetalleCompra.Visible = false;
                
            }
        }
        

        private void handleButtons_Mostrar_Ocultar(GridViewCommandEventArgs e, bool estado)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            Button btnDinamico = ((Button)gvMisCompras.Rows[index].FindControl("btnVerDetalles"));
            if(btnDinamico != null)
            {
                if (estado)
                {
                    btnDinamico.Text = "Ocultar Detalles";
                    btnDinamico.CommandName = "eventoOcultarDetalles";

                }
                else
                {
                    btnDinamico.Text = "Ver Detalles";
                    btnDinamico.CommandName = "eventoVerDetalles";
                }
            }

        }
        private void ResetAllButtons()
        {
            foreach (GridViewRow row in gvMisCompras.Rows)
            {
                Button btnDinamico = (Button)row.FindControl("btnVerDetalles");
                if (btnDinamico != null)
                {
                    btnDinamico.Text = "Ver Detalles";
                    btnDinamico.CommandName = "eventoVerDetalles";
                }
            }
        }
        protected void gvMisCompras_Sorting(object sender, GridViewSortEventArgs e)
        {
            ResetAllButtons();
            gvMisCompras.Visible = false;
            lblMensaje.Text = "Ordernar por: ";
            if (e.SortExpression == "ordenarxLegajo_Compras")
            {
                lblMensaje.Text += "Compras";
            }
            if (e.SortExpression == "ordenarxFecha")
            {
                lblMensaje.Text += "Fecha";
            }
            if (e.SortExpression == "ordenarxTotal")
            {
                lblMensaje.Text += "Total";
            }
        }

        protected void gvMisCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMisCompras.PageIndex = e.NewPageIndex;
            gvMisCompras.DataBind();
        }

        protected void gvMisCompras_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblMensaje.Text = "Entro";
        }
    }
}