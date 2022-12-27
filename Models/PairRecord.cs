using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPnetWebApp.Models;

public class PairRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.Empty;
    
    public Guid UserId { get; set; } = Guid.Empty;
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    public Guid PairedUserId { get; set; } = Guid.Empty;
    
    public string Type { get; set; } = string.Empty;

    public float Rating { get; set; } = .0f;
    
    public string RatingDescription { get; set; } = string.Empty;
}