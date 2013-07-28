using System;
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
            // Action is redundant if we're already authenticated
            if (Request.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            return View(new LoginViewModel());
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginEditModel model)
        {
            // Action is redundant if we're already authenticated
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

        [AllowAnonymous]
        public ActionResult Register()
        {
            // Action is redundant if we're already authenticated
            if (Request.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            return View(new RegisterFormModel());
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterFormModel model)
        {
            // Action is redundant if we're already authenticated
            if (Request.IsAuthenticated)
                return Redirect(FormsAuthentication.DefaultUrl);

            if (!ModelState.IsValid)
                return View(new RegisterFormModel {Username = model.Username, Email = model.Email});

            // Create user

            // Authenticate user

            // Redirect to default
            throw new NotImplementedException();
        }
    }
}
