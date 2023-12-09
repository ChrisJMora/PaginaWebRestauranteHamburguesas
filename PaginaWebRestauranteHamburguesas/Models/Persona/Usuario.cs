namespace PaginaWebRestauranteHamburguesas.Models.Persona
{
    public class Usuario
    {
        public int Id { get; set; }
        public required int IdTipoUsuario { get; set; }
        public required string Nombre { get; set; }
        public string SaltPassword { get; private set; } = "default";
        public string Password { get; private set; } = "default";
        public required DateTime FechaCreacion { get; set; }
        public required DateTime FechaAcceso { get; set; }
        public required int IdEstadoUsuario { get; set; }
        public int? IdCliente { get; set; }
    }
}