using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewCategoriasCombo
    {
        private readonly ApiProducto _apiProducto = ApiProducto.Singleton();
        public CategoriaCombo[] Categorias { get; set; } = new CategoriaCombo[0];

        public ModelViewCategoriasCombo() { }

        public async Task Inicializar()
        {
            CategoriaCombo[]? categorias = await _apiProducto.ObtenerCategoriasCombo();
            if (categorias == null) throw new Exception($"""
                Categorias combo no encontradas
                """);
            Categorias = categorias;
        }
    }
}
