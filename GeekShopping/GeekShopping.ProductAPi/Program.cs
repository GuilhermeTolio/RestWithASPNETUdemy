using AutoMapper;
using GeekShopping.ProductAPi.Config;
using GeekShopping.ProductAPi.Model.Context;
using GeekShopping.ProductAPi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GeekShopping.ProductAPi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connection = builder.Configuration.GetConnectionString("MySQLConnection");

        builder.Services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 28))));

        var mapperConfig = MappingConfig.RegisterMaps();
        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPi", Version = "v1" }));

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