using MySql.Data.MySqlClient;
using APIREST.Models;
using System.Configuration;
using System.Text;
using System.Xml;
using Swashbuckle.AspNetCore.SwaggerUI;

// namespace APIREST.Services;

public class LibroService
{
    private readonly string _connectionString;
    private string columns = "id, titulo, descripcion, idautor";
    private string tablename = "libro";

    public LibroService()
    {
        _connectionString = "Server=127.0.0.1;Port=3306;Database=libros;User=root;Password=root;";
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    public Libro GetById(int id)
    {
        using var conn = GetConnection();
        conn.Open();

        string sql = "SELECT " + this.columns + " FROM " + this.tablename + " WHERE id = @id";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {

            Libro resultado = new Libro();
            resultado.id = reader.GetInt32("id");
            resultado.titulo = reader.GetString("titulo");
            resultado.descripcion = reader.GetString("descripcion");
            resultado.idautor = reader.GetInt32("idautor");
            return resultado;
        }

        return new Libro();

    }


    public IEnumerable<Libro> SearchByTitle(string title)
    {
        var lista = new List<Libro>();
        using var conn = GetConnection();
        conn.Open();

        string sql = "SELECT " + this.columns + " FROM " + this.tablename + " WHERE titulo = @title";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@title", title);

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


    public IEnumerable<Libro> GetAll()
    {
        var lista = new List<Libro>();
        using var conn = GetConnection();
        conn.Open();

        string sql = "SELECT " + this.columns + " FROM " + this.tablename;

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

        string sql = "INSERT INTO " + this.tablename + " (titulo, descripcion, idautor) VALUES (@titulo, @descripcion, @idautor)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@titulo", lib.titulo);
        cmd.Parameters.AddWithValue("@descripcion", lib.descripcion);
        cmd.Parameters.AddWithValue("@idautor", lib.idautor);

        lib.id = Convert.ToInt32(cmd.ExecuteNonQuery());

        return lib;

    }

     public Libro Update(Libro lib)
    {
        using var conn = GetConnection();
        conn.Open();

        string sql = "UPDATE " + this.tablename + " SET titulo=@titulo, descripcion=@descripcion, idautor=@idautor WHERE id=@id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@titulo", lib.titulo);
        cmd.Parameters.AddWithValue("@descripcion", lib.descripcion);
        cmd.Parameters.AddWithValue("@idautor", lib.idautor);
        cmd.Parameters.AddWithValue("@id", lib.id);

        cmd.ExecuteNonQuery();
        
        return lib;
    }


    public bool delete(int id)
    {
        using var conn = GetConnection();
        conn.Open();

        string sql = "DELETE FROM libro WHERE id=@id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        return cmd.ExecuteNonQuery() > 0;
    }

}
