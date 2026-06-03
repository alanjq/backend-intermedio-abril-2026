// See https://aka.ms/new-console-template for more information
// Heredando de la clase usuario
using System.Data;

class Program : Usuario
{
    public static void Main()
    {
        // Usuario eladmin = new Usuario();
        // eladmin.usuario = "admin";

        // Console.WriteLine("Saludos desde C# dotnet", eladmin.Validar());

        // Conectarnos a la Base de datos
        // Database db = new Database();
        

        Libro libro = new Libro();
        // libro.NuevoLibro("Nuevo libro", "Este es un libro de ejemplo", 2);

        var resultados = libro.ListarLibros();
        
        Console.WriteLine(resultados.All<Libro>);

    }

}
