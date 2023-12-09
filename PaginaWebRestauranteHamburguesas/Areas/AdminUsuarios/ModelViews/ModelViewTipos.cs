using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewTipos
    {
        private readonly ApiUsuario _apiUsuario = ApiUsuario.Singleton();
        public TipoUsuario[] Tipos { get; set; } = new TipoUsuario[0];
        public ModelViewTipos() { }
        public async Task Inicializar()
        {
            TipoUsuario[]? tipos = await _apiUsuario.ObtenerTiposUsuario();
            if (tipos == null) throw new Exception($"""
                Catálogo de tipos de usuario no encontrado
                """);
            Tipos = tipos;
        }
    }
}