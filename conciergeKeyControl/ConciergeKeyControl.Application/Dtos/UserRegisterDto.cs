using System.ComponentModel.DataAnnotations;

public class UserRegisterDto{
    [Required(ErrorMessage = "Informe um nome")]
    public string name { get; set; }
    [Required(ErrorMessage = "Informe um email")]
    [EmailAddress(ErrorMessage = "Informe um email valido")]
    public string email { get; set; }
    [Required(ErrorMessage = "Informe uma senha")]
     [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$", ErrorMessage = "Informe uma senha valida")]
    public string password { get; set; }
}