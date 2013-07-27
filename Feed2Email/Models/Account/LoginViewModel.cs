using System.ComponentModel;

namespace Feed2Email.Models.Account
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}