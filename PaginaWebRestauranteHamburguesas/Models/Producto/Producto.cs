using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Producto
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre {  get; set; }
        public required string Descripcion {  get; set; }

    }
}
