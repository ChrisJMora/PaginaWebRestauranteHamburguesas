namespace PaginaWebRestauranteHamburguesas.Models.Persona
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required int IdGenero { get; set; }
        public required string TelefonoCliente { get; set; }
        public required string MailCliente { get; set; }
    }
}
