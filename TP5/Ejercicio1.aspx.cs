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
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProvincia.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                Conexión conexión = new Conexión();
                conexión.CargarProvincias(ddlProvincia);
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string consulta = "insert into Sucursal(NombreSucursal, DescripcionSucursal, DireccionSucursal, Id_ProvinciaSucursal) " +
                 "values('" + txtNombreSucursal.Text + "','" + txtDescripción.Text + "', '" + txtDirección.Text + "', " + DevuelveId_ProvinciaSucursal() + ")";

            Conexión conexion2 = new Conexión();

            int filasafectadas = conexion2.Ejecutar(consulta);

            if(filasafectadas > 0)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "La sucursal se ha agregado con éxito";
            }

            LimpiarCampos();
        }

        public int DevuelveId_ProvinciaSucursal()
        {
            int Id_Provincia_Sucursal = 0;
            // Asegurarse de que haya un elemento seleccionado
            if (ddlProvincia.SelectedIndex > 0) // Evita seleccionar el índice 0 si es un elemento "Seleccione"
            {
                // Obtiene el valor de la provincia seleccionada y lo convierte en int
                Id_Provincia_Sucursal = ddlProvincia.SelectedIndex;
            }
            return Id_Provincia_Sucursal; // Devuelve 0 si no se seleccionó ninguna provincia
        }


        //public int DevuelveId_ProvinciaSucursal()
        //{
        //    int Id_Provincia_Sucursal = 1;

        //    // Asegurarse de que haya un elemento seleccionado
        //    if (ddlProvincia.SelectedIndex > 0) // Evita seleccionar el índice 0 si es un elemento "Seleccione"
        //    {
        //        // Intenta convertir el valor seleccionado (que debería ser el ID de la provincia) en un entero
        //        if (int.TryParse(ddlProvincia.SelectedValue, out Id_Provincia_Sucursal))
        //        {
        //            return Id_Provincia_Sucursal; // Devuelve el ID si es un entero válido
        //        }
        //        else
        //        {
        //            // Manejar el caso en que el valor no sea un entero válido
        //            // Podrías manejar un error aquí si es necesario
        //        }
        //    }

        //    return Id_Provincia_Sucursal; // Devuelve 0 si no se seleccionó ninguna provincia o si la conversión falla
        //}


        void LimpiarCampos()
        {
            txtNombreSucursal.Text = "";
            txtDirección.Text = "";
            txtDescripción.Text = "";
        }


    }
}