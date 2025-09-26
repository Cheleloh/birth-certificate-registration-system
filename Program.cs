using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BirthCertificateRegistrationSystem.Data;
using Swashbuckle.AspNetCore.Annotations;
using BirthCertificateRegistrationSystem.Models;


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

builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Welcome to the Birth Certificate Registration System!");


app.UseAuthorization();
app.MapControllers();
app.Run();