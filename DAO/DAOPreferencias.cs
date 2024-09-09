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
    public class DAOPreferencias
    {
        AccesoDatos ad = new AccesoDatos();

        public DAOPreferencias()
        {

        }
        public int agregarNuevaPreferencias(Preferencias pref)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosNuevaPreferencias(pref, ref cmd);
            return ad.ejecutarProcedimientoAlmacenado(cmd, "spAgregarPreferencia");
        }
        public void ArmarParametrosNuevaPreferencias(Preferencias pref, ref SqlCommand cmd)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = cmd.Parameters.Add("@Producto_Preferido", SqlDbType.VarChar,255);
            parametros.Value = pref.producto_Preferido;
            parametros = cmd.Parameters.Add("@Interes_Categoria", SqlDbType.VarChar,255);
            parametros.Value = pref.interes_Categoria;
            parametros = cmd.Parameters.Add("@Interes_Actividad", SqlDbType.VarChar, 255);
            parametros.Value = pref.interes_Actividad;
            parametros = cmd.Parameters.Add("@Interes_Comida", SqlDbType.VarChar, 25);
            parametros.Value = pref.interes_Comida;
            parametros = cmd.Parameters.Add("@Estado", SqlDbType.Bit);
            parametros.Value = pref.estado_Cliente;
            parametros = cmd.Parameters.Add("@Legajo_Cliente", SqlDbType.Int);
            parametros.Value = pref.legajo_Cliente;
            
        }
    }
}
