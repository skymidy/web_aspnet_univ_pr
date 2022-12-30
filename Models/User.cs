using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASPnetWebApp.Enums;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Models;

[Index("LoginNameUppercase", IsUnique = true)]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string LoginName { get; set; }

    [Required] [StringLength(32)] public string LoginNameUppercase { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public string Role { get; set; }

    public List<PairRecord> PairRecords { get; set; } = new();

    public UserProfile? UserProfile { get; set; } = null;
}