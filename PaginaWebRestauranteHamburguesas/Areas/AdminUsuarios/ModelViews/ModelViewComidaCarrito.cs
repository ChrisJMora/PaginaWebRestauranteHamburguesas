using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewComidaCarrito
    {
        private readonly ApiProducto _apiProducto = ApiProducto.Singleton();

        public int ComidaCarritoId { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        public int? ComboCarritoId { get; set; }
        public int ComidaId { get; set; }
        public ModelViewComida Comida { get; set; } = new ModelViewComida();

        public ModelViewComidaCarrito() { }

        public async Task Inicializar(ComidaCarrito comidaCarrito)
        {
            Comida? comida = await _apiProducto.ObtenerComida(comidaCarrito.IdComida);
            if (comida == null) throw new Exception($"""
                La comida del producto con id: {comidaCarrito.Id} no fue encontrada
                """);
            ComidaCarritoId = comidaCarrito.Id;
            OrdenId = comidaCarrito.IdOrden;
            Cantidad = comidaCarrito.Cantidad;
            ComboCarritoId = comidaCarrito.IdComboCarrito;
            ComidaId = comidaCarrito.IdComida;
            await Comida.Inicializar(comida);
        }
    }
}
