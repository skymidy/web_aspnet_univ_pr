using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class AppUserProfile
{
    public string Knowledge { get; init; }

    public string Interests { get; init; } 

    public bool SearchStatus { get; init; }

    public bool MentorSearchStatus { get; init; }

    public bool MentorStatus { get; init; }

    public string Description { get; init; }

    public static AppUserProfile CopyUserProfile(UserProfile userProfile)
    {
        return new AppUserProfile
        {
            Knowledge = userProfile.Knowledge,
            Interests = userProfile.Interests,
            SearchStatus = userProfile.SearchStatus,
            MentorSearchStatus = userProfile.MentorSearchStatus,
            MentorStatus = userProfile.MentorStatus,
            Description = userProfile.Description
        };
    }
}