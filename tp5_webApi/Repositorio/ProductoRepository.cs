using Microsoft.Data.Sqlite;
using Producto_space;
using Presupuesto_space;
public class ProductoRepository
{
    string connectionString = "Data Source=db/Tienda.db;Cache=Shared;";

    void CrearPresupuesto(Presupuesto presupuesto)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            
            string query = "INSERT INTO Presupuestos(NombreDestinatario, FechaCreacion) VALUES (" + $"{presupuesto.NombreDestinatario}, {DateTime.Now};";

            SqliteCommand command = new SqliteCommand(query, connection);


            connection.Close();
        }
    }
}