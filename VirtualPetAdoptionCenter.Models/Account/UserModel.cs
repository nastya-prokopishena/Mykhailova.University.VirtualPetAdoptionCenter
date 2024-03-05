using System.ComponentModel.DataAnnotations;

namespace VirtualPetAdoptionCenter.Models.Account;

public class UserModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string AuthType { get; set; }

}