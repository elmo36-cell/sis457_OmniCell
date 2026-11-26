using Microsoft.EntityFrameworkCore;
using WebOmnicell.Data;

var builder = WebApplication.CreateBuilder(args);

// Servicios de MVC con vistas.
builder.Services.AddControllersWithViews();

// Base de datos que ya existe (LabOmnicell); la cadena está en appsettings.json.
builder.Services.AddDbContext<LabOmnicellContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LabOmnicell")));

// Memoria en el servidor para guardar la sesión del usuario que inició sesión.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// En producción se muestra una página de error propia y se fuerza HTTPS.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// La sesión debe ir antes de usar HttpContext.Session en los controladores.
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

// Ruta por defecto: la raíz del sitio abre el catálogo.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogo}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
