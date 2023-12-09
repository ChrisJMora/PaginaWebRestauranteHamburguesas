using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaginaWebRestauranteHamburguesas.Models.Orden;
using PaginaWebRestauranteHamburguesas.Models.Producto;
using PaginaWebRestauranteHamburguesas.Models.Producto.Catalogos;

namespace PaginaWebRestauranteHamburguesas.API_Service
{
    public class ApiProducto : Controller
    {
        //Atributos
        private static ApiProducto? _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231128183324.azurewebsites.net/api/Producto";

        //Constructor
        private ApiProducto() { }

        //Métodos
        public static ApiProducto Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiProducto();
            }
            return _instancia;
        }

        // GET: api/Producto
        public async Task<Comida[]?>
            ObtenerComidas()
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerComidas
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Comida[]>();
        }

        // GET: api/Producto
        public async Task<Combo[]?>
            ObtenerCombos()
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCombos
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Combo[]>();
        }

        // GET: api/Producto
        public async Task<CategoriaComida[]?>
            ObtenerCategoriasComida()
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCategoriasComida
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<CategoriaComida[]>();
        }

        // GET: api/Producto
        public async Task<CategoriaCombo[]?>
            ObtenerCategoriasCombo()
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCategoriasCombo
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<CategoriaCombo[]>();
        }

        // GET: api/Producto
        public async Task<Comida?>
            ObtenerComida(int idComida)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerComida/{idComida}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Comida>();
        }

        // GET: api/Producto
        public async Task<Combo?>
            ObtenerCombo(int idCombo)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCombo/{idCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Combo>();
        }

        // GET: api/Producto
        public async Task<CategoriaComida?>
            ObtenerCategoriaComida(int idCategoriaComida)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCategoriaComida/{idCategoriaComida}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<CategoriaComida>();
        }

        // GET: api/Producto
        public async Task<CategoriaCombo?>
            ObtenerCategoriaCombo(int idCategoriaCombo)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCategoriaCombo/{idCategoriaCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<CategoriaCombo>();
        }

        // GET: api/Producto
        public async Task<ComidaCombo[]?>
            ObtenerComidasCombo(int idCombo)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerComidasCombo/{idCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<ComidaCombo[]>();
        }

        // GET: api/Producto
        public async Task<Comida[]?>
            FiltrarComidas(int idCategoria)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/FiltrarComidas/{idCategoria}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Comida[]>();
        }

        // GET: api/Producto
        public async Task<Combo[]?>
            FiltrarCombos(int idCategoria)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/FiltrarCombos/{idCategoria}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<Combo[]>();
        }

        // GET: api/Producto
        public async Task<bool>
            ComboEliminable(int idCombo)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ComboEliminable/{idCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<bool>();
        }

        // GET: api/Producto
        public async Task<bool>
            ComidaEliminable(int idComida)
        {
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ComidaEliminable/{idComida}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsAsync<bool>();
        }

        // POST: api/Producto
        public async Task<string>
            AgregarComida(string nombre, string descripcion, double precio, int idCategoria)
        {
            VerificarCamposComida(nombre, descripcion, precio);
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/AgregarComida/{nombre},{descripcion},{precio},{idCategoria}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Producto
        public async Task<string>
            AgregarCombo(string nombre, string descripcion, double descuento, int idCategoria)
        {
            VerificarCamposCombo(nombre, descripcion, descuento);
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/AgregarCombo/{nombre},{descripcion},{descuento},{idCategoria}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Producto
        public async Task<string>
            AgregarComidaCombo(int idCombo, int idComida, int cantidad)
        {
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/AgregarComidaCombo/{idCombo},{idComida},{cantidad}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Producto
        public async Task<string>
            AgregarCategoriaComida(string nombre)
        {
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/AgregarCategoriaComida/{nombre}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Producto
        public async Task<string>
            AgregarCategoriaCombo(string nombre)
        {
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/AgregarCategoriaCombo/{nombre}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarComida(int idComida, string nombre, string descripcion, double precio, int idCategoria)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarComida/{idComida},{nombre},{descripcion},{precio},{idCategoria}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarCombo(int idCombo, string nombre, string descripcion, double descuento, int idCategoria)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarCombo/{idCombo},{nombre},{descripcion},{descuento},{idCategoria}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarCategoriaComida(int idCategoriaComida, string nombre)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarCategoriaComida/{idCategoriaComida},{nombre}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarCategoriaCombo(int idCategoriaCombo, string nombre)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarCategoriaCombo/{idCategoriaCombo},{nombre}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarEstadoComida(int idComida, int idEstado)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarEstadoComida/{idComida},{idEstado}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Producto
        public async Task<string>
            ModificarEstadoCombo(int idCombo, int idEstado)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarEstadoCombo/{idCombo},{idEstado}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Producto
        public async Task<string>
            EliminarComida(int idComida)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarComida/{idComida}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Producto
        public async Task<string>
            EliminarCombo(int idCombo)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarCombo/{idCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Producto
        public async Task<string>
            EliminarCategoriaComida(int idCategoriaComida)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarCategoriaComida/{idCategoriaComida}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Producto
        public async Task<string>
            EliminarCategoriaCombo(int idCategoriaCombo)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarCategoriaCombo/{idCategoriaCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Producto
        public async Task<string>
            EliminarComidasCombo(int idCombo)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarComidasCombo/{idCombo}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

    private void VerificarCamposComida(string nombre, string descripcion, double precio)
        {
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(descripcion))
                throw new Exception("Campos vacíos");
            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a cero");
        }

        private void VerificarCamposCombo(string nombre, string descripcion, double descuento)
        {
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(descripcion))
                throw new Exception("Campos vacíos");
            if (descuento <= 0 || descuento > 1)
                throw new Exception("Formato incorrecto: descuento");
        }

    }
}
