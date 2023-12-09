using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PaginaWebRestauranteHamburguesas.Models.Producto
{
    public class Imagen
    {
        public int ImagenId { get; set; }
        public required string Titulo { get; set; }
        public required byte[] Datos { get; set; }
    }
}
