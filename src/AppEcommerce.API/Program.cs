using AppEcommerce.Application.Services;
using AppEcommerce.Domain.Interfaces;
using AppEcommerce.Infra.Data.Context;
using AppEcommerce.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // <= importante

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AppEcommerce API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppEcommerce API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
