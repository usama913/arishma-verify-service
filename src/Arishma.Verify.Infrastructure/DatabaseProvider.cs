namespace Arishma.Verify.Infrastructure;
public enum DatabaseProvider { Postgres, MySql }
public static class DatabaseProviderParser
{
    public static DatabaseProvider Parse(string? value) => value?.Trim().ToLowerInvariant() switch
    {
        "mysql" or "mariadb" => DatabaseProvider.MySql,
        _ => DatabaseProvider.Postgres,
    };
}
