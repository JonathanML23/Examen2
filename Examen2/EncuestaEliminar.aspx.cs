using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Examen2
{
    public partial class EliminarEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string idEncuesta = btnEliminar.CommandArgument;

            // Realizar la eliminación de la encuesta con el ID obtenido
            string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Encuestas WHERE Id = @id", connection);
                    cmd.Parameters.AddWithValue("@id", idEncuesta);
                    cmd.ExecuteNonQuery();
                    MostrarMensaje("Encuesta eliminada correctamente.", true);
                    CargarEncuestas(); // Actualizar el GridView después de eliminar la encuesta
                }
                catch (SqlException ex)
                {
                    MostrarMensaje("Error al eliminar la encuesta: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error inesperado: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void CargarEncuestas()
        {
            string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Encuestas", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gvEncuestas.DataSource = dataTable;
                    gvEncuestas.DataBind();
                }
                catch (SqlException ex)
                {
                    MostrarMensaje("Error al cargar las encuestas: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error inesperado: " + ex.Message);
                }
                finally
                {
                    connection.Close();
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



