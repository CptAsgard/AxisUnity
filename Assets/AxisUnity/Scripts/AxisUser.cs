public class AxisUser
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Ticket { get; private set; }

    public AxisUser(string username, string email, string ticket)
    {
        this.Username = username;
        this.Email = email;
        this.Ticket = ticket;
    }

    public void GetAvatarImageUrl()
    {

    }

    public void GetEmailHash()
    {

    }
}