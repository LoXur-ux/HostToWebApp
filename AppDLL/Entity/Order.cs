using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;

namespace AppDLL.Entity;

public class Order
{
    public Order() { }

    [Key]
    public int Id { get; set; }
    public virtual Client Client { get; set; }
    [Required]
    public string ClientQRCode { get; set; }
    [Required]
    public string EmplQRCode { get; set; }
    [Required]
    public DateTime OrderTime { get; set; }
    public DateTime? TimeToRecive { get; set; }
    public DateTime? TimeTeDeliver { get; set; }
    [Required]
    public string AddressFrom { get; set; }
    [Required]
    public string AddressTo { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? Commentary { get; set; }
    public virtual Human? Employer { get; set; } 
    public virtual Status Status { get; set; }
    private static ApplicationContext db = Context.db;

    

    public static bool Add(Order order)
    {
        try
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static bool Update(Order order)
    {
        try
        {
            var _order = GetById(order.Id);
            _order = order;
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public static Order GetById(int id)
    {
        try
        {
            return db.Orders.FirstOrDefault(o => o.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public static List<Order> GetAllByLogin(string login)
    {
        try
        {
            return db.Orders.Where(o => o.Client.Human.Login == login).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public static List<Order> GetToWorker(string login)
    {
        try
        {
            return db.Orders.Where(o => o.Employer.Login == login).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public static int GetLastIndex()
    {
        try
        {
            return db.Orders.Count();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 0;
        }
    }
}
