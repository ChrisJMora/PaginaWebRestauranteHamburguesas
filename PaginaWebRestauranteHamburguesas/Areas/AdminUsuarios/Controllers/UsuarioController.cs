using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.ModelViews;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.Controllers
{
    [Area("AdminUsuarios")]
    public class UsuarioController : Controller
    {
        private ApiUsuario _apiUsuario = ApiUsuario.Singleton();

        // PAGINA PRINCIPAL
            // PAGINA: Muestra todos los usuarios de la base de datos
        [Route("1", Name = "usuarios")]
        public async Task<IActionResult> 
            PaginaPrincipalUsuario()
        {
            try
            {
                Usuario[]? usuarios = await _apiUsuario.ObtenerUsuarios();
                if (usuarios == null) throw new Exception("""
                La lista de usuarios es igual a a null
                """);
                ModelViewUsuarios modelViewUsuarios = new ModelViewUsuarios();
                await modelViewUsuarios.Inicializar(usuarios);
                return View("PaginaPrincipalUsuario", modelViewUsuarios);
            }
            catch(Exception ex)
            {
                return RedirectToAction("InicioSesion", "Admin", new { area = "AccesoAdmin", mensaje = ex.Message });
            }
        }
            // POST: Redirecciona a las páginas "CrearUsuarioAdmin" y "CrearUsuarioCliente" segun el tipo de usuario
        [HttpPost("2", Name = "crearUsuarios")]
        public IActionResult
            PaginaPrincipalUsuario(int tipoUsuario)
        {
            if (tipoUsuario == 1)
                return RedirectToAction("CrearUsuarioAdmin");
            else
                return RedirectToAction("CrearUsuarioCliente");
        }

        // CREAR USUARIO ADMIN
            // PAGINA: Muestra el formulario para la creación de un usuario administrador
        public IActionResult 
            CrearUsuarioAdmin(string mensaje)
        {
            return View("CrearUsuarioAdmin", mensaje);
        }
            // POST: Crea un usuario administrador
        [HttpPost]
        public async Task<IActionResult>
            CrearUsuarioAdmin(string nombreUsuarioAdmin, string passwordAdmin,
            string nombreUsuario, string password)
        {
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                await _apiUsuario.RegistroCuentaAdmin(nombreUsuario, password);
                return RedirectToAction("PaginaPrincipalUsuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CrearUsuarioAdmin", new { mensaje = ex.Message });
            }
        }

        // CREAR USUARIO CLIENTE
            // PAGINA: Muestra el formulario para la creación de un usuario cliente
        public async Task<IActionResult> 
            CrearUsuarioCliente(string mensaje)
        {
            ModelViewGeneros modelViewGeneros = new ModelViewGeneros();
            await modelViewGeneros.Inicializar();
            return View("CrearUsuarioCliente", new ModelViewMensaje<ModelViewGeneros>() 
                { entity = modelViewGeneros, mensaje = mensaje});
        }
            // POST: Crea un usuario cliente
        [HttpPost]
        public async Task<IActionResult>
            CrearUsuarioCliente(string nombreCliente, string apellidoCliente,
            DateTime fNacimientoCliente, int generoCliente, string telefono, string mail,
            string nombreUsuarioAdmin, string passwordAdmin,  string nombreUsuario, string password)
        {
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                Cliente cliente = new Cliente()
                {
                    Nombre = nombreCliente,
                    Apellido = apellidoCliente,
                    FechaNacimiento = fNacimientoCliente,
                    IdGenero = generoCliente,
                    TelefonoCliente = telefono,
                    MailCliente = mail,
                };
                await _apiUsuario.RegistroCuentaCliente(nombreUsuario, password, cliente);
                return RedirectToAction("PaginaPrincipalUsuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CrearUsuarioCliente", new { mensaje = ex.Message });
            }
        }

        // MODIFICAR USUARIO ADMIN
            // PAGINA: Muestra el formulario para modificar un usuario administrador
        public async Task<IActionResult>
            ModificarUsuarioAdmin(int idUsuario, string mensaje)
        {
            try
            {
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null)
                    throw new Exception("Usuario no encontrado");
                ModelViewUsuario modelViewUsuario = new ModelViewUsuario();
                await modelViewUsuario.Inicializar(usuario);
                return View("ModificarUsuarioAdmin", new ModelViewMensaje<ModelViewUsuario> 
                { entity = modelViewUsuario, mensaje = mensaje });
            }
            catch (Exception)
            {
                return RedirectToAction("usuarios");
            }
        }
            // POST: Modifica un usuario administrador
        [HttpPost]
        public async Task<IActionResult>
            ModificarUsuarioAdmin(int idUsuario, string nombreUsuarioAdmin, string passwordAdmin, string oldNombreUsuario,
            string nombreUsuario, string password, int estadoUsuario)
        {
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                await _apiUsuario.ModificarUsuario(oldNombreUsuario, nombreUsuario, password, estadoUsuario);
                return RedirectToRoute("usuarios");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ModificarUsuarioAdmin", new { idUsuario = idUsuario, mensaje = ex.Message });
            }
        }

        // MODIFICAR USUARIO CLIENTE
            // PAGINA: Muestra el formulario para modificar un usuario cliente
        public async Task<IActionResult>
            ModificarUsuarioCliente(int idUsuario, string mensaje)
        {
            try
            {
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null) throw new Exception("""
                    Usuario no encontrado
                    """);
                ModelViewUsuario modelViewUsuario = new ModelViewUsuario();
                await modelViewUsuario.Inicializar(usuario);
                return View("ModificarUsuarioCliente", new ModelViewMensaje<ModelViewUsuario>
                { entity = modelViewUsuario, mensaje = mensaje });
            }
            catch (Exception)
            {
                return RedirectToAction("usuarios");
            }
        }
            // POST: Modifica un usuario cliente
        [HttpPost]
        public async Task<IActionResult>
            ModificarUsuarioCliente(int idUsuario, int idCliente, string nombreCliente, string apellidoCliente,
            DateTime fNacimientoCliente, int generoCliente, string telefono, string mail,
            string nombreUsuarioAdmin, string passwordAdmin, string oldNombreUsuario, string nombreUsuario, string password, int estadoUsuario)
        {
            Cliente? oldCliente = await _apiUsuario.ObtenerCliente(idCliente);
            if (oldCliente == null) throw new Exception("Cliente no encontrado");
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                Cliente cliente = new Cliente()
                {
                    Nombre = nombreCliente,
                    Apellido = apellidoCliente,
                    FechaNacimiento = fNacimientoCliente,
                    IdGenero = generoCliente,
                    TelefonoCliente = telefono,
                    MailCliente = mail,
                };
                await _apiUsuario.ModificarCliente(idCliente, cliente);
                await _apiUsuario.ModificarUsuario(oldNombreUsuario, nombreUsuario, password, estadoUsuario);

                return RedirectToAction("PaginaPrincipalUsuario");
            }
            catch (Exception ex)
            {
                await _apiUsuario.ModificarCliente(idCliente, oldCliente);
                return RedirectToAction("ModificarUsuarioCliente", new { idUsuario = idUsuario, mensaje = ex.Message });
            }
        }

        // ELIMINAR USUARIO
            // PAGINA: Muestra el formulario para eliminar un usuario
        public async Task<IActionResult>
            EliminarUsuario(int idUsuario, string mensaje)
        {
            try
            {
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null)
                    throw new Exception("Usuario no encontrado");
                ModelViewUsuario modelViewUsuario = new ModelViewUsuario();
                await modelViewUsuario.Inicializar(usuario);
                return View("EliminarUsuario", new ModelViewMensaje<ModelViewUsuario>
                { entity = modelViewUsuario, mensaje = mensaje });
            }
            catch (Exception)
            {
                return RedirectToAction("usuarios");
            }
        }
            // POST: Eliminar Usuario
        [HttpPost]
        public async Task<IActionResult>
            EliminarUsuario(string nombreUsuarioAdmin, string passwordAdmin, int idUsuario)
        {
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null) throw new Exception("Usuario no encontrado");
                await _apiUsuario.EliminarUsuario(usuario.Nombre);
                if (usuario.IdTipoUsuario == 2)
                {
                    int? idCliente = usuario.IdCliente;
                    if (idCliente != null)
                        await _apiUsuario.EliminarCliente((int)idCliente);
                }
                return RedirectToRoute("usuarios");
            }
            catch (Exception ex)
            {
                return RedirectToAction("EliminarUsuario", new { idUsuario = idUsuario, mensaje = ex.Message });
            }
        }

        // MODIFICAR ESTADO USUARIO
            // PAGINA: Muestra el formulario para modificar el estado de un usuario
        public async Task<IActionResult>
            ModificarEstadoUsuario(int idUsuario, string mensaje)
        {
            try
            {
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null)
                    throw new Exception("Usuario no encontrado");
                ModelViewUsuario modelViewUsuario = new ModelViewUsuario();
                await modelViewUsuario.Inicializar(usuario);
                return View("ModificarEstadoUsuario", new ModelViewMensaje<ModelViewUsuario>
                { entity = modelViewUsuario, mensaje = mensaje });
            }
            catch (Exception) 
            {
                return RedirectToAction("usuarios");
            }
        }
            // AUX: Redirecciona a las páginas  "ModificarUsuarioAdmin" y "ModificarUsuarioCliente" segun el tipo de usuario
        public IActionResult
            ModificarUsuarios(int idUsuario, int tipoUsuario)
        {
            if (tipoUsuario == 1)
                return RedirectToAction("ModificarUsuarioAdmin", new { idUsuario = idUsuario });
            else
                return RedirectToAction("ModificarUsuarioCliente", new { idUsuario = idUsuario });
        }
            // POST: Modificar estado del usuario
        [HttpPost]
        public async Task<IActionResult>
            ModificarEstadoUsuario(string nombreUsuarioAdmin, string passwordAdmin, int idUsuario, int estadoUsuario)
        {
            try
            {
                await _apiUsuario.InicioSesionAdmin(nombreUsuarioAdmin, passwordAdmin);
                Usuario? usuario = await _apiUsuario.ObtenerUsuario(idUsuario);
                if (usuario == null) throw new Exception("Usuario no encontrado");
                await _apiUsuario.ModificarEstadoUsuario(usuario.Nombre, estadoUsuario);
                return RedirectToRoute("usuarios");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ModificarEstadoUsuario", new { idUsuario = idUsuario, mensaje = ex.Message });
            }
        }

        // BUSCAR USUARIOS
            // POST: Busca los nombres de usuarios que conincidan con los caracteres
        [HttpPost]
        public async Task<IActionResult>
            BuscarUsuario(string caracteres)
        {
            try
            {
                Usuario[]? usuarios = await _apiUsuario.ObtenerUsuarios(caracteres);
                if (usuarios == null) throw new Exception("Lista de usuarios vacía");
                ModelViewUsuarios modelViewUsuarios = new ModelViewUsuarios();
                await modelViewUsuarios.Inicializar(usuarios);
                return View("PaginaPrincipalUsuario", modelViewUsuarios);
            }
            catch (Exception)
            {
                return RedirectToRoute("usuarios");
            }
        }
    }
}
