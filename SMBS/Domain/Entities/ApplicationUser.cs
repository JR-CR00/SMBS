using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationUser  : IdentityUser
{

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public string? Avatar { get; set; } = null;

    [Required]
    [ForeignKey("UserStatus")]
    public int UserStatusId { get; set; }
    public required UserStatus UserStatus { get; set; }
    
    public DateTime CreateAt { get; set;} = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set;} = null;
    public DateTime? DeleteAt { get; set;} = null;

}