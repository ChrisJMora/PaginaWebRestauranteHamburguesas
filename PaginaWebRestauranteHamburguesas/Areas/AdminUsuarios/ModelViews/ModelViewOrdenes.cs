using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Persona;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewOrdenes
    {
        public List<ModelViewOrden> Ordenes = new List<ModelViewOrden>();
        public ModelViewOrdenes() { }
        public void Inicializar(Orden[] ordenes)
        {
            foreach (var orden in ordenes)
            {
                ModelViewOrden modelViewOrden = new ModelViewOrden();
                modelViewOrden.Inicializar(orden);
                Ordenes.Add(modelViewOrden);
            }
        }
    }
}
