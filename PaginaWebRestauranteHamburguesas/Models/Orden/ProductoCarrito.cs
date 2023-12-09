using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Orden
{
    public class ProductoCarrito
    {
        public int Id { get; set; }
        public required int IdOrden { get; set; }
        public required int Cantidad { get; set; }
    }
}
