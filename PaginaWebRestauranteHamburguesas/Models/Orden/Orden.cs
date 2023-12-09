namespace PaginaWebRestauranteHamburguesas.Models.Orden
{
    public class Orden
    {
        public int Id { get; set; }
        public required DateTime Fecha { get; set; }
        public required int IdCliente { get; set; }
    }
}
