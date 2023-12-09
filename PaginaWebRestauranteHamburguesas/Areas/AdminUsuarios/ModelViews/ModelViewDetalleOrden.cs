using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Persona;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewDetalleOrden
    {
        private readonly ApiCarrito _apiCarrito = ApiCarrito.Singleton();
        private readonly ApiUsuario _apiUsuario = ApiUsuario.Singleton();


        public int OrdenId { get; set; }
        public ModelViewCliente ClienteOrden { get; set; } = new ModelViewCliente();
        public List<ModelViewComboCarrito> CombosCarrito { get; set; } = new List<ModelViewComboCarrito>();
        public List<ModelViewComidaCarrito> ComidasCarrito { get; set; } = new List<ModelViewComidaCarrito>();
        public double PrecioTotalCombos { get; set; }
        public double PrecioTotalComidas { get; set; }
        public double PrecioTotal { get; set; }

        public ModelViewDetalleOrden() { }

        public async Task Inicializar(int idOrden, int idCliente)
        {
            Cliente? cliente = await _apiUsuario.ObtenerCliente(idCliente);
            if (cliente == null) throw new Exception($"""
                Cliente de la orden {idOrden} no encontrado
                """);
            ComboCarrito[]? combosCarrito = await _apiCarrito.ObtenerCombos(idOrden);
            if (combosCarrito == null) throw new Exception($"""
                Combos de la orden {idOrden} no encontrados
                """);
            ComidaCarrito[]? comidasCarrito = await _apiCarrito.ObtenerComidas(idOrden);
            if (comidasCarrito == null) throw new Exception($"""
                MvComidas de la orden {idOrden} no encontradas
                """);
            double totalComidas = await _apiCarrito.CalcularTotalComidas(idOrden);
            if (totalComidas < 0) throw new Exception($"""
                El totalComidas debe ser mayor o igual a cero
                """);

            double totalCombos = 0;
            foreach (var comboCarrito in combosCarrito)
            {
                ModelViewComboCarrito modelViewComboCarrito = new ModelViewComboCarrito();
                await modelViewComboCarrito.Inicializar(comboCarrito);
                totalCombos += modelViewComboCarrito.PrecioTotal * modelViewComboCarrito.Cantidad;
                CombosCarrito.Add(modelViewComboCarrito);
            }
            foreach (var comidaCarrito in comidasCarrito)
            {
                ModelViewComidaCarrito modelViewComidaCarrito = new ModelViewComidaCarrito();
                await modelViewComidaCarrito.Inicializar(comidaCarrito);
                ComidasCarrito.Add(modelViewComidaCarrito);
            }
            OrdenId = idOrden;
            await ClienteOrden.Inicializar(cliente);
            PrecioTotalCombos = totalCombos;
            PrecioTotalComidas = totalComidas;
            PrecioTotal = totalCombos + totalComidas;
        }
    }
}
