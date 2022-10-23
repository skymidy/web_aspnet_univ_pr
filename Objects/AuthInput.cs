namespace ASPnetWebApp.Objects;
/// <summary>
/// User's authentication data class
/// </summary>
public class AuthInput
{
    /// <summary>
    /// User's login
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// User' password
    /// </summary>
    public string Password { get; set; }
}