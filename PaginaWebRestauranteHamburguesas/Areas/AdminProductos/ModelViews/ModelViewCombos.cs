using PaginaWebRestauranteHamburguesas.Areas.AdminUsuarios.ModelViews;
using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewCombos
    {
        public List<ModelViewCombo> Combos { get; set; } = new List<ModelViewCombo>();
        public ModelViewCombos() { }

        public async Task Inicializar(Combo[] combos)
        {
            foreach (var combo in combos)
            {
                ModelViewCombo modelViewCombo = new ModelViewCombo();
                await modelViewCombo.Inicializar(combo);
                Combos.Add(modelViewCombo);
            }    

        }
    }
}
