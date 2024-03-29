using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Examen2
{
    public partial class EncuestaModificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string idEncuesta = Request.QueryString["id"];
                    txtID.Text = idEncuesta;
                    CargarEncuesta(idEncuesta);
                }
                else
                {
                    MostrarMensaje("No se ha proporcionado un ID para modificar un registro.");
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string idEncuesta = txtID.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string fechaNacimiento = txtFechaNacimiento.Text;
            string correo = txtCorreo.Text;
            string carroPropio = cmbCarroPropio.SelectedValue;

            ModificarEncuesta(idEncuesta, nombre, apellido, fechaNacimiento, correo, carroPropio);
            CargarEncuesta(idEncuesta);
        }

        private void CargarEncuesta(string idEncuesta)
        {
            string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";
            string query = "SELECT * FROM Encuestas WHERE id = @idEncuesta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idEncuesta", idEncuesta);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        txtFechaNacimiento.Text = reader["fecha_nacimiento"].ToString();
                        txtCorreo.Text = reader["correo"].ToString();
                        cmbCarroPropio.SelectedValue = reader["carro_propio"].ToString();
                    }
                    else
                    {
                        MostrarMensaje("No se encontró la encuesta con el ID proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al cargar la encuesta: " + ex.Message);
                }
            }
        }

        private void ModificarEncuesta(string idEncuesta, string nombre, string apellido, string fechaNacimiento, string correo, string carroPropio)
        {
            string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";
            string query = "UPDATE Encuestas SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fechaNacimiento, correo = @correo, carro_propio = @carroPropio WHERE id = @idEncuesta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@carroPropio", carroPropio);
                cmd.Parameters.AddWithValue("@idEncuesta", idEncuesta);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MostrarMensaje("Encuesta modificada exitosamente.", true);
                    }
                    else
                    {
                        MostrarMensaje("No se encontró la encuesta con el ID proporcionado.");
                    }
                }
                catch (SqlException ex)
                {
                    MostrarMensaje("Error al modificar la encuesta: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error inesperado: " + ex.Message);
                }
            }
        }

        private void MostrarMensaje(string mensaje, bool esExito = false)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esExito ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}






