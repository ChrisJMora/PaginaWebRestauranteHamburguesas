using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewComidas
    {
        public List<ModelViewComida> Comidas { get; set; }                = new List<ModelViewComida>();
        public ModelViewCategoriasComida CategoriasComida { get; set; }   = new ModelViewCategoriasComida();
        public ModelViewCategoriasCombo CategoriasCombo { get; set; }     = new ModelViewCategoriasCombo();

        public int IdCombo;

        public ModelViewComidas() { }

        public async Task Inicializar(Comida[] comidas)
        {
            await CategoriasComida.Inicializar();
            await CategoriasCombo.Inicializar();
            foreach (var comida in comidas)
            {
                ModelViewComida modelViewComida = new ModelViewComida();
                await modelViewComida.Inicializar(comida);
                Comidas.Add(modelViewComida);
            }    

        }

    }
}
