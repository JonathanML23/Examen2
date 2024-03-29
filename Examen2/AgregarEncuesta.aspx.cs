using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace Examen2
{
    public partial class VistaEncuesta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                cmbCarroPropio.SelectedItem == null)
            {
                MostrarMensaje("Todos los campos son obligatorios.");
                return;
            }

            if (!DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fechaNacimiento))
            {
                MostrarMensaje("La fecha de nacimiento no es válida.");
                return;
            }

            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                edad--;

            if (edad < 18 || edad > 50)
            {
                MostrarMensaje("La edad debe estar entre 18 y 50 años.");
                return;
            }

            string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Encuestas (nombre, apellido, fecha_nacimiento, correo, carro_propio) VALUES (@nombre, @apellido, @fecha_nacimiento, @correo, @carro_propio)", connection);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@carro_propio", cmbCarroPropio.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MostrarMensaje("Encuesta guardada exitosamente.", true);
                    LimpiarCampos();
                    CargarEncuestas();
                }
                catch (SqlException ex)
                {
                    MostrarMensaje("Error al guardar la encuesta: " + ex.Message);
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

                    gvDatos.DataSource = dataTable;
                    gvDatos.DataBind();
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

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            cmbCarroPropio.SelectedIndex = -1;
        }
    }
}



