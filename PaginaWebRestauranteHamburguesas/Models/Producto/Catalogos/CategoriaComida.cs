using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos
{
    public class CategoriaComida
    {
        public int Id { get; set; }
        public required string Etiqueta { get; set; }
    }
}
