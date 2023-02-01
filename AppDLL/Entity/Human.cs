using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AppDLL.Entity;
public class Human
{
    public Human() { }

    [Key]
    public int Id { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? MidName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNamber { get; set; }
    public virtual Role Role { get; set; }

    private static ApplicationContext db = Context.db!;

    public static bool Add(Human human)
    {
        try
        {
            db.Humans.Add(human);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    public static Human SetEmloyeeToOrder()
    {
        try
        {
            List<Human> humans = db.Humans.Where(e => e.Role.Id == 2).ToList();
            return humans[new Random().Next(0, humans.Count)];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    public static Human FindById(int id)
    {
        try
        {
            var human = db.Humans.FirstOrDefault(h => h.Id == id);
            return human;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    public static bool Update(Human human)
    {
        try
        {
            db.Humans.Update(human);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}
