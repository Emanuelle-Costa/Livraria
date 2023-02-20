using Livraria.Application;
using Livraria.Persistence;
using Livraria.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conexao = builder.Services.AddDbContext<LivrariaContexto>(opc => opc.UseSqlServer(
    builder.Configuration.GetConnectionString("Conexao")));

builder.Services.AddControllers();

builder.Services.AddScoped<ILivroPersistence, LivroPersistence>();
builder.Services.AddScoped<ILivroService, LivroService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
