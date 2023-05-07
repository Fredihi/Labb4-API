using API_Models;
using Labb4_API.Models;
using Labb4_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IInterestApi<Interest>, InterestRepository>();
            builder.Services.AddScoped<ILabb4<User>, UserRepository>();
            builder.Services.AddScoped<IUserInterest<UserInterest>, UserInterestRepo>();
            //Entity Framework to SQL Database
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


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