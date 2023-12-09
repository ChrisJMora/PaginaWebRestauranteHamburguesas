using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Orden;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewCliente
    {
        private readonly ApiUsuario _apiUsuario = ApiUsuario.Singleton();
        private readonly ApiOrden _apiOrden = ApiOrden.Singleton();

        public int ClienteId { get; set; }
        public int GeneroId { get; set; }
        public string Nombre { get; set; } = "default";
        public string Apellido { get; set; } = "default";
        public string FechaNacimiento { get; set; } = "default";
        public string Genero { get; set; } = "default";
        public string Telefono { get; set; } = "default";
        public string Mail { get; set; } = "default";
        public ModelViewGeneros GenerosCliente { get; set; } = new ModelViewGeneros();
        public bool TieneOrdenes { get; set; }
        public ModelViewOrdenes OrdenesCliente { get; set; } = new ModelViewOrdenes();

        public ModelViewCliente() { }

        public async Task Inicializar(Cliente cliente)
        {
            GeneroCliente? genero = await _apiUsuario.ObtenerGeneroCliente(cliente.IdGenero);
            if (genero == null) throw new Exception($"""
                El genero del cliente: {cliente.Nombre} {cliente.Apellido} no fue encontrado
                """);
            Orden[]? ordenes = await _apiOrden.ObtenerOrdenesCliente(cliente.Id);
            TieneOrdenes = ordenes != null;
            if (TieneOrdenes) 
                OrdenesCliente.Inicializar(ordenes);
            ClienteId = cliente.Id;
            GeneroId = cliente.IdGenero;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            FechaNacimiento = cliente.FechaNacimiento.ToString("yyyy/MM/dd");
            Genero = genero.Etiqueta;
            Telefono = cliente.TelefonoCliente;
            Mail = cliente.MailCliente;
            await GenerosCliente.Inicializar();
        }
    }
}
