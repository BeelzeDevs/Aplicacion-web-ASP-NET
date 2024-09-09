using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_usuario
{
    public partial class Us_EncuestaIntereses : System.Web.UI.Page
    {
        private Clientes cli = new Clientes();
        private PedidoLogico pl = new PedidoLogico();
        private Preferencias pref = new Preferencias();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if ((Clientes)Session["Cliente"] != null)
                {
                    cli = (Clientes)Session["Cliente"];
                }
                cargarDropDownLists();
            }

        }

        public void cargarDropDownLists()
        {
            DataTable ProductosYLegajos = pl.obtenerProductosUnicos();
            // Productos
            foreach(DataRow dataRow in ProductosYLegajos.Rows)
            {
                ddl_Producto.Items.Add(dataRow[0].ToString());
            }
            //Categorias
            DataTable CategoriasYLegajos = pl.obtenerCategoriasUnicos();
            foreach(DataRow dataRow in CategoriasYLegajos.Rows)
            {
                ddl_Categoria.Items.Add(dataRow[0].ToString());
            }
            //Actividades
            String[] Actividades = { "Deporte", "Ocio", "Mecánica", "Belleza", "Tecnología", };
            foreach (String str in Actividades)
            {
                ddl_Actividad.Items.Add(str);
            }
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid) 
            {
                cli = (Clientes)Session["Cliente"];
                pref.producto_Preferido = ddl_Producto.SelectedItem.Text;
                pref.interes_Categoria = ddl_Categoria.SelectedItem.Text;
                pref.interes_Actividad = ddl_Actividad.SelectedItem.Text;
                pref.interes_Comida= txt_DescripAlimentos.Text;
                pref.legajo_Cliente = cli.legajo_Cliente;
                pref.estado_Cliente = cli.estado;
                pl.agregarPreferencia(pref);

                //Agregar funcionalidad Seguimiento Marketing
                string tipo_marqueting = ddl_tipoMarketing.Text;
                ddl_Actividad.SelectedIndex = 0;
                ddl_Categoria.SelectedIndex = 0;
                ddl_Producto.SelectedIndex = 0;
                ddl_tipoMarketing.SelectedIndex = 0;
                txt_DescripAlimentos.Text = "";
                lblMensaje.Visible = true;
                lblMensaje.Text = "Enviado con éxito";
            }
            
        }
    }
}