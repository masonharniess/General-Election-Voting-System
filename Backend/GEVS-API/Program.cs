using GEVS_API.Context;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<GevsContext>(opt =>
            opt.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularOrigins",
                policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:4200") 
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials(); 
                });
        });

        var app = builder.Build();
        
        app.UseCors("AllowAngularOrigins");
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            endpoints.MapFallbackToFile("index.html"); // Fallback
        });
        
        
        app.UseStaticFiles(); // Enable static file serving

        app.MapControllers();
        
        try
        {
            MigrateDB.InitDB(app);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        app.Run();
        
        
    }
}