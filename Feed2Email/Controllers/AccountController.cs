using System.Web.Mvc;
using System.Web.Security;
using Feed2Email.Models.Account;

namespace Feed2Email.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            return View(new LoginViewModel());
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginEditModel model)
        {
            if (Request.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            var username = model.Username;

            if (!ModelState.IsValid || !Membership.ValidateUser(username, model.Password))
                return View(new LoginViewModel {Username = username});

            FormsAuthentication.SetAuthCookie(username, model.RememberMe);

            // The parameter "createPersistentCookie" is documented as "ignored."
            return Redirect(FormsAuthentication.GetRedirectUrl(username, false));
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
