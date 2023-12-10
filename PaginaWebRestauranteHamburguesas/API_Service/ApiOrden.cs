using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.Models.Orden;

namespace PaginaWebRestauranteHamburguesas.API_Service
{
    public class ApiOrden : Controller
    {
        //Atributos
        private static ApiOrden? _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231210132143.azurewebsites.net/api/Orden";

        //Constructor
        private ApiOrden() { }

        //Métodos
        public static ApiOrden Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiOrden();
            }
            return _instancia;
        }

        // GET: api/Orden
        public async Task<Orden?>
            ObtenerOrden(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerOrden/{idOrden}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Orden>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Orden
        public async Task<Orden[]?>
            ObtenerOrdenes()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerOrdenes
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Orden[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Orden
        public async Task<Orden[]?>
            ObtenerOrdenesCliente(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerOrdenesCliente/{idCliente}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Orden[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST: api/Orden
        public async Task<string>
            CrearOrden(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/CrearOrden/{idCliente}
                    """,null);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
