using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_administrador
{
    public partial class adm_ListarClientes : System.Web.UI.Page
    {
        private Admins adm = new Admins();
        private Clientes cli = new Clientes();
        private PedidoLogico pl = new PedidoLogico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                adm = (Admins)Session["Admin"];
                lbl_nombreusuario.Text = adm.nombre;
            }


            if (!IsPostBack)
            {
                ViewState["ClientesFilter"] = null;
                cargarlistview();

            }

        }
        public void cargarlistview()
        {
            if (ViewState["ClientesFiltro"] == null) {
                cargarlistview_sinFILTRO();
            }
            else
            {
                cargarlistview_conFILTRO(Convert.ToString(ViewState["ClientesFiltro"]));
            }

            DataPager pager = (DataPager)lv_ListarClientes.FindControl("DataPager1");
            if (pager != null)
            {
                pager.SetPageProperties(pager.StartRowIndex, pager.PageSize, true);
            }
        }
        public void cargarlistview_sinFILTRO()
        {
            Session["tablaClientes"] = (DataTable)pl.obtener_Cliente_sinFILTRO();
            lv_ListarClientes.DataSource = (DataTable)Session["tablaClientes"];
            lv_ListarClientes.DataBind();
        }
        public void cargarlistview_conFILTRO(string filtro)
        {
            Session["tablaClientes"] = (DataTable)pl.obtener_Cliente_conFILTRO(filtro);
            lv_ListarClientes.DataSource = (DataTable)Session["tablaClientes"];
            lv_ListarClientes.DataBind();
        }

        protected void btn_Filtro_Click(object sender, EventArgs e)
        {

            string filtro = txt_BusquedaxNombre.Text.ToString().Trim();
            if (filtro != "") {
                ViewState["ClientesFiltro"] = filtro;
                cargarlistview_conFILTRO(Convert.ToString(ViewState["ClientesFiltro"]));
                txt_BusquedaxNombre.Text = "";
            } 
            else{
                ViewState["ClientesFiltro"] = null;
                cargarlistview();
                txt_BusquedaxNombre.Text = "";
            }

        }

       
        protected void btn_Modificar_Command(object sender, CommandEventArgs e)
        {
        }

        protected void btn_Modificar_Command1(object sender, CommandEventArgs e)
        {        
        }

        protected void btn_Actualizar_Command(object sender, CommandEventArgs e)
        {
       
        }
        protected void btn_Cancelar_Command(object sender, CommandEventArgs e)
        {

        }
        private void Actualizar_Cliente(Clientes cli)
        {
            Clientes aux = new Clientes();
            foreach(ListViewItem x in lv_ListarClientes.Items)
            {
                if(Convert.ToInt32(((Label)x.FindControl("lbl_LegajoCliente")).Text) ==  cli.legajo_Cliente)
                {
                    aux.legajo_Cliente = cli.legajo_Cliente;
                    aux.nombre = ((TextBox)x.FindControl("txt_Nombre")).Text;
                    aux.contraseña= ((TextBox)x.FindControl("txt_Contraseña")).Text;
                    aux.dirección= ((TextBox)x.FindControl("txt_Direccion")).Text;
                    aux.correo= ((TextBox)x.FindControl("txt_Correo")).Text;
                    aux.teléfono= ((TextBox)x.FindControl("txt_Telefono")).Text;
                    aux.fecha_nacimiento=Convert.ToDateTime(((TextBox)x.FindControl("txt_Fecha")).Text);
                    aux.estado= ((CheckBox)x.FindControl("chb_Estado")).Checked;
                    aux.imagen = ((TextBox)x.FindControl("txtImagen")).Text;

                    lv_ListarClientes.DataSource= pl.actualizar_cliente(aux);
                    lv_ListarClientes.DataBind();
                }
            }
        }
 

        protected void lv_ListarClientes_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lv_ListarClientes.EditIndex = -1;
            cargarlistview();
        }

    

        protected void lv_ListarClientes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
              if(e.CommandName == "eventoActualizarCliente")
            {
                Clientes aux = new Clientes();
                int legajo1 = Convert.ToInt32(((Label)lv_ListarClientes.EditItem.FindControl("lbl_LegajoCliente")).Text);

                string nombre = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Nombre")).Text;
                string contraseña = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Contraseña")).Text;
                string direccion = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Direccion")).Text;
                string correo = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Correo")).Text;
                string telefono = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Telefono")).Text;
                string fechanac = ((TextBox)lv_ListarClientes.EditItem.FindControl("txt_Fecha")).Text;

                if(!CamposVacios(nombre, contraseña, direccion, correo, telefono, fechanac) ){



                    aux.legajo_Cliente = legajo1;
                    cli = pl.buscarCliente_SOLO_x_legajo(aux);
                    Actualizar_Cliente(cli);

                    lv_ListarClientes.EditIndex = -1;
                    cargarlistview();

                }else { lv_ListarClientes.EditIndex = -1; cargarlistview(); }

              
                
            }

            if (e.CommandName == "evento-modificar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                DataPager dp = ((DataPager)lv_ListarClientes.FindControl("DataPager1"));
                int registrosxPagina = dp.PageSize;
                bool offsetDeIndiceEsNecesario =  indice >= registrosxPagina;

                // Solamente va a modificar el indice cuando el offset es mayor a 3 que son los registroxPagina.
                if (indice % registrosxPagina == 0 && offsetDeIndiceEsNecesario)
                {
                    indice = 0;
                }
                else if (indice % registrosxPagina == 1 && offsetDeIndiceEsNecesario)
                {
                    indice = 1;
                }
                else if (indice % registrosxPagina == 2 && offsetDeIndiceEsNecesario)
                {
                    indice = 2;
                }

                lv_ListarClientes.EditIndex = indice;
                cargarlistview();
               
            }
            
           

        }
        private bool CamposVacios(string nombre, string contraseña, string direccion, string correo, string telefono, string fechanac)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(fechanac))
            {
                return true;
            }
            else return false;
        }



        protected void lv_ListarClientes_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
        {

            //cargarlistview();
        }

        protected void lv_ListarClientes_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lv_ListarClientes.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            cargarlistview();
        }
    }
}