using Microsoft.EntityFrameworkCore;
using Livraria.Data;
using Livraria.Models;
using Livraria.Models.Contratos;
using Livraria.Data.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conexao = builder.Services.AddDbContext<ContextoBanco>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("Conexao")));


builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

builder.Services.AddScoped<ILivroModel, LivroModel>();
builder.Services.AddScoped<IGeralPersistencia, GeralPersistencia>();
builder.Services.AddScoped<ILivroPersistencia, LivroPersistencia>();


builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
