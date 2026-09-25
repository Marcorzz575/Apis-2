using Microsoft.EntityFrameworkCore;
using APIClaveProdServ_SAT.Repositories;
using APIClaveProdServ.CasosDeUso;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

// Registramos el DbContext apuntando a "DefaultConnection"
builder.Services.AddDbContext<APIClaveProdServContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<IActualizaClavesProdServCasoDeUso, ActualizaClaveProdServCasoDeUso>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPoliticaCORS", policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Especifica la ruta correcta del archivo JSON generado
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIClaveProdServ-SAT v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("MiPoliticaCORS");

app.Run();
