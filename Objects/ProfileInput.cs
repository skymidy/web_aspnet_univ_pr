using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class ProfileInput
{
    public string Knowledge { get; init; } = string.Empty;

    public string Interests { get; init; } = string.Empty;

    public bool SearchStatus { get; init; } = false;

    public bool MentorSearchStatus { get; init; } = false;

    public bool MentorStatus { get; init; } = false;

    public string Description { get; init; } = string.Empty;
    
    public static void CopyToModel(ProfileInput input, UserProfile model)
    {
        model.Knowledge = input.Knowledge;
        model.Interests = input.Interests;
        model.SearchStatus = input.SearchStatus;
        model.MentorSearchStatus = input.MentorSearchStatus;
        model.MentorStatus = input.MentorStatus;
        model.Description = input.Description;
    }
}