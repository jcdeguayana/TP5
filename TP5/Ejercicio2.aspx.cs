using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP5
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Conexión cn = new Conexión();
                cn.CargarGrilla(grdSucursales);
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Conexión cn2 = new Conexión();
            cn2.FiltrarID(grdSucursales,txtIdSucursal);
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            Conexión cn3 = new Conexión();
            cn3.CargarGrilla(grdSucursales);
        }
    }
}