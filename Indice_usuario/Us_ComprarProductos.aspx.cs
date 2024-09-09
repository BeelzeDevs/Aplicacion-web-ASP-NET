using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_usuario
{
    public partial class Us_ComprarProdcutos : System.Web.UI.Page
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
                }
                cargarLvProductos();
                cargarCarrito();

            }
        }
        public void cargarCarrito()
        {
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new List<Producto>();
            }
            else
            {
                lvCarrito.DataSource = Session["carrito"];
                lvCarrito.DataBind();
            }
            
        }
        public void cargarLvProductos()
        {
            if (Session["Productos"] == null)
            {
                Session["Productos"] = (DataTable)pl.abrirListaProductos();
                lvProductos.DataSource = (DataTable)Session["Productos"];
            }
            else
            {
                lvProductos.DataSource = (DataTable)Session["Productos"];
            }
            
            lvProductos.DataBind();
            
        }
      
        protected void lvProductos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoComprarProducto")
            {
                string index = e.Item.DataItem as string;
                string idProducto = ((System.Web.UI.WebControls.Label)e.Item.FindControl("lblLegajoProducto")).Text;
                Producto product = new Producto();
                product.legajo_Producto = Convert.ToInt32(idProducto);

                product = pl.buscarProductoEnSession((DataTable)Session["Productos"], product);
                if (product == null) return;

                List<Producto> liCarrito = (List<Producto>)Session["carrito"];
                bool productoExiste = false;

                foreach (Producto prod in liCarrito)
                {
                    if(prod.legajo_Producto == product.legajo_Producto)
                    {
                        if (product.stock - 1 >= 0) 
                        {
                            prod.stock++;
                            product.stock--; 
                            Session["Productos"] = (DataTable) pl.modificarStockProductoEnSession((DataTable)Session["Productos"], product);
                        }
                        productoExiste = true;
                        break;
                    }
                }
                if (!productoExiste)
                {
                    Producto aux = new Producto();
                    aux.legajo_Producto = product.legajo_Producto;
                    aux.stock = 1;
                    aux.nombre = product.nombre;
                    aux.descripcion = product.descripcion;
                    aux.pu = product.pu;
                    aux.categoria = product.categoria;
                    aux.marca = product.marca;
                    
                    product.stock -= 1;
                    Session["Productos"] = (DataTable) pl.modificarStockProductoEnSession((DataTable)Session["Productos"],product);
                    liCarrito.Add(aux);
                }

                Session["carrito"] = liCarrito;
                cargarLvProductos();
                cargarCarrito();

            }
        }    

        

        // ejemplo para hacerlo con el click desde dentro del carrito con el evento 'Click' del botón más.
        protected void btnCarrito_mas_Click(object sender, EventArgs e)
        {
            // fila donde se hizo clic en el botón
            Button btn = (Button)sender;
            ListViewItem item = (ListViewItem)btn.NamingContainer;

            // Buscar el control lblCarrito_cantidad dentro de esa fila
            System.Web.UI.WebControls.Label lblCarrito_cantidad = ((System.Web.UI.WebControls.Label)item.FindControl("lblCarrito_cantidad"));


            lblCarrito_cantidad.Text = Convert.ToString(Convert.ToInt32(lblCarrito_cantidad.Text) + 1);
        }

        
        // Eventos del listView Sumar y Restar carrito
        protected void lvCarrito_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument); 
            List<Producto> liCarrito = (List<Producto>)Session["carrito"];
            Producto prodCarritoSelec = new Producto();
            Producto aux = new Producto();
            if (liCarrito.Count > 0)
            {
                prodCarritoSelec = liCarrito[index];
                aux.legajo_Producto = prodCarritoSelec.legajo_Producto;
            }
            
            if (e.CommandName == "eventoCarrito-sumar")
            {
                if(pl.puedeRestarseProductoEnSession((DataTable)Session["Productos"], aux))
                {
                    prodCarritoSelec.stock++;
                    Session["carrito"] = liCarrito;
                    cargarCarrito();
                    Session["Productos"] = (DataTable)pl.restarStockProductoEnSession((DataTable)Session["Productos"], aux);
                    Response.Redirect(Request.RawUrl);
                }

            }
            if(e.CommandName == "eventoCarrito-restar")
            {
                if (prodCarritoSelec.stock - 1 < 1) liCarrito.Remove(prodCarritoSelec);
                prodCarritoSelec.stock--;
                Session["carrito"] = liCarrito;
                cargarCarrito();
                Session["Productos"] = (DataTable)pl.sumarStockProductoEnSession((DataTable)Session["Productos"], aux);
                Response.Redirect(Request.RawUrl);
            }

           
        }

        protected void imgbtnCarrito_Click(object sender, ImageClickEventArgs e)
        {
            
            setEnableCarrito();
        }
        public void setEnableCarrito()
        {
            lvCarrito.Visible = !lvCarrito.Visible;
        }

        protected void lvProductos_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvProductos.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            cargarLvProductos();
        }
    }
}