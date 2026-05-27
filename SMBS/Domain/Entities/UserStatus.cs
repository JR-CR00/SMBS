using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Name), IsUnique = true)]
public class UserStatus
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}