using System.ComponentModel.DataAnnotations;
using Feed2Email.Attributes;

namespace Feed2Email.Models.Account
{
    public class RegisterFormModel
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        [Display(Description = "Your feeds' items will be delivered here.")]
        public string Email { get; set; }

        [ComplexPassword, DataType(DataType.Password), Required]
        [Display(Description = "At least eight characters with one lower case letter, one upper case letter. Add a number for good measure.")]
        public string Password { get; set; }

        [Compare("Password"), DataType(DataType.Password), Required]
        [Display(Description = "Be like Santa, checkin' it twice; gotta find out who typed it wrong.")]
        public string ConfirmPassword { get; set; }
    }
}