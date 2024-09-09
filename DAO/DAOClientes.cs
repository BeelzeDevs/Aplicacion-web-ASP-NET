using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
namespace DAO
{
    public class DAOClientes
    {

        AccesoDatos ad = new AccesoDatos();

        public DAOClientes()
        {

        }
        
        public Clientes obtenerCliente(Clientes cli)
        {
            DataTable dt = new DataTable();
            dt = ad.abrirTabla("Clientes", "Select * From Clientes WHERE Contraseña = '" + cli.contraseña + "' AND Nombre = '" + cli.nombre+"'");
            cli.legajo_Cliente = (Convert.ToInt32(dt.Rows[0][0].ToString()));
            cli.nombre = dt.Rows[0][1].ToString();
            cli.contraseña = dt.Rows[0][2].ToString();
            cli.dirección = dt.Rows[0][3].ToString();
            cli.teléfono = dt.Rows[0][4].ToString();
            cli.correo = dt.Rows[0][5].ToString();
            cli.fecha_nacimiento = Convert.ToDateTime(dt.Rows[0][6]);
            cli.imagen = dt.Rows[0][7].ToString();
            cli.estado = Convert.ToBoolean(dt.Rows[0][8]);

            return cli;
           
        }
        public Clientes obtenerCliente_SOLO_x_legajo(Clientes cli)
        {
            DataTable dt = new DataTable();
            dt = ad.abrirTabla("Clientes", "Select * From Clientes WHERE Legajo_Cliente = '" + cli.legajo_Cliente+"'");
            cli.legajo_Cliente = (Convert.ToInt32(dt.Rows[0][0].ToString()));
            cli.nombre = dt.Rows[0][1].ToString();
            cli.contraseña = dt.Rows[0][2].ToString();
            cli.dirección = dt.Rows[0][3].ToString();
            cli.teléfono = dt.Rows[0][4].ToString();
            cli.correo = dt.Rows[0][5].ToString();
            cli.fecha_nacimiento = Convert.ToDateTime(dt.Rows[0][6]);
            cli.imagen = dt.Rows[0][7].ToString();
            cli.estado = Convert.ToBoolean(dt.Rows[0][8]);

            return cli;

        }

        private void armarParametrosEliminar(ref SqlCommand cmd, Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Cliente", SqlDbType.Int);
            parametros.Value = cli.legajo_Cliente;


        }

        private void armarParametrosActualizar(ref SqlCommand cmd, Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = cli.nombre;
            parametros = cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            parametros.Value = cli.contraseña;
            parametros = cmd.Parameters.Add("@Dirección", SqlDbType.VarChar, 255);
            parametros.Value = cli.dirección; 
            parametros = cmd.Parameters.Add("@Teléfono", SqlDbType.VarChar, 15);
            parametros.Value = cli.teléfono;
            parametros = cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 255);
            parametros.Value = cli.correo;
            parametros = cmd.Parameters.Add("@Fecha_nacimiento", SqlDbType.Date);
            parametros.Value = cli.fecha_nacimiento;
            parametros = cmd.Parameters.Add("@Imagen", SqlDbType.VarChar, 255);
            parametros.Value = cli.imagen;
            parametros = cmd.Parameters.Add("@Estado", SqlDbType.Bit);
            parametros.Value = cli.estado;

        }

        private void armarParametrosNuevoCliente(ref SqlCommand cmd, Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = cli.nombre;
            parametros = cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            parametros.Value = cli.contraseña;
            parametros = cmd.Parameters.Add("@Dirección", SqlDbType.VarChar, 255);
            parametros.Value = cli.dirección;
            parametros = cmd.Parameters.Add("@Teléfono", SqlDbType.VarChar, 15);
            parametros.Value = cli.teléfono;
            parametros = cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 255);
            parametros.Value = cli.correo;
            parametros = cmd.Parameters.Add("@Fecha_nacimiento", SqlDbType.Date);
            parametros.Value = cli.fecha_nacimiento;
            parametros = cmd.Parameters.Add("@Imagen", SqlDbType.VarChar, 255);
            parametros.Value = "~/img/Clientes/0.jpg";

        }
        public int eliminarCliente(Clientes cli)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminar(ref cmd, cli);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spEliminarCliente");


        }
        public int actualizarCliente(Clientes cli)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosActualizar(ref cmd, cli);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spActualizarCliente");


        }
        public int nuevoCliente(Clientes cli)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosNuevoCliente(ref cmd, cli);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spAgregarCliente");


        }
        public bool existeCliente(Clientes cli)
        {
            string consulta = $"Select * From Clientes WHERE Contraseña = '{cli.contraseña}' AND Nombre = '{cli.nombre}' AND Estado = 1 ";
            return ad.existe(consulta);
        }
        public bool podriaCrearCliente(Clientes cli)
        {
            string consulta = $"Select * From Clientes WHERE Contraseña = '{cli.contraseña}' AND Nombre = '{cli.nombre}' ";
            return ad.podriaCrearCliente(consulta);
        }
        public bool correoExiste(Clientes cli)
        {
            string consulta = $"Select Correo from Clientes Where Correo = '{cli.correo}'";
            return ad.existe(consulta);
        }
        public DataTable obtenerTabla()
        {
            DataTable tabla = ad.abrirTabla("Clientes", "Select * From Clientes");
            return tabla;
        }
        public DataTable ObtenerdatatableCliente(Clientes cli)
        {
            string consulta = $"Select Legajo_Cliente as [Legajo Cliente],Nombre,Dirección,Teléfono,Correo,Fecha_nacimiento as [Fecha Nac] from clientes where Legajo_Cliente = {cli.legajo_Cliente}";
            return ad.abrirTabla("Cliente", consulta);
        }
    }
}