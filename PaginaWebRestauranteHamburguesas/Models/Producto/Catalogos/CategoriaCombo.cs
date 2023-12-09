using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos
{
    public class CategoriaCombo
    {
        public int Id { get; set; }
        public required string Etiqueta { get; set; }
        public Combo? Combo { get; set; }
    }
}
