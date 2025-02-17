using Microsoft.OpenApi.Models;
using NLog.Web;
using ServiceManager.Api.middlewares;
using ServiceManager.Application.controll;
using ServiceManager.Infra.loggers;
using ServiceManager.Infra.resources;
using ServiceManager.Interfaces.inbound;
using ServiceManager.Interfaces.outbound;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceManagerAPI", Description = "Gerenciamento de Serviços e API Paschoalotto", Version = "v1" });
});

builder.Services.AddScoped<IServiceControll, ServiceControll>();
builder.Services.AddScoped<IServiceResource, ServiceManagementObject>();
builder.Services.AddScoped<ILoggerAdapter<GlobalExceptionMiddleware>, LoggerAdapter<GlobalExceptionMiddleware>>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();