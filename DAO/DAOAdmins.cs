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
    public class DAOAdmins
    {

        AccesoDatos ad = new AccesoDatos();

        public DAOAdmins()
        {

        }

        public Admins obtenerAdmin(Admins adm)
        {
            
           
            DataTable dt = new DataTable();
            dt = ad.abrirTabla("Admins", "Select * From Admins WHERE Contraseña = '" + adm.contraseña + "' AND Nombre = '"+ adm.nombre+"'");
            adm.legajo_Admin = (Convert.ToInt32(dt.Rows[0][0].ToString()));
            adm.nombre = dt.Rows[0][1].ToString();
            adm.contraseña = dt.Rows[0][2].ToString();

            return adm;
        }
        private void armarParametrosEliminar(ref SqlCommand cmd, Admins adm)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Admin", SqlDbType.Int);
            parametros.Value = adm.legajo_Admin;


        }

        private void armarParametrosActualizar(ref SqlCommand cmd, Admins adm)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Admin", SqlDbType.Int);
            parametros.Value = adm.legajo_Admin;
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = adm.nombre;
            parametros = cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            parametros.Value = adm.contraseña;

        }

        private void armarParametrosNuevoAdmin(ref SqlCommand cmd, Admins adm)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Legajo_Admin", SqlDbType.Int);
            parametros.Value = adm.legajo_Admin;
            parametros = cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 255);
            parametros.Value = adm.nombre;
            parametros = cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            parametros.Value = adm.contraseña;

        }
        public int eliminarAdmin(Admins adm)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminar(ref cmd, adm);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spEliminarAdmin");
     


        }
        public int actualizarAdmin(Admins adm)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosActualizar(ref cmd, adm);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spActualizarAdmin");


        }
        public int nuevoAdmin(Admins adm)
        {
            SqlCommand cmd = new SqlCommand();

            AccesoDatos ad = new AccesoDatos();
            int id_nuevo_admin = ad.obtenerMaximo("Select max(Legajo_Admin) from Admins") + 1;
            adm.legajo_Admin = id_nuevo_admin;
            armarParametrosNuevoAdmin(ref cmd, adm);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spAgregarAdmin");


        }
        public bool existeAdmin(Admins adm)
        {
            string consulta = $"Select * From Admins WHERE Contraseña = '{adm.contraseña}' AND Nombre = '{adm.nombre}' ";
            return ad.existe(consulta);
        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = ad.abrirTabla("Admins", "Select * From Admins");
            return tabla;
        }
         
    }
}