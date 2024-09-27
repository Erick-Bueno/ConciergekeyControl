using System.ComponentModel.DataAnnotations;

public class RoomRegisterDto{
    [Required(ErrorMessage = "Informe um nome")]
    public string Name { get; set; }
}