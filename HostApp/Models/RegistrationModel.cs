namespace HostApp.Models;
public class RegistrationModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAnonimus { get; set; }
    public string? FirstName { get; set; }
    public string? MidName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }

    public static bool Check(RegistrationModel model)
        => model is null || string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email);
}
