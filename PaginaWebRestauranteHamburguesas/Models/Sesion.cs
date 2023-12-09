using PaginaWebRestauranteHamburguesas.API_Service;

namespace PaginaWebRestauranteHamburguesas.Models
{
    public class Sesion
    {
        //Atributos
        private static Sesion? _instancia;
        public string? UsuarioLogeado { get; set; }

        //Constructor
        private Sesion() { }

        //Métodos
        public static Sesion Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new Sesion();
            }
            return _instancia;
        }
    }
}
