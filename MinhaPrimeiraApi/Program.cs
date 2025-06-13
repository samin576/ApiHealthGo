using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Services;
using MinhaPrimeiraApi.Contracts.Repository;
using MeuPrimeiroCrud.Repository;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Infrastructure;
namespace MinhaPrimeiraApi
{
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);
            //DEPENDENCIA
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<INacaoService, NacaoService>();
            builder.Services.AddTransient<INacaoRepository, NacaoRepository>();
            // Add services to the container.

            builder.Services.AddControllers();
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
}