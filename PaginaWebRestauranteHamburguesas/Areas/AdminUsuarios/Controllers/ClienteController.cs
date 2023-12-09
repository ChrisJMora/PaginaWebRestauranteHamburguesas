using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Persona;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.Controllers
{
    [Area("AdminUsuarios")]
    public class ClienteController : Controller
    {
        private ApiUsuario _apiUsuario = ApiUsuario.Singleton();

        // PAGINA PRINCIPAL
            // PAGINA: Muestra todos los clientes de la base de datos
        [Route("3", Name = "clientes")]
        public async Task<IActionResult> 
            PaginaPrincipalCliente()
        {
            try
            {
                Cliente[]? clientes = await _apiUsuario.ObtenerClientes();
                if (clientes == null) throw new Exception("""
                La lista de clientes es igual a null
                """);
                ModelViewClientes modelViewClientes = new ModelViewClientes();
                await modelViewClientes.Inicializar(clientes);
                return View("PaginaPrincipalCliente", modelViewClientes);
            }
            catch (Exception)
            {
                return RedirectToAction("usuarios");
            }
        }
    }
}
