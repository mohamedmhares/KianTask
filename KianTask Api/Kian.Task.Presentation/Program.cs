
using Kian.task.Core.Interfaces;
using Kian.Task.Infrastructure.Data;
using KianTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KianTask.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EmpDbContext>(options => options.UseSqlServer(ConnectionString));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEmployeeRebository, EmployeeRebository>();
            builder.Services.AddScoped(typeof(IGenericRebository<>), typeof(GenericRebository<>));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            //the Following Code Is Written To Generate The Database When The App Started 
            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<EmpDbContext>();
            var logger = Services.GetRequiredService<ILogger<Program>>();
            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "The error Occured During Migration");
            }

            app.Run();
        }
    }
}
