using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace TIF_Grupo_12
{
    public partial class adm_Listar_mod_productos : System.Web.UI.Page
    {
        private Admins adm = new Admins();
        private PedidoLogico pl = new PedidoLogico();
        private Producto prod = new Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                adm = (Admins)Session["Admin"];
                lbl_nombreusuario.Text = adm.nombre;
            }

            if (!IsPostBack)
            {
                cargargridview();
                lbl_Mensaje.Text = "";
            }
            
        }

        private void cargargridview()
        {
            if(Session["Productos"] == null) { 
                Session["Productos"]= (DataTable)pl.abrirtabla_Productos();
                gv_Listarproductos.DataSource= (DataTable)Session["Productos"];
                gv_Listarproductos.DataBind();
            }
            else
            {
                gv_Listarproductos.DataSource = (DataTable)Session["Productos"];
                gv_Listarproductos.DataBind();
            }
        }
        
        protected void gv_Listarproductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Listarproductos.PageIndex = e.NewPageIndex;
            cargargridview();
        }

        protected void gv_Listarproductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lbl_Mensaje.Text = "";
            gv_Listarproductos.EditIndex = e.NewEditIndex;
            cargargridview();
        }

        protected void gv_Listarproductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lbl_Mensaje.Text = "";
            gv_Listarproductos.EditIndex = -1;
            cargargridview();
        }

        //verifica si es un numero que se puede convertir a decimal y si es positivo
        private bool esnumeroDecimalMayorA0(string numero)
        {
            decimal valor = 0;

            if (decimal.TryParse(numero, out valor))
            {
                if (valor > 0) return true;
                else return false;
            }
            else return false;

        }
        private bool esnumeroEnteroMayorA0(string numero)
        {
            int valor = 0;

            if (int.TryParse(numero, out valor))
            {
                if (valor > 0) return true;
                else return false;
            }
            else return false;

        }

        protected void gv_Listarproductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            string legajo = ((Label)gv_Listarproductos.Rows[e.RowIndex].FindControl("lbl_LegajoProd")).Text;
            string nombre = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Nombre")).Text;
            string precio = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Precio")).Text;
            string marca = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Marca")).Text;
            string categoria = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Categoria")).Text;
            string stock = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Stock")).Text;
            string descripcion = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Descripcion")).Text;
            bool estado = ((CheckBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("cb_Estado")).Checked;
            string imagen = ((TextBox)gv_Listarproductos.Rows[e.RowIndex].FindControl("txt_Imagen")).Text;

            bool verifyPrecio = esnumeroDecimalMayorA0(precio);
            bool verifyStock = esnumeroEnteroMayorA0(stock);
            bool estadoVacio=chequeo_campos_Vacios(nombre, precio,marca,categoria,stock, descripcion, imagen);
            //validación de precio de textbox, Stock de textbox y Campos Vacios o NULOS
            if (verifyPrecio && !estadoVacio && verifyStock) { 

                prod.legajo_Producto = Convert.ToInt32(legajo);
                prod.nombre = nombre;
                prod.pu = Convert.ToDecimal(precio);
                prod.marca = marca;
                prod.categoria = categoria;
                prod.stock = Convert.ToInt32(stock);
                prod.descripcion = descripcion;
                prod.imagen = imagen;
                prod.estado = estado;

            //Validación que no exista el mismo producto con mismo nombre,precio,marca,categoria,stock,descripcion y estado
            if (!pl.existeProductoExactamenteIgual(prod))
            {
                pl.actualizarProducto(prod);
                Session["Productos"] = pl.abrirtabla_Productos();
                gv_Listarproductos.EditIndex = -1;
                cargargridview();
                lbl_Mensaje.Text = "Producto actualizado con éxito";
            }
            else
            {
                gv_Listarproductos.EditIndex = -1;
                cargargridview();
                lbl_Mensaje.Text = "El producto ya se encuentra agregado";
            }

            }

            else
            {
                gv_Listarproductos.EditIndex = -1;
                cargargridview();
                lbl_Mensaje.Text = "Ingrese un precio válido";

            }
        }
        private bool chequeo_campos_Vacios(string nombre,string precio,string marca, string categoria, string stock, string descripcion, string imagen)
        {
            if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(precio) || string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(categoria) || string.IsNullOrWhiteSpace(stock) || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(imagen))
            {
                return true;
            }
            else return false; 
        }

        protected void gv_Listarproductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["legajo_prod"] = null;
            string legajo = ((Label)gv_Listarproductos.Rows[e.RowIndex].FindControl("lbl_LegajoProd")).Text;
            string nombre = ((Label)gv_Listarproductos.Rows[e.RowIndex].FindControl("lbl_Nomb")).Text;
            string descripcion = ((Label)gv_Listarproductos.Rows[e.RowIndex].FindControl("lbl_Descripcion")).Text;

            lbl_Eliminar.Text = "Seguro que desea eliminar? <br> Producto: " + nombre + "<br> Descripcion: " + descripcion;
            lbl_Eliminar.Visible = true;
            btn_Eliminar_NO.Visible = true;
            btn_Eliminar_SI.Visible = true;
            Session["legajo_prod"] = (int)Convert.ToInt32(legajo);

        }

        protected void btn_Eliminar_SI_Click(object sender, EventArgs e)
        {
            lbl_Mensaje.Text = "";
            int filascambiadas=0;
            prod.legajo_Producto = Convert.ToInt32(Session["legajo_prod"]);
            prod = pl.obtenerproducto(prod);
            filascambiadas =pl.eliminarProducto(prod);
            if (filascambiadas == 1) {
                lbl_Mensaje.Text = "Producto eliminado con éxito, Producto: " + prod.nombre; 
                Session["legajo_prod"] = null;
                Session["Productos"] = (DataTable)pl.abrirtabla_Productos();
                Botones_Eliminar_Invisible();
                cargargridview();
            }
            else
            {

                lbl_Mensaje.Text = "No se pudo eliminar el producto seleccionado";
                Session["legajo_prod"] = null;
                Botones_Eliminar_Invisible();
                cargargridview();
            }

        }

        protected void btn_Eliminar_NO_Click(object sender, EventArgs e)
        {
            Session["legajo_prod"] = null;
            lbl_Mensaje.Text = "";
            Botones_Eliminar_Invisible();
            cargargridview();
        }

        protected void btn_Filtro_Click(object sender, EventArgs e)
        {
            gv_Listarproductos.EditIndex = -1;
            Botones_Eliminar_Invisible();
            string desc = txt_BusquedaxDesc.Text.Trim();
            txt_BusquedaxDesc.Text = "";
            if (desc != "")
            {
                prod.descripcion = desc;
                Session["Productos"] =(DataTable) pl.FiltrarProducto_x_Descripcion(prod);
                cargargridview();

            }
            else
            {
                Session["Productos"] = (DataTable)pl.abrirtabla_Productos();
                cargargridview();
            }
        }

        private void Botones_Eliminar_Invisible()
        {
            lbl_Eliminar.Visible = false;
            btn_Eliminar_NO.Visible = false;
            btn_Eliminar_SI.Visible = false;
        }
    }
}