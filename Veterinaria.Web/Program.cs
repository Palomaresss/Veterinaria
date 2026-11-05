using Microsoft.EntityFrameworkCore;
using Veterinaria.Datos;
using Veterinaria.Negocios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL");

// Registrar Contexto y Servicio
builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<MascotaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta predeterminada hacia Mascotas/Crear
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mascotas}/{action=Crear}/{id?}");

app.Run();