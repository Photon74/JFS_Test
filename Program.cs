using JFS_Test.Repositories;
using JFS_Test.Services;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace JFS_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IRepository, Repository>();

            builder.Services.AddControllers(opt =>
            {
                opt.OutputFormatters.Add(new CsvOutputFormatter());
                opt.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

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

            //app.UseWelcomePage();

            app.Run();
        }
    }
}