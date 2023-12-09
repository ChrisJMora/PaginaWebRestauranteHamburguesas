using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Models.Orden
{
    public class ComboCarrito : ProductoCarrito
    {
        public int IdCombo { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComboCarrito combo = (ComboCarrito)obj;
            return IdCombo == combo.IdCombo;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
