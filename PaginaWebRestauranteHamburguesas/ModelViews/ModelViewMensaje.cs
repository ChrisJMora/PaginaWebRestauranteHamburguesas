namespace PaginaWebRestauranteHamburguesas.ModelViews
{
    public class ModelViewMensaje<T>
    {
        public required T entity { get; set; }
        public string? mensaje;
    }
}
