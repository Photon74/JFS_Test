using JFS_Test.Mapper;
using JFS_Test.Repositories;
using JFS_Test.Services;
using JFS_Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace JFS_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddScoped<IStatementService, StatementService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IBalanceService, BalanceService>();
            builder.Services.AddScoped<IStatementBuilder, StatementBuilder>();

            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            builder.Services.AddControllers(options =>
            {
                options.OutputFormatters.Add(new CsvSerializerOutputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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