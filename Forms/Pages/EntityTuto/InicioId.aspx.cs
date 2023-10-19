using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forms.Pages.EntityTuto
{
    public partial class InicioId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSession();
            if (!Page.IsPostBack)
            {
                Usuarios usuario = ClsUsuario.BuscarUsuariosById(Int32.Parse(Session["usuario"].ToString()));

                lblId.Text = usuario.Nombre.ToUpper();
            }

        }

        private void VerificarSession()
        {
            if (Session["usuario"] == null)
                Response.Redirect("~/Pages/Index.aspx");
        }

        protected void lnkCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Pages/Index.aspx");
        }
    }
}