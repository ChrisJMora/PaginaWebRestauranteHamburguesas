using PaginaWebRestauranteHamburguesas.Models.Orden;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewOrden
    {
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public string Fecha { get; set; } = "default";

        public ModelViewOrden() { }

        public void Inicializar(Orden orden)
        {
            OrdenId = orden.Id;
            ClienteId = orden.IdCliente;
            Fecha = orden.Fecha.ToString("dd/MM/yyyy");
        }
    }
}
