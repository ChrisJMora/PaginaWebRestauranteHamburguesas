using PaginaWebRestauranteHamburguesas.API_Service;
using PaginaWebRestauranteHamburguesas.Models;
using PaginaWebRestauranteHamburguesas.Models.Persona;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Singleton API
ApiEstado.Singleton();
ApiOrden.Singleton();
ApiProducto.Singleton();
ApiUsuario.Singleton();
ApiCarrito.Singleton();
Sesion.Singleton();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "AccesoAdmin",
    pattern: "{area:exists}/{controller=Admin}/{action=InicioSesion}/{id?}");

app.MapControllerRoute(
    name: "AdminUsuarios",
    pattern: "{area:exists}/{controller=Usuario}/{action=PaginaPricipal}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
