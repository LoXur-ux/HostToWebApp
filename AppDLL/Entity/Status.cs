using System.ComponentModel.DataAnnotations;

namespace AppDLL.Entity;
public class Status
{
    public Status() { }

    public Status(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

    private static ApplicationContext db = Context.db;

    public static Status GetById(int id)
    {
        try
        {
            return db.Statuses.FirstOrDefault(s => s.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}