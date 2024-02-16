using Depoimentos_API.Context;
using Depoimentos_API.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("AluraApiDatabase");

builder.Services
    .AddDbContext<DatabaseContext>(opts => opts
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddScoped<IDepoimentosRepository, DepoimentosRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
