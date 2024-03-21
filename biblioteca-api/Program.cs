using biblioteca_api.Repositorio.interfaces;
using biblioteca_api.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using biblioteca_api.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string chaveSecreta = "20ccd6b9-a66a-4761-8b70-64a656226f52";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Tarefas - API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Jwt Autenticação",
        Description = "Entre com o JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new string[] {} }
    });
});

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
        builder.Services.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorio>();
        builder.Services.AddScoped<IEditoraRepositorio, EditoraRepositorio>();
        builder.Services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
        builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
        builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();


        builder.Services.AddDbContext<SistemaBibliotecaDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
        );

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true, //Emissor do token,
        ValidateAudience = true, //Destinatário do Token
        ValidateLifetime = true, //Termino do Token
        ValidateIssuerSigningKey = true, //Chave de Assinatura
        ValidIssuer = "empresa",
        ValidAudience = "aplicacao",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
