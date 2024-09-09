using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades;
using System.ComponentModel;


namespace Negocio
{
    public class PedidoLogico
    {
        private DAOClientes daoCliente = new DAOClientes();
        private DAOAdmins daoAdmin = new DAOAdmins();
        private DAOProductos daoProd = new DAOProductos();
        private DAOCompras daoComp = new DAOCompras();
        private DAOPreferencias daoPref = new DAOPreferencias();
        private DAOInteracciones daoInter = new DAOInteracciones();
        private AccesoDatos ad = new AccesoDatos();


        public DataTable obtenerClientes()
        {
            return daoCliente.obtenerTabla();

        }
        public DataTable obtenerAdmins()
        {
            return daoCliente.obtenerTabla();

        }
        public DataTable obtenerProductosUnicos()
        {
            return daoProd.obtenerProductosUnicos();
        }
        public DataTable obtenerCategoriasUnicos()
        {
            return daoProd.obtenerCategoriasUnicos();
        }
        public DataTable obtenerComprasXCliente(Clientes cli)
        {
            return daoComp.obtenerTablaCliente(cli);
        }
        public bool esCliente(Clientes cliente)//se usa
        {
            return daoCliente.existeCliente(cliente);
        }
        public bool podriaCrearCliente(Clientes cliente)//se usa
        {
            return daoCliente.podriaCrearCliente(cliente);
        }
        public bool correoExiste(Clientes cliente)
        {
            return daoCliente.correoExiste(cliente);
        }
        public bool esAdmin(Admins admin)//se usa
        {
            return daoAdmin.existeAdmin(admin);
        }
        public Clientes buscarUsuario(Clientes cli)
        {
            return daoCliente.obtenerCliente(cli);
        }
        public Admins buscarUsuario(Admins adm)
        {
            return daoAdmin.obtenerAdmin(adm);
        }
       
        public Clientes buscarCliente_SOLO_x_legajo(Clientes cli)
        {
            return daoCliente.obtenerCliente_SOLO_x_legajo(cli);
        }
        
        public int nuevoCliente(Clientes cli)
        {
           return daoCliente.nuevoCliente(cli);
        }

        public int agregarProducto(Producto prod)
        {
            return daoProd.nuevoProducto(prod);
        }
        public int agregarPreferencia(Preferencias pref)
        {
            return daoPref.agregarNuevaPreferencias(pref);
        }
        public int agregarInteraccion(Interacciones inter)
        {
            return daoInter.agregarInteraccion(inter);
        }

        public bool existeProducto(Producto prod)
        {
            return daoProd.existeProducto(prod);
        }
        public bool existeProductoExactamenteIgual(Producto prod)
        {
            return daoProd.existeProductoExactamenteIgual(prod);
        }
       public DataTable devolverdataset(string nombre_tabla,string consulta)
        {
            return ad.abrirTabla(nombre_tabla, consulta);

        }
        public DataTable abrirListaProductos()
        {
            return daoProd.obtenerTablaProductos();
        }

        public DataTable ObtenerdatatableCliente(string legajo_cliente)
        {
            string consulta = $"Select Legajo_Cliente as [Legajo Cliente],Nombre,Dirección,Teléfono,Correo,Fecha_nacimiento as [Fecha Nac] from clientes where Legajo_Cliente = {legajo_cliente}";
            return ad.abrirTabla("Clientes", consulta);
        }
        public DataTable ObtenerdatatableCliente2(Clientes cli)
        {
            return daoCliente.ObtenerdatatableCliente(cli);
        }
       
        
        public DataTable obtenerTabla_DetalleDeProductosPorLegajoCompra(Compras compra)
        {
            return daoProd.obtenerTabla_DetalleDeProductosPorLegajoCompra(compra);
        }

        public DataTable abrirTabla_Compras_FiltradaxFECHA(string fecha)
        {
            string consulta = "SELECT [Legajo_Compra], [Fecha], [Cantidad], [Legajo_Cliente] FROM [Compra] Where [Fecha] LIKE " + "'%" + fecha + "%'";
            return ad.abrirTabla("listar_compra", consulta);

        }
        public DataTable abrirTabla_Compras()
        {
            string consulta = "SELECT [Legajo_Compra], [Fecha], [Total], [Legajo_Cliente] FROM [Compra]";
            return ad.abrirTabla("listar_compra", consulta);

        }
        public DataTable abrirtabla_Productos()
        {
            string consulta = "SELECT Legajo_Producto,Nombre,PU,Marca,Categoria,Stock,Descripción,Imagen, Estado From Producto";
            return ad.abrirTabla("listar_producto", consulta);
        }
        public void actualizarProducto(Producto prod)
        {
            daoProd.actualizarProducto(prod);
          
        }
        public int eliminarProducto(Producto prod)
        {
            return daoProd.eliminarProducto(prod);

        }
        public Producto obtenerproducto(Producto prod)
        {
            return daoProd.obtenerProducto(prod);
        }
        public Producto buscarProductoEnSession(DataTable dt, Producto prod)
        {
            Producto aux = null;

            foreach (DataRow dr in dt.Rows) 
            {

                if ( Convert.ToInt32(dr["legajo_Producto"]) == prod.legajo_Producto)
                {
                    aux = new Producto();
                    aux.legajo_Producto = Convert.ToInt32(dr["Legajo_Producto"]);
                    aux.nombre = dr["Nombre"].ToString();
                    aux.pu = Convert.ToDecimal(dr["PU"]);
                    aux.marca = dr["Marca"].ToString();
                    aux.categoria = dr["Categoria"].ToString();
                    aux.stock = Convert.ToInt32(dr["Stock"]);
                    aux.descripcion = dr["Descripción"].ToString();
                    aux.imagen = dr["Imagen"].ToString();
                    aux.estado = Convert.ToBoolean(dr["Estado"]);
                }
            }
            return aux;
        }
        public DataTable modificarStockProductoEnSession(DataTable dt, Producto prod)
        {
            foreach(DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["legajo_Producto"]) == prod.legajo_Producto)
                {
                    dr["Stock"] = Convert.ToString(prod.stock);
                }
            }
            return dt;
        }
        public DataTable sumarStockProductoEnSession(DataTable dt, Producto prod)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["legajo_Producto"]) == prod.legajo_Producto)
                {
                    dr["Stock"] = Convert.ToString(Convert.ToInt32(dr["Stock"]) + 1);
                }
            }
            return dt;
        }
        public DataTable restarStockProductoEnSession(DataTable dt, Producto prod)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["legajo_Producto"]) == prod.legajo_Producto)
                {
                    if ( Convert.ToInt32(dr["Stock"]) - 1 >= 0) dr["Stock"] = Convert.ToString(Convert.ToInt32(dr["Stock"]) - 1);
                }
            }
            return dt;
        }
        public bool puedeRestarseProductoEnSession(DataTable dt, Producto prod)
        {
            foreach(DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["legajo_Producto"]) == prod.legajo_Producto)
                {
                    if (Convert.ToInt32(dr["Stock"]) - 1 >= 0)
                    return true;
                }
            }
            return false;
        }
        public DataTable FiltrarProducto_x_Descripcion(Producto prod)
        {
            string consulta = "SELECT Legajo_Producto,Nombre,PU,Marca,Categoria,Stock,Descripción,Imagen,Estado FROM Producto Where Descripción LIKE '%"+ prod.descripcion + "%'" ;
            return ad.abrirTabla("filtrar_producto_x_desc", consulta);
        }

        public bool AgregarSucursal(String nombre, String descripcion, String provincia, String direccion)
        {
            String consulta = $"INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES ('{nombre}', '{descripcion}', '{provincia}', '{direccion}')";
            int filasAfectadas = ad.EjecutarProcedimientos(consulta);
            return filasAfectadas > 0;

        }
        public DataTable abrirTabla_listarSucursales()
        {
            string consulta = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [DescripcionProvincia], [DireccionSucursal] FROM[Sucursal] INNER JOIN[Provincia] ON[Sucursal].Id_ProvinciaSucursal = [Provincia].Id_Provincia";
            return ad.abrirTabla("listar_sucursales", consulta);

        }
        public DataTable abrirTabla_listarSucursales_FiltradaxIDSUCURSAL(/*Sucursal*/ Admins sucursal)
        {
            string consulta = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [DescripcionProvincia], [DireccionSucursal] FROM[Sucursal] INNER JOIN[Provincia] ON[Sucursal].Id_ProvinciaSucursal = [Provincia].Id_Provincia WHERE [Sucursal].Id_Sucursal LIKE " + "'%" + sucursal.legajo_Admin + "%'";
            return ad.abrirTabla("listar_sucursales", consulta);

        }
        public DataTable abrir_tabla_Consultas()
        {
            string consulta = "SELECT Legajo_Interaccion,Fecha,Tipo,Motivo,Descripción,Legajo_Cliente from Interaccion ";
            return ad.abrirTabla("listar_consultas", consulta);

        }
        public DataTable abri_tabla_Consultas_FiltroxLegajo(string legajo)
        {
            string consulta = "SELECT Legajo_Interaccion,Fecha,Tipo,Motivo,Descripción,Legajo_Cliente from Interaccion Where Legajo_Cliente LIKE '%" + legajo+"%'";
            return ad.abrirTabla("listar_consultas_Filtrada", consulta);

        }
        public DataTable abrir_tabla_preferencia_x_legajo(int legajo)
        {
            string consulta = "SELECT Legajo_Preferencia,Producto_Preferido,Interes_Categoria,Interes_Actividad,Interes_Comida,Legajo_Cliente FROM Preferencias Where Legajo_Cliente = " + legajo;
            return ad.abrirTabla("preferencia_cliente", consulta);
        }
        public DataTable abrir_tabla_preferencias()
        {
            string consulta = "SELECT Legajo_Preferencia,Producto_Preferido,Interes_Categoria,Interes_Actividad,Interes_Comida,Legajo_Cliente FROM Preferencias ";
            return ad.abrirTabla("preferencia_cliente", consulta);
        }
        public DataTable abrir_tabla_preferencia_LIKE_legajo(int legajo)
        {
            string consulta = "SELECT Legajo_Preferencia,Producto_Preferido,Interes_Categoria,Interes_Actividad,Interes_Comida,Legajo_Cliente FROM Preferencias Where Legajo_Cliente LIKE '%" + legajo+"%'";
            return ad.abrirTabla("preferencia_cliente", consulta);
        }
        public DataTable obtener_Cliente_x_Legajo(int legajo)
        {
            string consulta = "SELECT Legajo_Cliente,Nombre,Contraseña,Dirección,Teléfono,Correo,Fecha_nacimiento,Estado from Clientes Where Legajo_Cliente LIKE '%" + legajo + "%'";
            return ad.abrirTabla("preferencia_Cliente", consulta);
        }
        public DataTable obtener_Cliente_conFILTRO(string filtro)
        {
            string consulta = "SELECT [Legajo_Cliente], [Nombre], [Contraseña], [Dirección], [Teléfono], [Correo], [Fecha_nacimiento] , [Estado], [Imagen] FROM [Clientes] WHERE [Nombre] LIKE '%" + filtro + "%'";
            return ad.abrirTabla("listar_Clientes", consulta);
        }
        public DataTable obtener_Cliente_sinFILTRO()
        {
            string consulta = "SELECT [Legajo_Cliente], [Nombre], [Contraseña], [Dirección], [Teléfono], [Correo], [Fecha_nacimiento] , [Estado], [Imagen] FROM [Clientes]";
            return ad.abrirTabla("listar_Clientes", consulta);
        }

        public DataTable actualizar_cliente(Clientes cli)
        {
            string consulta = "Update Clientes set Nombre = '"+cli.nombre+ "', Contraseña= '"+cli.contraseña+ "', Dirección= '"+cli.dirección+ "', Teléfono= '"+cli.teléfono+ "', Correo= '"+cli.correo+ "',Fecha_nacimiento= '"+cli.fecha_nacimiento+ "',Estado= '"+cli.estado+ "', Imagen = '"+cli.imagen +"' Where Legajo_Cliente = "+cli.legajo_Cliente;
            return ad.abrirTabla("actualizar_Clientes", consulta);

        }
        public string cantidad_interacciones(Clientes cli)
        {
            string consulta = "select count(Legajo_Cliente)as cantidad from Interaccion where Legajo_Cliente = '" + cli.legajo_Cliente +"'" ;
            return ad.obtener_String_Consulta(consulta);

        }
        public string cantidad_interacciones_MOTIVOsoporte(Clientes cli)
        {
            string consulta = "select count(Legajo_Cliente) as cantidad from Interaccion where Motivo='Soporte técnico' AND Legajo_Cliente = '" + cli.legajo_Cliente + "'";
            return ad.obtener_String_Consulta(consulta);

        }
        public string cantidad_interacciones_MOTIVOconsulta(Clientes cli)
        {
            string consulta = "select count(Legajo_Cliente) as cantidad from Interaccion where Motivo='Consulta' AND Legajo_Cliente = '" + cli.legajo_Cliente + "'";
            return ad.obtener_String_Consulta(consulta);

        }
        public DataTable obtenerTablaCompras(Clientes cli) //se uso
        { 
            return daoComp.obtenerTablaCompras(cli);
        }
        public DataTable obtenerTablaDetalleCompras(Compras compras)
        {
            return daoComp.obtenerTablaDetalleCompra(compras);
        }



        public bool EliminarSucursal(/*Sucursal*/ Admins suc)
        {
            /*    AccesoDatos acceso_de_datos = new AccesoDatos();
                DAOSucursales dao_sucursal = new DAOSucursales();
                bool estado = dao_sucursal.existeSucursal(suc);
                if (estado)
                {
                    String consulta = "DELETE FROM Sucursal WHERE Id_Sucursal = " + suc.Legajo_Admin1;
                    int filasAfectadas = acceso_de_datos.EjecutarProcedimientos(consulta);
                    return filasAfectadas > 0;
                }
                return estado;
            */
            return false;
        }
    }
}
