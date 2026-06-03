public class Usuario
{
    public string usuario;
    public string contrasena;

    public bool Validar()
    {
        bool esCorrecto = (this.usuario == "admin");
        if (esCorrecto)
        {
            Console.WriteLine("Bienvenido admin.");
        }
        else
        {
            Console.WriteLine("No puedes acceder.");
        }

        return esCorrecto;
    }
}
