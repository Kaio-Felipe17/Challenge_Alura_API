using API_Alura.Application.Profile;
using API_Alura.Core.Repository;
using API_Alura.Infrastructure.Context;
using API_Alura.Infrastructure.Services;
using API_Alura.Middleware;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IDepoimentosRepository, DepoimentosRepository>();
builder.Services.AddScoped<IDestinosRepository, DestinosRepository>();
builder.Services.AddScoped<IOpenAiService, OpenAiService>();

var connectionString = builder
    .Configuration
    .GetConnectionString("AluraDatabase");

builder.Services
    .AddDbContext<DatabaseContext>(opts => opts
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Mappings());
});

IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("*");
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Depoimentos API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Configuration["OPENAI_API_KEY"] = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
