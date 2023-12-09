using PaginaWebRestauranteHamburguesas.Models;
using Microsoft.AspNetCore.Mvc;

namespace PaginaWebRestauranteHamburguesas.API_Service
{
    public class ApiEstado : Controller
    {
        //Atributos
        private static ApiEstado? _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231128183324.azurewebsites.net/api/Estado";

        //Constructor
        private ApiEstado() { }

        //Métodos
        public static ApiEstado Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiEstado();
            }
            return _instancia;
        }

        // GET: api/Estado
        public async Task<Estado[]?>
            ObtenerEstados()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerEstados
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Estado[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Estado
        public async Task<Estado?>
            ObtenerEstado(int idEstado)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerEstado/{idEstado}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Estado>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
