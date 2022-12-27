namespace ASPnetWebApp.Objects;
/// <summary>
/// User's authentication data class
/// </summary>
public class AuthInput
{
    /// <summary>
    /// User's login
    /// </summary>
    public string login { get; set; } = string.Empty;

    /// <summary>
    /// User' password
    /// </summary>
    public string password { get; set; } = string.Empty;
}