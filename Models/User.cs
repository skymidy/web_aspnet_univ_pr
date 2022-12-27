using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.Empty;
    
    public string Login { get; set; } = string.Empty;

    public string Hash { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}