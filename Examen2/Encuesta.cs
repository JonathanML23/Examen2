using System;
using System.Data.SqlClient;

public class EncuestaService
{
    public int cantidad_encuestas { get; set; }
    public int cantidad_si { get; set; }
    public int cantidad_no { get; set; }

    public void ObtenerInformacionEncuestas()
    {
        string connectionString = @"Data Source=MINI-CEBOLLITA\JONATHAN;Initial Catalog=EncuestasDB;Integrated Security=True";
        string query = "SELECT COUNT(*) AS total_encuestas, " +
                       "SUM(CASE WHEN carro_propio = 'Si' THEN 1 ELSE 0 END) AS personas_con_carro_propio, " +
                       "SUM(CASE WHEN carro_propio = 'No' THEN 1 ELSE 0 END) AS personas_sin_carro_propio " +
                       "FROM Encuestas";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cantidad_encuestas = Convert.ToInt32(reader["total_encuestas"]);
                    cantidad_si = Convert.ToInt32(reader["personas_con_carro_propio"]);
                    cantidad_no = Convert.ToInt32(reader["personas_sin_carro_propio"]);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                // Aquí podrías manejar la excepción de manera adecuada, como registrarla o lanzarla nuevamente
                throw new Exception("Error al obtener información de encuestas: " + ex.Message);
            }
        }
    }
}


