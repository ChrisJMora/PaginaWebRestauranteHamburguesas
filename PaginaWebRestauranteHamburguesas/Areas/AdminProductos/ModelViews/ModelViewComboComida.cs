using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models.Producto;

namespace PaginaWebRestauranteHamburguesas.Areas.AdminProductos.ModelViews
{
    public class ModelViewComboComida
    {
        private readonly ApiProducto _apiProducto = ApiProducto.Singleton();
        public int IdCombo { get; set; }
        public ModelViewCombo MvCombo { get; set; }
        public Dictionary<int,int> ComidasCombo { get; set; }
        public ModelViewComidas MvComidasCombo { get; set; }
        public ModelViewComidas MvComidas { get; set; }

        public ModelViewComboComida()
        {
            MvCombo = new ModelViewCombo();
            ComidasCombo = new Dictionary<int,int>();
            MvComidasCombo = new ModelViewComidas();
            MvComidas = new ModelViewComidas();
        }

        public async Task Inicializar(int idCombo)
        {
            Combo? combo = await _apiProducto.ObtenerCombo(idCombo);
            if (combo == null) throw new Exception($"""
                Combo no encontrado
                """);
            ComidaCombo[]? comboComidas = await _apiProducto.ObtenerComidasCombo(idCombo);
            if (comboComidas == null) throw new Exception($"""
                Comidas del combo con id: {idCombo} no encontradas
                """);
            Comida[]? comidas = await _apiProducto.ObtenerComidas();
            if (comidas == null) throw new Exception($"""
                Comidas no encontradas
                """);
            Comida[] comidasCombo = await ObtenerComidasCombo(comboComidas);
            IdCombo = idCombo;
            await MvCombo.Inicializar(combo);
            await MvComidasCombo.Inicializar(comidasCombo);
            await MvComidas.Inicializar(comidas);
        }

        private async Task<Comida[]> ObtenerComidasCombo(ComidaCombo[] comboComidas)
        {
            List<Comida> comidasCombo = new List<Comida>();
            List<int> idComidasCombo = new List<int>();
            List<int> cantidadesComidasCombo = new List<int>();

            foreach (var comboComida in comboComidas)
            {
                Comida? comida = await _apiProducto.ObtenerComida(comboComida.IdComida);
                if (comida == null) throw new Exception($"""
                Comida no encontrada
                """);

                ComidasCombo.Add(comboComida.IdComida, comboComida.Cantidad);
                comidasCombo.Add(comida);
            }
            return comidasCombo.ToArray();
        }

    }
}
