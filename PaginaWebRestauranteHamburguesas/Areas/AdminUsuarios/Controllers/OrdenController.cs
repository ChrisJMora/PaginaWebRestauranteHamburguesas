using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Persona;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.Controllers
{
    [Area("AdminUsuarios")]
    public class OrdenController : Controller
    {
        private ApiUsuario _apiUsuario = ApiUsuario.Singleton();
        private ApiOrden _apiOrden = ApiOrden.Singleton();

        // PAGINA PRINCIPAL
            // PAGINA: Muestra todas las ordenes de un cliente
        [Route("4", Name = "ordenes")]
        public async Task<IActionResult> 
            PaginaPrincipalOrden(int idCliente)
        {
            try
            {
                Cliente? cliente = await _apiUsuario.ObtenerCliente(idCliente);
                if (cliente == null) throw new Exception("""
                Cliente no encontrado
                """);
                ModelViewCliente modelViewCliente = new ModelViewCliente();
                await modelViewCliente.Inicializar(cliente);
                return View("PaginaPrincipalOrden", modelViewCliente);
            }
            catch (Exception)
            {
                return RedirectToRoute("clientes");
            }
        }

        // DETALLES DE ORDEN
            // PAGINA: Muestra los detalles de la orden
        public async Task<IActionResult>
            DetallesOrden(int idOrden, int idCliente)
        {
            try
            {
                Orden? orden = await _apiOrden.ObtenerOrden(idOrden);
                if (orden == null) { return RedirectToAction("ordenes"); }
                ModelViewDetalleOrden modelViewDetalleOrden = new ModelViewDetalleOrden();
                await modelViewDetalleOrden.Inicializar(idOrden, idCliente);
                return View("DetallesOrden", modelViewDetalleOrden);
            }
            catch (Exception)
            {
                return RedirectToRoute("ordenes");
            }
        }
    }
}
