using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOInteracciones
    {
        private AccesoDatos ad = new AccesoDatos();
        public DAOInteracciones() { }
        public int agregarInteraccion( Interacciones interac)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosNuevaInteraccion(ref cmd, interac);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spAgregarInteraccion");
        }
        public void ArmarParametrosNuevaInteraccion(ref SqlCommand cmd,Interacciones inter )
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
            parametros.Value = inter.fecha;
            parametros = cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 255);
            parametros.Value = inter.tipo;
            parametros = cmd.Parameters.Add("@Motivo", SqlDbType.VarChar, 255);
            parametros.Value = inter.motivo;
            parametros = cmd.Parameters.Add("@Descripcion", SqlDbType.Text);
            parametros.Value = inter.descripcion;
            parametros = cmd.Parameters.Add("@Legajo_Cliente", SqlDbType.Int);
            parametros.Value = inter.legajo_Cliente;

        }
    }
}
