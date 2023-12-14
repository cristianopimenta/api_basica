using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtimizeLaudoPredial.Data;
using OtimizeLaudoPredial.Repositorios;
using OtimizeLaudoPredial.Repositorios.Interfaces;

namespace OtimizeLaudoPredial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

                       //...
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5001); // to listen for incoming http connection on port 5001
                options.ListenAnyIP(7001, configure => configure.UseHttps()); // to listen for incoming https connection on port 7001
            });
            //...
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<OtimizeLaudoPredialDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

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
