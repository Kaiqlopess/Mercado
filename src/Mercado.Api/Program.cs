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

builder.Services.AddScoped<IRepositorioSetor, PostgresRepositorioSetor>();
builder.Services.AddScoped<IRepositorioProduto, PostgresRepositorioProduto>();
builder.Services.AddScoped<IRepositorioCategoria, PostgresRepositorioCategoria>();

builder.Services.AddScoped<ICriarProdutoService, CriarProdutoService>();
builder.Services.AddScoped<ICriarCategoriaService, CriarCategoriaService>();
builder.Services.AddScoped<ICriarSetorService, CriarSetorService>();



builder.Services.AddScoped<IObterProdutoService, ObterProdutoService>();
builder.Services.AddScoped<IObterCategoriaService, ObterCategoriaService>();
builder.Services.AddScoped<IObterSetorService, ObterSetorService>();

builder.Services.AddScoped<IDeletarProdutoService, DeletarProdutoService>();
builder.Services.AddScoped<IDeletarCategoriaService, DeletarCategoriaService>();
builder.Services.AddScoped<IDeletarSetorService, DeletarSetorService>();

builder.Services.AddScoped<IAtualizarProdutoService, AtualizarProdutoService>();
builder.Services.AddScoped<IAtualizarCategoriaService>();
builder.Services.AddScoped<IAtualizarSetorService, AtualizarSetorService>();

builder.Services.AddScoped<ProdutoVendidoNoCaixaService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaAppFront", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("MinhaAppFront");

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
