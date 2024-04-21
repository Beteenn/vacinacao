using CartaoVacina.Application.Services;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.Core.Interfaces.Services;
using CartaoVacina.DataAccess.Persistence;
using CartaoVacina.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona contexto do banco de dados

var connectionString = builder.Configuration.GetConnectionString("CartaoVacina");
builder.Services.AddDbContext<CartaoVacinaContext>(opts => opts.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddScoped<IPessoaService, PessoaService>();

// Adicionar Repositorios

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();


builder.Services.AddControllers();
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
