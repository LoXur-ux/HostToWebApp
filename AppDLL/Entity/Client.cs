using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace AppDLL.Entity;
public class Client
{
    public Client() { }

    public Client(int id, bool isAnonimus, int orderCount, Human human)
    {
        Id = id;
        IsAnonimus = isAnonimus;
        Human = human;
    }

    [Key]
    public int Id { get; set; }
    [Required]
    public bool IsAnonimus { get; set; }
    public virtual Human Human { get; set; }

    private static ApplicationContext db = Context.db;

    public static bool Add(Client client)
    {
        try
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static Client Get(string login, string password)
    {
        try
        {
            return db.Clients.FirstOrDefault(c => c.Human.Login == login && c.Human.Password == password);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    public static Client GetByLogin(string login)
    {
        try
        {
            return db.Clients.FirstOrDefault(c => c.Human.Login == login);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}
