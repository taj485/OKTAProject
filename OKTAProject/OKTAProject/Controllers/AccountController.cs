using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Okta.AspNet;
using System.Web;
using System.Web.Mvc;

public class AccountController : Controller
{
    public ActionResult Login()
    {
        if (!HttpContext.User.Identity.IsAuthenticated)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                OktaDefaults.MvcAuthenticationType);
            return new HttpUnauthorizedResult();
        }

        return RedirectToAction("Index", "Home");
    }

    public ActionResult SignOut()
    {
        if (HttpContext.User.Identity.IsAuthenticated)
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                CookieAuthenticationDefaults.AuthenticationType,
                OktaDefaults.MvcAuthenticationType);
        }

        return RedirectToAction("Index", "Home");
    }

    public ActionResult PostSignOut()
    {
        // Return to the home page after sign out
        return RedirectToAction("Index", "Home");
    }
}