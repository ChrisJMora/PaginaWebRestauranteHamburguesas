using PaginaWebRestauranteHamburguesas.Models.Producto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaginaWebRestauranteHamburguesas.Models.Orden
{
    public class ComidaCarrito : ProductoCarrito
    {
        public int? IdComboCarrito { get; set; }
        public required int IdComida { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComidaCarrito comida = (ComidaCarrito)obj;
            return IdComida == comida.IdComida;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
