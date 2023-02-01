using System.ComponentModel.DataAnnotations;

namespace AppDLL.Entity;
public class Role
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    private static ApplicationContext db = Context.db;

    public static Role GetById(int id)
    {
        try
        {
            return db.Roles.FirstOrDefault(r => r.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
