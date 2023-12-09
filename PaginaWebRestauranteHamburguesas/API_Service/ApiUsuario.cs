using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Persona;
using PaginaWebRestauranteHamburguesas.Models.Persona.Catalogos;
using System.Text.RegularExpressions;

namespace PaginaWebRestauranteHamburguesas.API_Service
{
    public class ApiUsuario : Controller
    {
        //Atributos
        private static ApiUsuario? _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231128183324.azurewebsites.net/api/Usuario";

        //Constructor
        private ApiUsuario() { }

        //Métodos
        public static ApiUsuario Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiUsuario();
            }
            return _instancia;
        }

        // GET: api/Usuario
        public async Task<Usuario?>
            ObtenerUsuario(int idUsuario)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerUsuario/{idUsuario}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Usuario>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<Cliente?>
            ObtenerCliente(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerCliente/{idCliente}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Cliente>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<Usuario[]?>
            ObtenerUsuarios()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerUsuarios
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Usuario[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<Cliente[]?>
            ObtenerClientes()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerClientes
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Cliente[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<GeneroCliente[]?>
            ObtenerGenerosCliente()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerGenerosCliente
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<GeneroCliente[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<GeneroCliente?>
            ObtenerGeneroCliente(int idGeneroCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerGeneroCliente/{idGeneroCliente}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<GeneroCliente>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<TipoUsuario[]?>
            ObtenerTiposUsuario()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerTiposUsuario
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<TipoUsuario[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<TipoUsuario?>
            ObtenerTipoUsuario(int idTipoUsuario)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerTipoUsuario/{idTipoUsuario}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<TipoUsuario>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<Usuario[]?>
            ObtenerUsuarios(string caracteres)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/ObtenerUsuarios/{caracteres}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Usuario[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<Cliente?>
            InicioSesionCliente(string nombreUsuario, string password)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/InicioSesionCliente/{nombreUsuario},{password}
                    """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<Cliente>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Usuario
        public async Task<string>
            InicioSesionAdmin(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            HttpResponseMessage response = await client.GetAsync($"""
                    {_url}/IncioSesionAdmin/{nombreUsuario},{password}
                    """);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Usuario
        public async Task<string>
            RegistroCuentaCliente(string nombreUsuario, string password, Cliente cliente)
        {
            VerificarCredenciales(nombreUsuario, password);
            VerificarDatosCliente(cliente);
            HttpResponseMessage response = await client.PostAsJsonAsync($"""
                    {_url}/RegistroCuentaCliente/{nombreUsuario},{password}
                    """, cliente);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        // POST: api/Usuario
        public async Task<string>
            RegistroCuentaAdmin(string nombreUsuario, string password)
        {
            VerificarCredenciales(nombreUsuario, password);
            HttpResponseMessage response = await client.PostAsync($"""
                    {_url}/RegistroCuentaAdmin/{nombreUsuario},{password}
                    """, null);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Usuario
        public async Task<string>
            ModificarUsuario(string oldNombreUsuario, string nombreUsuario, string password, int estadoUsuario)
        {
            VerificarCredenciales(nombreUsuario, password);
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarUsuario/{oldNombreUsuario},{nombreUsuario},{password},{estadoUsuario}
                    """, null);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Usuario
        public async Task<string>
            ModificarCliente(int idCliente, Cliente nuevoCliente)
        {
            VerificarDatosCliente(nuevoCliente);
            HttpResponseMessage response = await client.PutAsJsonAsync($"""
                    {_url}/ModificarCliente/{idCliente}
                    """, nuevoCliente);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // PUT: api/Usuario
        public async Task<string>
            ModificarEstadoUsuario(string nombreUsuario, int idEstado)
        {
            HttpResponseMessage response = await client.PutAsync($"""
                    {_url}/ModificarEstadoUsuario/{nombreUsuario},{idEstado}
                    """, null);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Usuario
        public async Task<string>
            EliminarUsuario(string nombreUsuario)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarUsuario/{nombreUsuario}
                    """);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadAsStringAsync();
        }

        // DELETE: api/Usuario
        public async Task<string>
            EliminarCliente(int idCliente)
        {
            HttpResponseMessage response = await client.DeleteAsync($"""
                    {_url}/EliminarCliente/{idCliente}
                    """);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        private void VerificarCredenciales(string nombreUsuario, string password)
        {
            if (String.IsNullOrEmpty(nombreUsuario) || String.IsNullOrEmpty(password))
                throw new Exception("Campos vacíos");
        }

        private void VerificarDatosCliente(Cliente cliente)
        {
            if (String.IsNullOrEmpty(cliente.Nombre) || String.IsNullOrEmpty(cliente.Apellido)
                || String.IsNullOrEmpty(cliente.TelefonoCliente) || String.IsNullOrEmpty(cliente.MailCliente))
                throw new Exception("Campos vacíos");
            DateTime inicio = new DateTime(1900, 01, 01);
            DateTime final = new FechaHora().ObtenerFechaHoraLocal();
            if (cliente.FechaNacimiento < inicio || cliente.FechaNacimiento > final)
                throw new Exception("Formato fecha incorrecto");
            if (!EmailValido(cliente.MailCliente)) 
                throw new Exception("Formato del mail inválido");
            if (!TelefonoValido(cliente.TelefonoCliente)) 
                throw new Exception("Formato del teléfono inválido");
        }

        static bool EmailValido(string mail)
        {
            // Regular expression pattern for mail validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the mail matches the pattern
            return Regex.IsMatch(mail, pattern);
        }
        static bool TelefonoValido(string telefono)
        {
            // Expresión regular para validar un número de 10 dígitos con el primer dígito igual a cero
            string pattern = @"^0\d{9}$";

            // Verifica si el número coincide con el patrón
            return Regex.IsMatch(telefono, pattern);
        }
    }
}
