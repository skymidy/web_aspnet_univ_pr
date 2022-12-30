namespace ASPnetWebApp.Objects;

public class PairInfo
{
    public Guid UserId { get; set; } = Guid.Empty;
    
    public Guid PairedUserId { get; set; } = Guid.Empty;
    
    public string Type { get; set; } = string.Empty;

    public float Rating { get; set; } = .0f;
    
    public string RatingDescription { get; set; } = string.Empty;

    public static PairsInfo FromModelTPairsInfo(User user)
    {
        return new PairsInfo
        {
            Id = user.Id,
            LoginName = user.LoginName,
            Role = user.Role,
            PairRecords = user.PairRecords,
            UserProfile = AppUserProfile.CopyUserProfile(user.UserProfile)
        };
    }

    public static PairsInfo Fail(string errorMessage)
    {
        return new PairsInfo
        {
            ErrorMessage = errorMessage
        };
    }
}
