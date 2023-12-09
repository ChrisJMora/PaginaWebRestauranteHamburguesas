using PaginaWebRestauranteHamburguesas.Models;
using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.Models.Orden;

namespace PaginaWebRestauranteHamburguesas.API_Service
{
    public class ApiCarrito : Controller
    {
        //Atributos
        private static ApiCarrito? _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231128183324.azurewebsites.net/api/Carrito";

        //Constructor
        private ApiCarrito() { }

        //Métodos
        public static ApiCarrito Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiCarrito();
            }
            return _instancia;
        }

        // GET: api/Carrito
        public async Task<ProductoCarrito?>
            ObtenerProducto(int idProducto)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerProducto/{idProducto}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ProductoCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito?>
            ObtenerComidaCarrito(int idComidaCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidaCarrito/{idComidaCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComboCarrito?>
            ObtenerComboCarrito(int idComboCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComboCarrito/{idComboCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComboCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito[]?>
            ObtenerComidas(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidas/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComboCarrito[]?>
            ObtenerCombos(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerCombos/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComboCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito[]?>
            ObtenerComidasCombo(int idCombo)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidasCombo/{idCombo}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<double>
            CalcularTotalCombo(int idComboCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/CalcularTotalCombo/{idComboCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<double>();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // GET: api/Carrito
        public async Task<double>
            CalcularTotalComidas(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/CalcularTotalComidas/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<double>();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
