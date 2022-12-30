using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class AppUserProfile
{
    public Guid Id { get; private set; } = Guid.Empty;

    public string LoginName { get; private set; } = string.Empty;

    public string Role { get; private set; } = string.Empty;

    public List<PairRecord> PairRecords { get; private set; } = new();

    public UserProfile? UserProfile { get; private set; } = null;

    public string ErrorMessage { get; private set; } = string.Empty;

    public static AppUserProfile Success(User user)
    {
        return new AppUserProfile
        {
            Id = user.Id,
            LoginName = user.LoginName,
            Role = user.Role,
            PairRecords = user.PairRecords,
            UserProfile = user.UserProfile
        };
    }

    public static AppUserProfile Fail(string errorMessage)
    {
        return new AppUserProfile
        {
            ErrorMessage = errorMessage
        };
    }
}