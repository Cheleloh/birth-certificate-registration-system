using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BirthCertificateRegistrationSystem.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<BirthCertificateDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Birth Certificate API",
        Version = "v1",
        Description = "API for Birth Certificate Registration System"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Welcome to the Birth Certificate Registration System!");



app.Run();