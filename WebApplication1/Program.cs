
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
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
            // builder.Services.AddDbContext<TheTaskContext>(ttc => ttc.UseInMemoryDatabase("TheTaskDB"));
            // builder.Services.AddSqlServer<TheTaskContext>("Data Source=JULIOCSANTAMAN;Initial Catalog=TheTaskDB;user id=JULIOCSANTAMAN\\julio;password=");
            builder.Services.AddSqlServer<TheTaskContext>(builder.Configuration.GetConnectionString("cnTheTask"));


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

            //app.MapGet("/dbconnection", async ([FromServices] TheTaskContext dbContext) =>
            //{
            //    dbContext.Database.EnsureCreated();
            //    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
            //});

            app.Run();
        }
    }
}
