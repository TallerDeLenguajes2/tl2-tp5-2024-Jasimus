using Presupuesto_space;
using Microsoft.Data.Sqlite;


public class PresupuestoRepository
{
    string connectionString = "Data Source=db/Tienda.db;Cache=Shared;";
    int CrearPresupuesto(Presupuesto presupuesto)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
                
            string query = "INSERT INTO Presupuestos(NombreDestinatario, FechaCreacion) VALUES (" + $"{presupuesto.NombreDestinatario}, {DateTime.Now};";

            SqliteCommand command = new SqliteCommand(query, connection);

            return command.ExecuteNonQuery();

            connection.Close();
        }
    }

}
