using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Producto
{
    public class ComidaCombo
    {
        public int Id { get; set; }
        public int IdCombo { get; set; }
        public int IdComida { get; set; }
        public int Cantidad { get; set; }
    }
}
