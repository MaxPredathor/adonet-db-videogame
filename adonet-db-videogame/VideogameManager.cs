using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=videogames;Integrated Security=True;Encrypt=False;TrustServerCertificate=False";
        public static void InserisciVideogame(Videogioco videogame)
        {
            string query = "INSERT INTO videogames ( name, overview, release_date, created_at, updated_at, software_house_id) " +
                           "VALUES (@Name, @OverView, @ReleaseDate, @CreatedAt, @UpdatedAt, @SoftwareHouseId)";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {                  
                    cmd.Parameters.AddWithValue("@Name", videogame.Name);
                    cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@CreatedAt", videogame.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", videogame.UpdatedAt);
                    cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseID);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Videogioco creato con successo.\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Errore: " + e.Message);
                    }
                }
            }
        }
        public static void CercaVideogiocoPerId(int videogameId)
        {
            string query = "SELECT * FROM videogames WHERE id = @videogame_id";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@videogame_id", videogameId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine($"Nome: {reader["name"]}");
                            Console.WriteLine($"Date di Rilascio: {reader["release_date"]}");
                            Console.WriteLine($"Descrizione: {reader["overview"]}");
                            Console.WriteLine($"Creato il: {reader["created_at"]}");
                            Console.WriteLine($"Aggiornato il: {reader["updated_at"]}");
                            Console.WriteLine($"Id della Casa di produzione: {reader["software_house_id"]}");
                            Console.WriteLine("-------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Nessun videogioco torvato con questo id.");
                        }

                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Errore: " + e.Message);
                    }
                }
            }
        }

        public static void CercaVideogiocoPerNome(string searchString)
        {
            string query = "SELECT * FROM videogames WHERE name LIKE @SearchString";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchString", "%" + searchString + "%");

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["id"]}");
                            Console.WriteLine($"Name: {reader["name"]}");
                            Console.WriteLine($"Data di rilascio: {reader["release_date"]}");
                            Console.WriteLine("---------------------------------------");
                        }

                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Errore: " + e.Message);
                    }
                }
            }
        }

        public static void CancellaVideogioco(int videogameId)
        {
            string query = "DELETE FROM videogames WHERE id = @videogame_id";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@videogame_id", videogameId);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Videogioco cancellato con successo.");   
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Errore: " + e.Message);
                    }
                }
            }
        }
    }
}
