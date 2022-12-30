using ASPnetWebApp.Database;
using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class PairInfo
{
    public string UserId { get; set; } = string.Empty;
    
    public string PairedUserId { get; set; } = string.Empty;
    
    public string Type { get; set; } = string.Empty;

    public float Rating { get; set; } = .0f;
    
    public string RatingDescription { get; set; } = string.Empty;

    public static PairInfo FromModelTPairInfo(PairRecord record, ApplicationContext db)
    {
        var userId = db.Users.Where((user => user.Id.Equals(record.UserId))).First().LoginName;
        var pairedUserId = db.Users.Where((user => user.Id.Equals(record.PairedUserId))).First().LoginName;
        return new PairInfo
        {
            UserId = userId,
            PairedUserId = pairedUserId,
            Type = record.Type,
            Rating = record.Rating,
            RatingDescription = record.RatingDescription
        };
    }
}
