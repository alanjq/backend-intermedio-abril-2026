using MySql.Data.MySqlClient;

class Database
{
    private string cadenaConexion = "Server=127.0.0.1;Port=3306;Database=libros;User ID=root;Password=root";

    protected void ConexionSql()
    {
        using var conexion = new MySqlConnection(this.cadenaConexion);

        try
        {
            conexion.Open();
            Console.WriteLine("Conexión a SQL correcta.");

            string query = "SELECT titulo FROM libro limit 1";

            using var cmd = new MySqlCommand(query, conexion);
            var result = cmd.ExecuteScalar();

            Console.WriteLine("HORA: " + result);

        }catch(Exception ex){
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }

    protected void Insertar()
    {
        
    }

    protected void Eliminar(){}
    protected void Actualizar(){}

    protected IEnumerable<Libro> ListarTodo(string columnas, string tabla)
     {
        using var conexion = new MySqlConnection(this.cadenaConexion);

        // try
        // {
            // los resultados como objetos
            var lista = new List<Libro>();

            conexion.Open();
            Console.WriteLine("Conexión a SQL correcta.");

            string query = "SELECT "+ columnas + " FROM "+ tabla;

            using var cmd = new MySqlCommand(query, conexion);
            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                lista.Add(new Libro(
                   result.GetString("titulo"),
                   result.GetString("descripcion"),
                   result.GetInt32("idautor")
                ));
            }

            return lista;

            
            // Console.WriteLine("RESULTADO: " + result);

        // }catch(Exception ex){
        //     Console.WriteLine("ERROR: " + ex.Message);
        // }
    }

    protected void BuscarPorId(){}
}
