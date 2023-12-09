using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewComboCarrito
    {
        private readonly ApiProducto _apiProducto = ApiProducto.Singleton();
        private readonly ApiCarrito _apiCarrito = ApiCarrito.Singleton();

        public int ComboCarritoId { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        public int ComboId { get; set; }
        public double Subtotal { get; set; }
        public double PrecioTotal { get; set; }
        public ModelViewCombo Combo { get; set; } = new ModelViewCombo();
        public List<ModelViewComidaCarrito> ComidasCarritoCombo { get; set; } =  new List<ModelViewComidaCarrito>();

        public ModelViewComboCarrito() { }

        public async Task Inicializar(ComboCarrito comboCarrito)
        {
            Combo? combo = await _apiProducto.ObtenerCombo(comboCarrito.IdCombo);
            if (combo == null) throw new Exception($"""
                El combo del producto con id: {comboCarrito.Id} no fue encontrado
                """);
            double precio = await _apiCarrito.CalcularTotalCombo(comboCarrito.Id);
            if (precio <= 0) throw new Exception("El precio debe ser mayor o igual a cero");
            ComidaCarrito[]? comidasCombo = await _apiCarrito.ObtenerComidasCombo(comboCarrito.Id);
            if (comidasCombo == null) throw new Exception($"""
                Las comidas del combo con id: {comboCarrito.Id} no fueron encontradas
                """);
            foreach (var comidaCombo in comidasCombo)
            {
                ModelViewComidaCarrito comidaCarrito = new ModelViewComidaCarrito();
                await comidaCarrito.Inicializar(comidaCombo);
                ComidasCarritoCombo.Add(comidaCarrito);
            }
            ComboCarritoId = comboCarrito.Id;
            OrdenId = comboCarrito.IdOrden;
            Cantidad = comboCarrito.Cantidad;
            ComboId = comboCarrito.IdCombo;
            Subtotal = precio;
            PrecioTotal = precio - (precio * combo.Descuento);
            await Combo.Inicializar(combo);
        }
    }
}
