using domain.Interfaces.Repositorios;
using domain.Interfaces.Services;
using domain.Services;
using infra.Context;
using infra.Repositorios;

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
builder.Services.AddScoped<Contexto, Contexto>();

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
