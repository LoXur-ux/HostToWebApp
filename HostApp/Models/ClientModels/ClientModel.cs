namespace HostApp.Models.ClientModels;
public class ClientModel
{
    public ClientModel() { }
    public ClientModel(int id, bool isAnonimus, string login, string email)
    {
        Id = id;
        IsAnonimus = isAnonimus;
        Login = login;
        Email = email;
    }

    public ClientModel(int id, int role, bool isAnonimus, string login, string? email, string? firstName, string? midName, string? lastName, string? phoneNumber)
    {
        Id = id;
        IsAnonimus = isAnonimus;
        Role = role;
        Login = login;
        Email = email;
        FirstName = firstName;
        MidName = midName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public int Id { get; set; }
    public int Role { get; set; }
    public bool IsAnonimus { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? MidName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
}

