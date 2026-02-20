using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Repositories;
using FilmesMoura.WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// adiciona o contexto do banco de dados (exemplo SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// adiciona o repositório  ao contêiner de injeção de dependência
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

// adiciona servicos de controllers
builder.Services.AddControllers();

var app = builder.Build();

// adiciona o mapeamento de controllers
app.MapControllers();

app.Run();