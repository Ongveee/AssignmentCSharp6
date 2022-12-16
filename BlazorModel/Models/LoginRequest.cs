using System.ComponentModel.DataAnnotations;

namespace BlazorModel.Models;

public class LoginRequest
{
    [Required]
    public string username { get; set; }

    [Required]
    public string password { get; set; }
}