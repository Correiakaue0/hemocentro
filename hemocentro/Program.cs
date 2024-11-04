using domain.Interfaces.Repositorios;
using domain.Interfaces.Services;
using domain.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using hemocentro.Extensions;
using infra.Context;
using infra.Repositorios;
using Service.Services;
using Store.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection SqlContext
builder.Services.AddScoped<IEstoqueSangueService, EstoqueSangueServices>();
builder.Services.AddScoped<IDoadoresService, DoadoresServices>();
builder.Services.AddScoped<IAgendamentoDoacoesService, AgendamentoDoacoesServices>();
builder.Services.AddScoped<IDoadoresRepositorio, DoadoresRepositorio>();
builder.Services.AddScoped<IEstoqueSangueRepositorio, EstoqueSangueRepositorio>();
builder.Services.AddScoped<IAgendamentoDoacoesRepositorio, AgendamentoDoacoesRepositorio>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<Contexto, Contexto>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:9000") // Substitua pela URL do seu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Configuration Authentication Jwt
builder.Services.AddJwtAuthentication();

//Configuration Swagger
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseCors("PermitirFrontend");

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
