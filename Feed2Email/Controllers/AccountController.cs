using System.Web.Mvc;

namespace Feed2Email.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
