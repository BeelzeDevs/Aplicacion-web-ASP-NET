using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace DAO
{
    public class DAOProductos
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOProductos()
        {

        }
        public Producto obtenerProducto(Producto prod)
        {
            DataTable dt = new DataTable();
            dt = ad.abrirTabla("Productos", "Select * From Producto WHERE Legajo_Producto = " + prod.legajo_Producto );
            prod.legajo_Producto = (Convert.ToInt32(dt.Rows[0][0].ToString()));
            prod.nombre = dt.Rows[0][1].ToString();
            prod.pu =Convert.ToDecimal( dt.Rows[0][2].ToString());
            prod.marca = dt.Rows[0][3].ToString();
            prod.categoria = dt.Rows[0][4].ToString();
            prod.stock = Convert.ToInt32(dt.Rows[0][5].ToString());
            prod.descripcion = dt.Rows[0][6].ToString();
            prod.imagen = dt.Rows[0][7].ToString();
            prod.estado = Convert.ToBoolean(dt.Rows[0][8]);

            return prod;

        }
        private void armarParametrosEliminar(ref SqlCommand cmd, Producto prod)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Producto", SqlDbType.Int);
            parametros.Value = prod.legajo_Producto;


        }

        private void armarParametrosActualizar(ref SqlCommand cmd, Producto prod)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Producto", SqlDbType.Int);
            parametros.Value = prod.legajo_Producto;
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = prod.nombre;
            parametros = cmd.Parameters.Add("@PU", SqlDbType.Decimal);
            parametros.Value = prod.pu;
            parametros = cmd.Parameters.Add("@Marca", SqlDbType.VarChar, 255);
            parametros.Value = prod.marca;
            parametros = cmd.Parameters.Add("@Categoria", SqlDbType.VarChar, 255);
            parametros.Value = prod.categoria; 
            parametros = cmd.Parameters.Add("@Stock", SqlDbType.Int);
            parametros.Value = prod.stock; 
            parametros = cmd.Parameters.Add("@Descripción", SqlDbType.Text);
            parametros.Value = prod.descripcion;
            parametros = cmd.Parameters.Add("@Imagen", SqlDbType.Text);
            parametros.Value = prod.imagen;
            parametros = cmd.Parameters.Add("@Estado", SqlDbType.Bit);
            parametros.Value = prod.estado;

        }

        private void armarParametrosNuevoProducto(ref SqlCommand cmd, Producto prod)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = prod.nombre;
            parametros = cmd.Parameters.Add("@PU", SqlDbType.Decimal);
            parametros.Value = prod.pu;
            parametros = cmd.Parameters.Add("@Marca", SqlDbType.VarChar, 255);
            parametros.Value = prod.marca;
            parametros = cmd.Parameters.Add("@Categoria", SqlDbType.VarChar, 255);
            parametros.Value = prod.categoria;
            parametros = cmd.Parameters.Add("@Stock", SqlDbType.Int);
            parametros.Value = prod.stock;
            parametros = cmd.Parameters.Add("@Descripción", SqlDbType.Text);
            parametros.Value = prod.descripcion;
            parametros = cmd.Parameters.Add("@Imagen", SqlDbType.Text);
            parametros.Value = prod.imagen;


        }
        public int eliminarProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminar(ref cmd, prod);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spEliminarProducto");


        }
        public int bajaLogicaProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminar(ref cmd, prod);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spBajaLogicaProducto");


        }
        public int actualizarProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosActualizar(ref cmd, prod);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spActualizarProducto");


        }
        public int nuevoProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();

            armarParametrosNuevoProducto(ref cmd, prod);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spAgregarProducto");


        }
        public bool existeProducto(Producto prod)
        {
            string consulta = $"Select * From Producto WHERE Nombre = '{prod.nombre}' AND Marca = '{prod.marca}' AND Categoria = '{prod.categoria}' AND Descripción LIKE '{prod.descripcion}'";
            return ad.existe(consulta);
        }
        public bool existeProductoExactamenteIgual(Producto prod)
        {
            string consulta = $"Select * From Producto WHERE Nombre = '{prod.nombre}' AND PU = {prod.pu.ToString().Replace(',','.')} AND Marca = '{prod.marca}' AND Categoria = '{prod.categoria}' AND Stock = {prod.stock} AND Descripción LIKE '%{prod.descripcion}%' AND Imagen LIKE '%{prod.imagen}%' AND Estado = {Convert.ToInt32(prod.estado)}";
            return ad.existe(consulta);
        }
        public DataTable obtenerProductosUnicos()
        {
            return ad.abrirTabla("ProductosDistinct", "SELECT DISTINCT(Producto.Nombre), Legajo_Producto FROM Producto ORDER BY Legajo_Producto ASC");
        }
        public DataTable obtenerCategoriasUnicos()
        {
            return ad.abrirTabla("CategoriasDistinct", "SELECT DISTINCT(Producto.Categoria) FROM Producto ");
        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = ad.abrirTabla("Productos", "Select * From Producto");
            return tabla;
        }
        public DataTable obtenerTabla_DetalleDeProductosPorLegajoCompra(Compras compra)
        {
            DataTable tabla = ad.abrirTabla("DetalleCompra", $"Select  DetalleCompra.Legajo_Producto, DetalleCompra.Legajo_DetalleCompra, Producto.Nombre, Producto.Categoria, DetalleCompra.PU, DetalleCompra.Cantidad, DetalleCompra.Subtotal  from DetalleCompra INNER JOIN Producto ON DetalleCompra.Legajo_Producto = Producto.Legajo_Producto INNER JOIN Compra ON DetalleCompra.Legajo_Compra = Compra.Legajo_Compra WHERE Compra.Legajo_Compra = {compra.legajo_Compra}");
            return tabla;
        }
        public DataTable obtenerTablaProductos()
        {
            return ad.abrirTabla("Productos", "Select Legajo_Producto, Nombre, PU, Marca, Categoria, Stock, Descripción, Imagen, Estado From Producto");
        }

    }
}