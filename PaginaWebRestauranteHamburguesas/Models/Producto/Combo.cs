namespace PaginaWebRestauranteHamburguesas.Models.Producto
{
    public class Combo : Producto
    {
        public required double Descuento { get; set; }
        public required int IdEstadoCombo { get; set; }
        public required int IdCategoriaCombo { get; set; }
    }
}
