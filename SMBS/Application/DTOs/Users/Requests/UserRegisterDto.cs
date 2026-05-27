using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.Requests;

public class UserRegisterDto
{
    [Required(ErrorMessage = "The field email is required")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "The field name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "The field password is required")]
    public string? Password { get; set; }
}




