using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Reflection;

namespace TP5
{
    public class Conexión
    {
       private string Ruta = "Data Source=EXOR9CE\\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";

       public void CargarProvincias(DropDownList ddlProvincia)
        {
            SqlConnection conexion3 = new SqlConnection(Ruta);
            conexion3.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter("Select * from Provincia", conexion3);

            DataSet ds = new DataSet();

            adaptador.Fill(ds,"Provincia");

            foreach (DataRow dr in ds.Tables["Provincia"].Rows)
            {
                ddlProvincia.Items.Add(dr["Id_Provincia"]+ "- " + dr["DescripcionProvincia"]);
            }

            conexion3.Close();
        }

        public void CargarGrilla(GridView gridView)
        {
            using (SqlConnection cn = new SqlConnection(Ruta))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Sucursal.Id_Sucursal,Sucursal.NombreSucursal,Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia,Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia;", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                gridView.DataSource = dr;
                gridView.DataBind();
                cn.Close();
            }
        }

        public void FiltrarID(GridView gridView, TextBox txtIdSucursal)
        {
           using (SqlConnection cn = new SqlConnection(Ruta))
           {
               cn.Open();
               SqlCommand cmd = new SqlCommand("SELECT Sucursal.Id_Sucursal,Sucursal.NombreSucursal,Sucursal.DescripcionSucursal,Provincia.DescripcionProvincia,Sucursal.DireccionSucursal FROM Sucursal INNER JOIN Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE Id_Sucursal = @IdSucursal;", cn);
               cmd.Parameters.AddWithValue("@IdSucursal", txtIdSucursal.Text);
               SqlDataReader dr = cmd.ExecuteReader();
               gridView.DataSource = dr;
               gridView.DataBind();
               txtIdSucursal.Text = "";
               cn.Close();
           }
            
        }

        public int Ejecutar(string consulta)
        {
            SqlConnection conexion4 = new SqlConnection(Ruta);
            conexion4.Open();

            SqlCommand comando = new SqlCommand(consulta,conexion4);

            int FilasAfectadas = comando.ExecuteNonQuery();

            return FilasAfectadas;
        }

    }
}