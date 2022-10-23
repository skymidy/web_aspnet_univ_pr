using ASPnetWebApp.Enums;

namespace ASPnetWebApp.Objects;

/// <summary>
/// User's information class
/// </summary>
public class AuthInfo
{
    /// <summary>
    /// User's authentication status
    /// </summary>
    public bool IsAuthenticated { get; private set; }
    
    /// <summary>
    /// User's role
    /// </summary>
    public RoleType Role { get; private set; }

    /// <summary>
    /// User's successful authentication method 
    /// </summary>
    /// <param name="role">User's role</param>
    /// <returns></returns>
    public static AuthInfo Success(RoleType role)
    {
        return new AuthInfo()
        {
            IsAuthenticated = true,
            Role = role
        };
    }

    /// <summary>
    /// User's failed authentication method 
    /// </summary>
    /// <returns></returns>
    public static AuthInfo Fail()
    {
        return new AuthInfo()
        {
            IsAuthenticated = false,
            Role = RoleType.Undefined
        };
    }
}