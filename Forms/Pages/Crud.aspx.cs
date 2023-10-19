using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using Modelo;

namespace Forms.Pages
{
    public partial class Crud : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener Id
            if (!Page.IsPostBack)
            {
                ListarCiudades();
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatosEntity();
                    tbDate.TextMode = TextBoxMode.DateTime;
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de usuario";
                            DisableTB();
                            ddlCiudades.Enabled = false;
                            break;
                        case "U":
                            this.lblTitulo.Text = "Actualizar usuario";
                            this.BtnUpdate.Visible = true;

                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar usuario";
                            DisableTB();
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void DisableTB()
        {
            tbNombre.Enabled = false;
            tbEmail.Enabled = false;
            tbEdad.Enabled = false;
            tbDate.Enabled = false;
            ddlCiudades.Enabled = false;
        }

        // SIN LINQ
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbEdad.Text = row[2].ToString();
            tbEmail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbDate.Text = d.ToString("dd/MM/yyyy");
            ListarCiudades();
            ddlCiudades.ClearSelection();
            ListItem ciudadUsuario = ddlCiudades.Items.FindByValue(row[5].ToString());
            if (ciudadUsuario != null) ciudadUsuario.Selected = true;

            con.Close();
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        // SIN LINQ
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        // SIN LINQ
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        // SIN LINQ
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            Response.Redirect("Index.aspx");
        }

        void CargarDatosEntity()
        {
            Usuarios usu = ClsUsuario.BuscarUsuariosById(int.Parse(sID));
            tbNombre.Text = usu.Nombre;
            tbEdad.Text = usu.Edad.ToString();
            tbEmail.Text = usu.Correo;
            DateTime d = (DateTime)usu.Fecha_Nacimiento;
            tbDate.Text = d.ToString("dd/MM/yyyy");
            ListarCiudades();
            ddlCiudades.ClearSelection();
            ListItem ciudadUsuario = ddlCiudades.Items.FindByValue(usu.Ciudad.ToString());
            if (ciudadUsuario != null) ciudadUsuario.Selected = true;
        }

        protected void BtnUpdate_ClickEntity(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.Id_Usuario = int.Parse(sID);
            usu.Nombre = tbNombre.Text;
            usu.Edad = int.Parse(tbEdad.Text);
            usu.Correo = tbEmail.Text;
            usu.Fecha_Nacimiento = DateTime.Parse(tbDate.Text);
            usu.Ciudad = int.Parse(ddlCiudades.SelectedValue);
            bool ok = ClsUsuario.UpdateUsuario(usu);


            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_ClickEntity(object sender, EventArgs e)
        {
            bool ok = ClsUsuario.RemoveUsuario(int.Parse(sID));
            Response.Redirect("Index.aspx");
        }

        protected void BtnCreate_ClickEntity(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.Id_Usuario = 0;
            usu.Nombre = tbNombre.Text;
            usu.Edad = int.Parse(tbEdad.Text);
            usu.Correo = tbEmail.Text;
            usu.Fecha_Nacimiento = DateTime.Parse(tbDate.Text);
            usu.Ciudad = int.Parse(ddlCiudades.SelectedValue);

            bool ok = ClsUsuario.AddUsuario(usu);
            Response.Redirect("Index.aspx");
        }

        private void ListarCiudades()
        {
            ddlCiudades.DataSource = null;
            ddlCiudades.DataBind();

            ddlCiudades.DataSource = ClsCiudad.ListarCiudades();
            ddlCiudades.DataTextField = "Nombre";
            ddlCiudades.DataValueField = "Id";
            ddlCiudades.DataBind();
        }
    }
}