using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Repositories;
using FilmesMoura.WebAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// adiciona o contexto do banco de dados (exemplo SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// adiciona o repositório  ao contêiner de injeção de dependência
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// adiciona o serviço de autenticação JWT Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //valida quem esta solicitando 
            ValidateIssuer = true,

            //valida quem esta recebendo o token
            ValidateAudience = true,

            //define se o tempo de expiração será validado
            ValidateLifetime = true,

            //forma de criptografia e valida a chave de autenticação
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //nome do issuer (de onde está vindo)
            ValidIssuer = "api_filmes",

            //nome do audience (para onde está indo)
            ValidAudience = "api_filmes"
        };
    });


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
{
    Version = "v1",
    Title = "Filmes API",
    Description = "Uma API com um catálogo de filmes",
    TermsOfService = new Uri("https://examplo.com/terms"),
    Contact = new Microsoft.OpenApi.OpenApiContact
    {
        Name = "FelipeTorolho",
        Url = new Uri("https://github.com/FelipeTorolho")
    },
    License = new Microsoft.OpenApi.OpenApiLicense
    {
        Name = "Exemple License",
        Url = new Uri("https://exemple.com/license")
    }
  });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT:"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddCors(options => 
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// adiciona servicos de controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => {});
    app.UseSwaggerUI(options =>
    {  
         options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
         options.RoutePrefix = string.Empty; 
    });
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

// adiciona o mapeamento de controllers
app.MapControllers();

app.Run();