using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Feed2Email.Attributes;

namespace Feed2Email.Models.Account
{
    public class RegisterFormModel
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [ComplexPassword, DataType(DataType.Password), Required]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}