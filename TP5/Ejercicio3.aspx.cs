using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP5
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEliminar.Text,out int Id_Sucursal)) {
                string consulta = "DELETE FROM Sucursal WHERE Id_Sucursal=" + Id_Sucursal + "AND Id_Sucursal IS NOT NULL";
                Conexión cn = new Conexión();
                int filasafectadas = cn.Ejecutar(consulta);
                if (filasafectadas > 0)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "La sucursal se ha eliminado con éxito";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "El ID ingresado es inexistente";
                }
                txtEliminar.Text = "";
            }
            else
            {
                lblMensaje.Text = "El valor a ingresar debe ser numérico";
            }
        }
    }
}