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
    public bool IsAuthenticated { get; protected set; }

    public string LoginName { get; protected set; } = string.Empty;
    
    /// <summary>
    /// User's role
    /// </summary>
    public RoleType Role { get; protected set; }
     
    public string ErrorMessage { get; private set; } = string.Empty;

    /// <summary>
    /// User's successful authentication method 
    /// </summary>
    /// <param name="role">User's role</param>
    /// <returns></returns>
    public static AuthInfo Success(string loginName, RoleType role)
    {
        return new AuthInfo()
        {
            LoginName = loginName,
            IsAuthenticated = true,
            Role = role
        };
    }

    /// <summary>
    /// User's failed authentication method 
    /// </summary>
    /// <returns></returns>
    public static AuthInfo Fail(string errorMessage)
    {
        return new AuthInfo()
        {
            IsAuthenticated = false,
            Role = RoleType.Undefined,
            ErrorMessage = errorMessage
        };
    }
}