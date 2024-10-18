using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NotificacaoColetaApi.Config;
using NotificacaoColetaApi.Data;
using NotificacaoColetaApi.Data.Repository;
using NotificacaoColetaApi.Data.Repository.Interfaces;
using NotificacaoColetaApi.Repositories;
using NotificacaoColetaApi.Services;
using NotificacaoColetaApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ColetaApi.Web", Version = "v1" });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddScoped<JwtSecurityTokenHandler>();

builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IColetaRepository, ColetaRepository>();
builder.Services.AddScoped<IColetaService, ColetaService>();

// Auth
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.IncludeErrorDetails = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("15c6b2f21c4b157880b49dd375cfea9e15c6b2f21c4b157880b49dd375cfea9e"))
    };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();