using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Modelo;

namespace Forms.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTablaEntity();
        }

        // SIN LINQ
        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        void CargarTablaEntity()
        {
            gvusuarios.DataSource = ClsUsuario.BuscarUsuarios();
            gvusuarios.DataBind();
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect("~/Pages/Crud.aspx?id=" + id + "&op=R");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect("~/Pages/Crud.aspx?id=" + id + "&op=U");
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect("~/Pages/Crud.aspx?id=" + id + "&op=D");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Crud.aspx?op=C");
        }

        protected void BtnId_Click(object sender, EventArgs e)
        {
            if (TxtId.Text != "")
            {
                int id = int.Parse(TxtId.Text);
                string idString = "";
                int usuarioId = ClsLogin.IniciarSesion(id);

                if (usuarioId == 0)
                {
                    idString = "El id: " + id + " no existe en la BBDD";
                    Response.Write("<script>alert('" + idString + "')</script>");
                }
                else
                {
                    Session["usuario"] = usuarioId;
                    Response.Redirect("~/Pages/EntityTuto/InicioId.aspx");
                }
            }

        }
    }
}