using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GEVS_API.Context;

public class MigrateDB
{
    public static void InitDB(WebApplication app)
    {
        var retry = 10;

        while (retry > 0)
        {
            try
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetService<GevsContext>();
                dbContext?.Database.Migrate();
                dbContext?.Database.EnsureCreated();
                break;
            }
            catch (SqliteException e)
            {
                retry -= 1;
                Console.WriteLine("Postgres is not ready. Attempting to connect in 5 secs. Retries left: " + retry);
                Thread.Sleep(5000);
            }
        }
    }
}