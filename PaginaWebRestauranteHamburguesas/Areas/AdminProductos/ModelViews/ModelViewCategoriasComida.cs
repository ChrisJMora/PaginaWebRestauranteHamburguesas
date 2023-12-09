using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewCategoriasComida
    {
        private readonly ApiProducto _apiProducto = ApiProducto.Singleton();
        public CategoriaComida[] Categorias { get; set; } = new CategoriaComida[0];

        public ModelViewCategoriasComida() { }

        public async Task Inicializar()
        {
            CategoriaComida[]? categorias = await _apiProducto.ObtenerCategoriasComida();
            if (categorias == null) throw new Exception($"""
                Categorias comida no encontradas
                """);
            Categorias = categorias;
        }
    }
}
