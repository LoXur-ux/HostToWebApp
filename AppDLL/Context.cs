using Npgsql;

namespace AppDLL;
public class Context
{
    public static ApplicationContext db { get; private set; }
    public static NpgsqlConnection npgsql { get; private set; }
    public Context(ApplicationContext applicationContext)
    {
        db = applicationContext;
    }
    public static void AddDb(ApplicationContext applicationContext)
    {
        db = applicationContext;
    }
}
