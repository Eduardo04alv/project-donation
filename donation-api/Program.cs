using Donation_Domain.Repository;
using Donation_Infrastructure.Ddcontext;
using Donation_Infrastructure.IRepository;
using Donation_Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers(); 

        builder.Services.AddDbContext<donorContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));
        builder.Services.AddTransient<IDonorRepository, DonorRepository>();

        builder.Services.AddDbContext<BeneficiarieContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));
        builder.Services.AddTransient<IBeneficiarieRepository, BeneficiarieRepository>();

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
    }
}