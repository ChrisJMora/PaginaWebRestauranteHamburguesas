using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;

namespace PaginaWebRestauranteHamburguesas.Areas.AccesoAdmin.Controllers
{
    [Area("AccesoAdmin")]
    public class AdminController : Controller
    {
        private ApiUsuario apiUsuario = ApiUsuario.Singleton();

        public IActionResult PaginaPrincipal()
        {
            return View();
        }

        public IActionResult InicioSesion(string mensaje)
        {
            return View("InicioSesion", mensaje);
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string nombreUsuario, string password)
        {
            try
            {
                string mensaje = await apiUsuario.InicioSesionAdmin(nombreUsuario, password);
                Sesion.Singleton().UsuarioLogeado = nombreUsuario;
                return RedirectToAction("PaginaPrincipal");
            }
            catch(Exception ex)
            {
                return RedirectToAction("InicioSesion", new { mensaje = ex.Message });
            }
        }
    }
}
