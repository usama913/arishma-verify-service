using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Arishma.Verify.Application;
namespace Arishma.Verify.Infrastructure;
public static class PersistenceExtensions
{
    // THE SWITCH: change one value, in one place, per service.
    // Option A (config): appsettings.json -> "Database": { "Provider": "Postgres" or "MySql", "ConnectionString": "..." }
    // Option B (env, wins over config): DATABASE_PROVIDER=Postgres|MySql and DATABASE_CONNECTION_STRING="..."
    // No code change, no other service affected. Provider is read at startup only.
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        var provider = DatabaseProviderParser.Parse(
            Environment.GetEnvironmentVariable("DATABASE_PROVIDER")
            ?? config["Database:Provider"]);
        var conn = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
            ?? config["Database:ConnectionString"]
            ?? "Host=localhost;Database=arishma_verify;Username=arishma;Password=arishma-dev-only";
        services.AddSingleton(new DatabaseSettings(provider, conn));
        services.AddDbContext<AppDbContext>(o =>
        {
            if (provider == DatabaseProvider.MySql)
                o.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 0)));
            else
                o.UseNpgsql(conn);
        });
        services.AddScoped<IVerificationRepository, EfVerificationRepository>();
        return services;
    }
}
