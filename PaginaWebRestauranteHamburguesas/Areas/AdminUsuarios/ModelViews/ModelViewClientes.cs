using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewClientes
    {
        public List<ModelViewCliente> Clientes = new List<ModelViewCliente>();
        public ModelViewClientes() { }
        public async Task Inicializar(Cliente[] clientes)
        {
            foreach (var cliente in clientes)
            {
                ModelViewCliente modelViewCliente = new ModelViewCliente();
                await modelViewCliente.Inicializar(cliente);
                Clientes.Add(modelViewCliente);
            }
        }
    }
}
