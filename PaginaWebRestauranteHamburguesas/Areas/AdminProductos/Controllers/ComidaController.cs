using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews;
using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Producto;
using PaginaWebRestauranteHamburguesas.ModelViews;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.Controllers
{
    [Area("AdminProductos")]
    public class ComidaController : Controller
    {
        private ApiProducto _apiProducto = ApiProducto.Singleton();

        // PAGINA PRINCIPAL
        public async Task<IActionResult> PaginaPrincipalComida()
        {
            try
            {
                Comida[]? comidas = await _apiProducto.ObtenerComidas();
                if (comidas == null)
                    throw new Exception("MvComidas no encontradas");
                ModelViewComidas modelViewComidas = new ModelViewComidas();
                await modelViewComidas.Inicializar(comidas);
                return View("PaginaPrincipalComida",modelViewComidas);
            }
            catch(Exception)
            {
                return RedirectToAction("PaginaPrincipal","Admin", new { area = "AccesoAdmin" });
            }
        }

        // AGREGAR COMIDA
            // PAGINA
        public async Task<IActionResult> 
            AgregarComida(string mensaje)
        {
            try
            {
                ModelViewCategoriasComida modelViewCategoriasComida = new ModelViewCategoriasComida();
                await modelViewCategoriasComida.Inicializar();
                return View("AgregarComida", new ModelViewMensaje<ModelViewCategoriasComida>()
                { entity = modelViewCategoriasComida, mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("AgregarComida", new { mensaje = ex.Message} );
            }
        }
            // POST
        [HttpPost]
        public async Task<IActionResult> 
            AgregarComida(string nombreComida, string descripcionComida,
            double precioComida, int categoriaComida)
        {
            try
            {
                await _apiProducto.AgregarComida(nombreComida, descripcionComida, precioComida, categoriaComida);
                return RedirectToAction("PaginaPrincipalComida");
            }
            catch (Exception ex)
            {
                return RedirectToAction("AgregarComida", new { mensaje = ex.Message } );
            }
        }

        // DETALLES COMIDA
            // PAGINA
        public async Task<IActionResult>
            DetallesComida(int idComida)
        {
            try
            {
                Comida? comida = await _apiProducto.ObtenerComida(idComida);
                if (comida == null) throw new Exception("""
                    Comida no encontrada;
                    """);
                ModelViewComida modelViewComida = new ModelViewComida();
                await modelViewComida.Inicializar(comida);
                return View("DetallesComida", modelViewComida);
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalComida");
            }
        }

        // MODIFICAR COMIDA
            // PAGINA
        public async Task<IActionResult>
            ModificarComida(int idComida, string mensaje)
        {
            try
            {
                Comida? comida = await _apiProducto.ObtenerComida(idComida);
                if (comida == null) throw new Exception("""
                    Comida no encontrada
                    """);
                ModelViewComida modelViewComida = new ModelViewComida();
                await modelViewComida.Inicializar(comida);
                return View("ModificarComida", new ModelViewMensaje<ModelViewComida>()
                { entity = modelViewComida, mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("ModificarComida", new { mensaje = ex.Message });
            }
        }
            // POST
        [HttpPost]
        public async Task<IActionResult>
            ModificarComida(int idComida, string nombreComida, string descripcionComida,
            double precioComida, int categoriaComida)
        {
            try
            {
                await _apiProducto.ModificarComida(idComida, nombreComida, descripcionComida, precioComida, categoriaComida);
                return RedirectToAction("PaginaPrincipalComida");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ModificarComida", new { idComida = idComida, mensaje = ex.Message });
            }
        }

        // ELIMINAR COMIDA
        public async Task<IActionResult>
        EliminarComida(int idComida)
        {
            try
            {
                await _apiProducto.EliminarComida(idComida);
                return RedirectToAction("PaginaPrincipalComida");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalComida");
            }
        }


        // HABILITAR COMIDA
        public async Task<IActionResult>
        HabilitarComida(int idComida)
        {
            try
            {
                await _apiProducto.ModificarEstadoComida(idComida, 1);
                return RedirectToAction("PaginaPrincipalComida");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalComida");
            }
        }

        // DESHABILITAR COMIDA
        public async Task<IActionResult>
        DeshabilitarComida(int idComida)
        {
            try
            {
                await _apiProducto.ModificarEstadoComida(idComida, 2);
                return RedirectToAction("PaginaPrincipalComida");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalComida");
            }
        }


    }
}
