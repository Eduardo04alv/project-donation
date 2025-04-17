using Donation_application.Iservices;
using Donation_Domain.Repository;
using Donation_application.services;
using Donation_Infrastructure.Ddcontext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registra el DbContext
builder.Services.AddDbContext<donorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))); 

// Inyección de dependencias
builder.Services.AddScoped<IDonorService, DonorService>(); 
builder.Services.AddScoped<IDonorRepository, DonorRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
