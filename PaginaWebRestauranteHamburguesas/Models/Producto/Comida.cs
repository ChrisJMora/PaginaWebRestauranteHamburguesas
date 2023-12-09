namespace PaginaWebRestauranteHamburguesas.Models.Producto
{
    public class Comida : Producto
    {
        public required double Precio { get; set; }
        public required int IdCategoriaComida { get; set; }
        public required int IdEstadoComida { get; set; }
    }
}
