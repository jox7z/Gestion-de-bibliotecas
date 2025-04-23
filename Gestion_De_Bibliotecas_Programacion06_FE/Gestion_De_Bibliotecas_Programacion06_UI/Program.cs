using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Cliente;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Libro;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Prestamo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IsrvAutor, srvAutor>();
builder.Services.AddScoped<IsrvCliente, srvCliente>();
builder.Services.AddScoped<IsrvLibro, srvLibro>();
builder.Services.AddScoped<IsrvPrestamo, srvPrestamo>();

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
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
