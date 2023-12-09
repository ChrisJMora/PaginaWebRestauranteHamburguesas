using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewEstados
    {
        private readonly ApiEstado _apiEstado = ApiEstado.Singleton();
        public Estado[] Estados { get; set; } = new Estado[0];
        public ModelViewEstados() { }
        public async Task Inicializar()
        {
            Estado[]? estados = await _apiEstado.ObtenerEstados();
            if (estados == null) throw new Exception($"""
                Catálogo de estados no encontrado
                """);
            Estados = estados;
        }
    }
}
