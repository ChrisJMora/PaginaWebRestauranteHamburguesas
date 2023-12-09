using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;
using System.Drawing.Printing;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewUsuario
    {
        private readonly ApiUsuario _apiUsuario = ApiUsuario.Singleton();
        private readonly ApiEstado _apiEstado = ApiEstado.Singleton();

        public int UsuarioId { get; set; }
        public int TipoId { get; set; }
        public int EstadoId { get; set; }
        public string Tipo { get; set; } = "default";
        public string Nombre { get; set; } = "default";
        public string FechaCreacion { get; set; } = "default";
        public string FechaAcceso { get; set; } = "default";
        public string HoraAcceso { get; set; } = "default";
        public string Estado { get; set; } = "default";
        public ModelViewCliente Cliente { get; set; } = new ModelViewCliente();
        public ModelViewEstados EstadosUsuario {  get; set; } = new ModelViewEstados();

        public ModelViewUsuario() { }

        public async Task Inicializar(Usuario usuario)
        {
            TipoUsuario? tipo = await _apiUsuario.ObtenerTipoUsuario(usuario.IdTipoUsuario);
            if (tipo == null) throw new Exception($"""
                El tipo del usuario: {usuario.Nombre} no fue encontrado
                """);
            Estado? estado = await _apiEstado.ObtenerEstado(usuario.IdEstadoUsuario);
            if (estado == null) throw new Exception($"""
                El estado del usuario: {usuario.Nombre} no fue encontrado
                """);
            if (tipo.Id == 2)
            {
                int? clienteId = usuario.IdCliente;
                if (clienteId == null) throw new Exception($"""
                El usuario: {usuario.Nombre} no tiene asociado un cliente
                """);
                Cliente? cliente = await _apiUsuario.ObtenerCliente((int)clienteId);
                if (cliente == null) throw new Exception($"""
                El cliente del usuario: {usuario.Nombre} no fue encontrado
                """);
                await Cliente.Inicializar(cliente);
            }
            UsuarioId = usuario.Id;
            TipoId = usuario.IdTipoUsuario;
            EstadoId = usuario.IdEstadoUsuario;
            Tipo = tipo.Etiqueta;
            Nombre = usuario.Nombre;
            FechaCreacion = usuario.FechaCreacion.ToString("dd/MM/yyyy");
            FechaAcceso = usuario.FechaAcceso.ToString("dd/MM/yyyy");
            HoraAcceso = usuario.FechaAcceso.ToString("HH:mm");
            Estado = estado.Etiqueta;
            await EstadosUsuario.Inicializar();
        }
    }
}
