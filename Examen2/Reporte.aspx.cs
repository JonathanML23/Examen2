using System;

namespace Examen2
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EncuestaService servicio = new EncuestaService();
                servicio.ObtenerInformacionEncuestas();

                // Asignar los valores a las etiquetas
                lblTotalEncuestas.Text = servicio.cantidad_encuestas.ToString();
                lblCantidadSi.Text = servicio.cantidad_si.ToString();
                lblCantidadNo.Text = servicio.cantidad_no.ToString();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar el reporte: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            // Muestra el mensaje de error en un control Label
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = System.Drawing.Color.Red;
        }
    }
}

