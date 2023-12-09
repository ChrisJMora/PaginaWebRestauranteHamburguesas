using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Producto;
using PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewComida
    {
        private ApiProducto _apiProducto = ApiProducto.Singleton();
        private ApiEstado _apiEstado = ApiEstado.Singleton();

        public int ComidaId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
        public double Precio { get; set; }
        public string Nombre { get; set; } = "default";
        public string Descripcion { get; set; } = "default";
        public string Categoria { get; set; } = "default";
        public string Estado { get; set; } = "default";
        public bool ComidaEliminable { get; set; }
        public ModelViewCategoriasComida CategoriasComida { get; set; } = new ModelViewCategoriasComida();

        public ModelViewComida() { }

        public async Task Inicializar(Comida comida)
        {
            CategoriaComida[]? categorias = await _apiProducto.ObtenerCategoriasComida();
            if (categorias == null) throw new Exception($"""
                La categorias de la comida: {comida.Nombre} no fueron encontradas
                """);
            CategoriaComida? categoria = await _apiProducto.ObtenerCategoriaComida(comida.IdCategoriaComida);
            if (categoria == null) throw new Exception($"""
                La categoria de la comida: {comida.Nombre} no fue encontrada
                """);
            Estado? estado = await _apiEstado.ObtenerEstado(comida.IdEstadoComida);
            if (estado == null) throw new Exception($"""
                El estado de la comida: {comida.Nombre} no fue encontradao
                """);
            await CategoriasComida.Inicializar();
            ComidaId = comida.Id;
            Nombre = comida.Nombre;
            Descripcion = comida.Descripcion;
            Precio = comida.Precio;
            CategoriaId = categoria.Id;
            EstadoId = comida.IdEstadoComida;
            Categoria = categoria.Etiqueta;
            Estado = estado.Etiqueta;
            ComidaEliminable = await _apiProducto.ComidaEliminable(ComidaId);
        }
    }
}
