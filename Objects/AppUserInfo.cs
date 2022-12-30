using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class AppUserInfo
{
    public Guid Id { get; private set; } = Guid.Empty;

    public string LoginName { get; private set; } = string.Empty;

    public string Role { get; private set; } = string.Empty;

    public AppUserProfile UserProfile { get; private set; } = null;

    public string ErrorMessage { get; private set; } = string.Empty;

    public static AppUserInfo Success(User user)
    {
        return new AppUserInfo
        {
            Id = user.Id,
            LoginName = user.LoginName,
            Role = user.Role,
            UserProfile = AppUserProfile.CopyUserProfile(user.UserProfile)
        };
    }

    public static AppUserInfo Fail(string errorMessage)
    {
        return new AppUserInfo
        {
            ErrorMessage = errorMessage
        };
    }
}