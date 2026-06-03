using Org.BouncyCastle.Asn1.Misc;

class Libro : Database
{
    private int id;
    private string titulo;
    private string descripcion;
    private string portada;
    private int idautor;

    public Libro()
    {
    }

    public Libro(string titulo,string descripcion,int idautor)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.idautor = idautor;
    }

    public void NuevoLibro(string titulo, string descripcion,int idautor)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.idautor = idautor;
    }

    public IEnumerable<Libro> ListarLibros()
    {
        return base.ListarTodo("*", "libro");
    }

}