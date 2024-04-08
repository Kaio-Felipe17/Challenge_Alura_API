using API_Alura.Application.Profile;
using API_Alura.Core.Repository;
using API_Alura.Infrastructure.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDepoimentosRepository, DepoimentosRepository>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Profiles());
});

IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var connectionString = builder.Configuration.GetConnectionString("AluraDatabase");

builder.Services
    .AddDbContext<DatabaseContext>(opts => opts
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
