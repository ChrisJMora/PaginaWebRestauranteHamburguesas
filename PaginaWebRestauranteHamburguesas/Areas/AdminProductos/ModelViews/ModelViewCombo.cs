using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Producto;
using PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewCombo
    {
        private ApiProducto _apiProducto = ApiProducto.Singleton();
        private ApiEstado _apiEstado = ApiEstado.Singleton();

        public int ComboId { get; set; }
        public double Descuento { get; set; }
        public int CategoriaComboId { get; set; }
        public int EstadoComboId { get; set; }
        public string Nombre { get; set; } = "default";
        public string Descripcion { get; set; } = "default";
        public string Categoria { get; set; } = "default";
        public string Estado { get; set; } = "default";
        public bool ComboEliminable { get; set; } 



        public ModelViewCategoriasCombo CategoriasCombo { get; set; } = new ModelViewCategoriasCombo();

        public ModelViewCombo() { }

        public async Task Inicializar(Combo combo)
        {
            CategoriaCombo? categoria = await _apiProducto.ObtenerCategoriaCombo(combo.IdCategoriaCombo);
            if (categoria == null) throw new Exception($"""
                La categoria del combo: {combo.Nombre} no fue encontrada
                """);
            Estado? estado = await _apiEstado.ObtenerEstado(combo.IdEstadoCombo);
            if (estado == null) throw new Exception($"""
                El estado del combo: {combo.Nombre} no fue encontrado
                """);
            ComboId = combo.Id;
            Descuento = combo.Descuento * 100;
            CategoriaComboId = combo.IdEstadoCombo;
            Nombre = combo.Nombre;
            Descripcion = combo.Descripcion;
            Categoria = categoria.Etiqueta;
            Estado = estado.Etiqueta;
            EstadoComboId = estado.Id;
            await CategoriasCombo.Inicializar();
            ComboEliminable = await _apiProducto.ComboEliminable(ComboId);
        }
    }
}
