﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TIF_Grupo_12.Indice_administrador
{
    public partial class adm_PreferenciasClientes : System.Web.UI.Page
    {
        private Admins adm = new Admins();
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
                cargargreedview();
                cargarlistview();
                
            }

        }
        private void cargargreedview()
        {
            gv_PreferenciasClientes.DataSource = pl.abrir_tabla_preferencias();
            gv_PreferenciasClientes.DataBind();

        }
        private void cargarlistview()
        {
            lv_Clientes.DataSource = pl.obtenerClientes();
            lv_Clientes.DataBind();
        }

        protected void btn_Filtro_Click(object sender, EventArgs e)
        {
            string num = txt_BusquedaxLegajo.Text.Trim();
            txt_BusquedaxLegajo.Text = "";
            if (esnumero(num))
            {
                ViewState["LegajoFilter"] = num;

                gv_PreferenciasClientes.DataSource = pl.abrir_tabla_preferencia_LIKE_legajo(Convert.ToInt32(num));
                gv_PreferenciasClientes.DataBind();
                lv_Clientes.DataSource = pl.obtener_Cliente_x_Legajo(Convert.ToInt32(num));
                lv_Clientes.DataBind();
            }
            else
            {
                ViewState["LegajoFilter"] = null;
                cargarlistview();
                cargargreedview();
            }
        }
        private bool esnumero(string numero)
        {
            int valor = 0;

            if (int.TryParse(numero, out valor))
            {
                if (valor > 0) return true;
                else return false;
            }
            else return false;

        }

        protected void gv_PreferenciasClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_PreferenciasClientes.PageIndex = e.NewPageIndex;
            cargargreedview();
        }

       

        protected void lv_Clientes_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            (lv_Clientes.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            if (ViewState["LegajoFilter"] != null)
            {
                int num = Convert.ToInt32(ViewState["LegajoFilter"]);
                lv_Clientes.DataSource = pl.obtener_Cliente_x_Legajo(num);
            }
            else
            {
                lv_Clientes.DataSource = pl.obtenerClientes();
            }
            lv_Clientes.DataBind();
        }
    }
}