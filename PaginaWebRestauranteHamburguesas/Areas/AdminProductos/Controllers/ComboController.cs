using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Producto;
using PaginaWebRestauranteHamburguesas.ModelViews;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.Controllers
{
    [Area("AdminProductos")]
    public class ComboController : Controller
    {
        private ApiProducto _apiProducto = ApiProducto.Singleton();

        // PAGINA PRINCIPAL
        public async Task<IActionResult> 
            PaginaPrincipalCombo()
        {
            try
            {
                Combo[]? combos = await _apiProducto.ObtenerCombos();
                if (combos == null)
                    throw new Exception("Combos no encontrados");
                ModelViewCombos modelViewCombos = new ModelViewCombos();
                await modelViewCombos.Inicializar(combos);
                return View("PaginaPrincipalCombo",modelViewCombos);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("PaginaPrincipal","Admin", new { area = "AccesoAdmin" });
            }
        }

        // AGREGAR COMIDA
            // PAGINA
        public async Task<IActionResult> 
            AgregarCombo(string mensaje)
        {
            try
            {
                ModelViewCategoriasCombo modelViewCategoriasCombo = new ModelViewCategoriasCombo();
                await modelViewCategoriasCombo.Inicializar();
                return View("AgregarCombo", new ModelViewMensaje<ModelViewCategoriasCombo>()
                { entity = modelViewCategoriasCombo, mensaje = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("AgregarCombo", new { mensaje = ex.Message} );
            }
        }
            // POST
        [HttpPost]
        public async Task<IActionResult> 
            AgregarCombo(string nombreCombo, string descripcionCombo,
            double descuentoCombo, int categoriaCombo)
        {
            try
            {
                await _apiProducto.AgregarCombo(nombreCombo, descripcionCombo,
                    descuentoCombo, categoriaCombo);
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception ex)
            {
                return RedirectToAction("AgregarCombo", new { mensaje = ex.Message } );
            }
        }

        // AGREGAR COMIDAS COMBO
            // PAGINA
        public async Task<IActionResult>
            AgregarComidasCombo(int idCombo)
        {
            try
            {
                Comida[]? comidas = await _apiProducto.ObtenerComidas();
                if (comidas == null) throw new Exception("""
                    Comidas no encontradas
                    """);
                ModelViewComboComida modelViewComboComida = new ModelViewComboComida();
                await modelViewComboComida.Inicializar(idCombo);
                return View("AgregarComidasCombo", modelViewComboComida);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }
            // POST
        [HttpPost]
        public async Task<IActionResult>
            AgregarComidasCombo(int idCombo, int[] idComidas, int[] cantComidas)
        {
            try
            {
                await _apiProducto.EliminarComidasCombo(idCombo);

                cantComidas = cantComidas.Where(x => x != 0).ToArray();
                for (int i = 0; i < cantComidas.Length; i++)
                {
                    await _apiProducto.AgregarComidaCombo(idCombo, idComidas[i], cantComidas[i]);
                }
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }

        // DETALLES COMBO
        // PAGINA
        public async Task<IActionResult>
            DetallesCombo(int idCombo)
        {
            try
            {
                ModelViewComboComida modelViewComboComida = new ModelViewComboComida();
                await modelViewComboComida.Inicializar(idCombo);
                return View("DetallesCombo", modelViewComboComida);
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }

        // MODIFICAR COMBO
            // PAGINA
        public async Task<IActionResult>
            ModificarCombo(int idCombo, string mensaje)
        {
            try
            {
                Combo? combo = await _apiProducto.ObtenerCombo(idCombo);
                if (combo == null) throw new Exception("""
                    Combo no encontrado
                    """);
                ModelViewCombo modelViewCombo = new ModelViewCombo();
                await modelViewCombo.Inicializar(combo);
                return View("ModificarCombo", new ModelViewMensaje<ModelViewCombo>()
                { entity = modelViewCombo, mensaje = mensaje });
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }
            // POST
        [HttpPost]
        public async Task<IActionResult>
            ModificarCombo(int idCombo, string nombreCombo, string descripcionCombo,
            double descuentoCombo, int categoriaCombo)
        {
            try
            {
                await _apiProducto.ModificarCombo(idCombo, nombreCombo, descripcionCombo, descuentoCombo, categoriaCombo);
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ModificarCombo", new { idCombo = idCombo, mensaje = ex.Message });
            }
        }




        // ELIMINAR COMIDA
        public async Task<IActionResult>
        EliminarCombo(int idCombo)
        {
            try
            {
                await _apiProducto.EliminarCombo(idCombo);
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }


        // HABILITAR COMIDA
        public async Task<IActionResult>
        HabilitarCombo(int idCombo)
        {
            try
            {
                await _apiProducto.ModificarEstadoCombo(idCombo, 1);
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }

        // DESHABILITAR COMIDA
        public async Task<IActionResult>
        DeshabilitarCombo(int idCombo)
        {
            try
            {
                await _apiProducto.ModificarEstadoCombo(idCombo, 2);
                return RedirectToAction("PaginaPrincipalCombo");
            }
            catch (Exception)
            {
                return RedirectToAction("PaginaPrincipalCombo");
            }
        }


    }
}
