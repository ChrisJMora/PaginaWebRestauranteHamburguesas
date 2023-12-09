using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews
{
    public class ModelViewUsuarios
    {
        public ModelViewTipos ModelViewTipos = new ModelViewTipos();
        public List<ModelViewUsuario> Usuarios = new List<ModelViewUsuario>();
        public ModelViewUsuarios() { }
        public async Task Inicializar(Usuario[] usuarios)
        {
            await ModelViewTipos.Inicializar();
            foreach (var usuario in usuarios)
            {
                ModelViewUsuario modelViewUsuario = new ModelViewUsuario();
                await modelViewUsuario.Inicializar(usuario);
                Usuarios.Add(modelViewUsuario);
            }
        }
    }
}
