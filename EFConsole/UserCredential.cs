namespace EFConsole;

public class UserCredential
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

}