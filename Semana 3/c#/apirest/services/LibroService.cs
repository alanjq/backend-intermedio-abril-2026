using MySql.Data.MySqlClient;
using APIREST.Models;
using System.Configuration;

// namespace APIREST.Services;

public class LibroService
{
    private readonly string _connectionString;
    private string columns = "id, titulo, descripcion, idautor";
    private string tablename = "libro";

    public LibroService(){
        _connectionString = "Server=127.0.0.1;Port=3306;Database=libros;User=root;Password=root;";
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    public IEnumerable<Libro> GetAll()
    {
        var lista= new List<Libro>();
        using var conn = GetConnection();
        conn.Open();

        string sql = "SELECT "+this.columns+" FROM " + this.tablename;

        using var cmd = new MySqlCommand(sql, conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            lista.Add(new Libro
            {
                id = reader.GetInt32("id"),
                titulo = reader.GetString("titulo"),
                descripcion = reader.GetString("descripcion"),
                idautor = reader.GetInt32("idautor")
            });
        }

        return lista;
    }


    public Libro Create(Libro lib)
    {
        using var conn = GetConnection();
        conn.Open();

        string sql = "INSERT INTO "+this.tablename+" ("+ this.columns+") VALUES (@titulo, @descripcion, @idautor)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@titulo", lib.titulo);
        cmd.Parameters.AddWithValue("@descripcion", lib.descripcion);
        cmd.Parameters.AddWithValue("@idautor", lib.idautor);

        lib.id = Convert.ToInt32(cmd.ExecuteScalar());

        return lib;

    }
}
