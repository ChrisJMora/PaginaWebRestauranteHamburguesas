using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewGeneros
    {
        private readonly ApiUsuario _apiUsuario = ApiUsuario.Singleton();
        public GeneroCliente[] Generos { get; set; } = new GeneroCliente[0];
        public ModelViewGeneros() { }
        public async Task Inicializar()
        {
            GeneroCliente[]? generos = await _apiUsuario.ObtenerGenerosCliente();
            if (generos == null) throw new Exception($"""
                Catalogo de generos no encontrado
                """);
            Generos = generos;
        }
    }
}
