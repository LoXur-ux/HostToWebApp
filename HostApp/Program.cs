using AppDLL;
using RestPanda;
using Trivial.Security;

namespace HostApp;

public class Program
{
    public static HashSignatureProvider Sign { get; private set; } = null!;
    static void Main(string[] args)
    {
        using var db = new ApplicationContext(ApplicationContext.GetDb());
        Sign = HashSignatureProvider.CreateHS256("some-texxt");
        var config = new PandaConfig();
        config.AddHeader("access-control-allow-origin", "*");
        config.AddHeader("access-control-allow-headers", "*");
        var server = new PandaServer(config, new Uri("http://localhost:8888"));
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        server.Start();
        Console.WriteLine("Server started");
        Console.Read();
        server.Stop();
    }
}