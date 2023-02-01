using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppDLL.Entity;
public class AuthToken
{
    public AuthToken(string token, Client client)
    {
        Token = token;
        TokenTime = DateTime.Now;
        Client = client;
    }

    public AuthToken()
    {
    }

    [Key]
    public string Token { get; set; }
    public DateTime TokenTime { get; set; }
    public virtual Client Client { get; set; } 

    private static ApplicationContext db = Context.db;

    public static bool AddToken(string token, Client client)
    {
        var jwt = new AuthToken(token, client);
        try
        {
            db.AuthTokens.Add(jwt);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static bool RemoveToken(TimeSpan timeSpan)
    {
        try
        {
            db.AuthTokens.RemoveRange(db.AuthTokens.Where(t => (DateTime.Now - timeSpan) > t.TokenTime));
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static Client? ContainsToken(string token)
    {
        var strtoken = db.AuthTokens.Include(r => r.Client)
        .FirstOrDefault(a => a.Token == token);
        if (strtoken is null) return null;
        db.AuthTokens.Remove(strtoken);
        return strtoken.Client;
    }
    /*public static bool ContainsToken(string token)
    {
        try
        {
            return db.AuthTokens.FirstOrDefault(t => t.Token == token) is not null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }*/
}