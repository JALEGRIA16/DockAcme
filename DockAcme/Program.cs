using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DockAcme;
using SoapCore;
using DockAcme.Data;
using System.ServiceModel;
using DockAcme.Services;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(IPAddress.Any, 80);  // la aplicaci�n escucha en el puerto 80 dentro del contenedor
//});

// Agregar Swagger para la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n del DbContext para SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.AllowAnyOrigin()                     //WithOrigins("https://localhost:")  // Permitir solicitudes desde https://localhost
                  .AllowAnyMethod()                     // Permitir cualquier m�todo (GET, POST, etc.)
                  .AllowAnyHeader();                    // Permitir cualquier encabezado
        });
});

// Agregar servicios SOAP
builder.Services.AddSoapCore();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IEnvioService, EnvioService>();

var app = builder.Build();

// Aplicar la pol�tica CORS antes de las rutas
app.UseCors("AllowLocalhost");

// Configurar el servicio SOAP para el endpoint
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.UseSoapEndpoint<IPedidoService>("/PedidoService.svc", new SoapEncoderOptions(), SoapCore.SoapSerializer.DataContractSerializer);
    endpoints.UseSoapEndpoint<IEnvioService>("/EnvioService.svc", new SoapEncoderOptions(), SoapCore.SoapSerializer.DataContractSerializer);
});

// Servir archivos est�ticos y buscar index.html
app.UseDefaultFiles();  // Busca autom�ticamente index.html en wwwroot
app.UseStaticFiles();  // Sirve archivos est�ticos desde wwwroot

// Habilitar Swagger solo en el entorno de desarrollo
//if (app.Environment.IsDevelopment())
//{

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acme v1"); c.RoutePrefix = "swagger"; });
//}

// Otros middlewares
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
