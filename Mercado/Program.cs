using Mercado.Application.UseCase.CategoriaUseCase;
using Mercado.Application.UseCase.ProdutoUseCase;
using Mercado.Application.UseCase.SetorUseCase;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Infra.Context;
using Mercado.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MercadoContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioSetor, RepositorioSetor>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();

builder.Services.AddScoped<CriarCategoriaService>();
builder.Services.AddScoped<CriarProdutoService>();
builder.Services.AddScoped<CriarSetorService>();


builder.Services.AddScoped<ObterProdutoService>();
builder.Services.AddScoped<ObterCategoriaService>();
builder.Services.AddScoped<ObterSetorService>();


builder.Services.AddScoped<DeletarProdutoService>();
builder.Services.AddScoped<DeletarCategoriaService>();

builder.Services.AddScoped<AtualizarProdutoService>();
builder.Services.AddScoped<AtualizarCategoriaService>();


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
