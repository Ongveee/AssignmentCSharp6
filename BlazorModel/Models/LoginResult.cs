namespace BlazorModel.Models;

public class LoginResult
{
    public bool Successful { get; set; }
    public string error { get; set; }
    public string token { get; set; }
}