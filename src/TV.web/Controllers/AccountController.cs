using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TV.web.Filters;
using TV.web.Models;
using TV.web.ViewModels;
using System.Net.Mail;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;

namespace TV.web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        private readonly TVContext _ctx;

        public AccountController(TVContext ctx)
        {
            _ctx = ctx;
        }

        public bool SendPasswordToken(string userName)
        {
            try{
                var user = _ctx.UserProfiles.Where(m => m.UserName == userName).SingleOrDefault();
                var userEmail = user.Email;
            
                var resetToken = WebSecurity.GeneratePasswordResetToken(user.UserName, 1440);

                var hosturl =
                        System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                        "/Account/ChangePassword/?token=" + resetToken;

               //var confirmationLink = string.Format("<a href=\'{0}\'>Clink to confirm your registration</a>",
               //                                      hosturl);

                var bemail = new MailMessage("registration@tenantsvillage.com", userEmail.ToString(), "Password Reset Request",
                    "You have requested to have your password reset, or have forgot your password. Click the link below to reset your password."+ System.Environment.NewLine+   
                   hosturl );
                var smtpServer = new SmtpClient();
                smtpServer.Send(bemail);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        [AllowAnonymous]
        public ActionResult ChangePassword(string token)
        {
            
            var userId = WebSecurity.GetUserIdFromPasswordResetToken(token);
            
            if (userId > 0)
            {
                
                var outModel = new ChangePasswordViewModel{
                    UserId = userId,
                    Token = token
                };
                return View(outModel);
            }
            else
            {
                return View("Error");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel inModel)
        {
            if(inModel.Password != inModel.ConfirmPassword)
            {
                ModelState.AddModelError("", "The passwords do not match");
                return View(inModel);
            }

            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty");
                return View(inModel);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer");
                return View(inModel);
            }

            try
            {
                var user = _ctx.UserProfiles.Find(inModel.UserId);

                if (inModel.UserName == user.UserName)
                {

                    WebSecurity.ResetPassword(inModel.Token, inModel.Password);
                    WebSecurity.Login(inModel.UserName, inModel.Password, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ModelState.AddModelError("", "The user name does not match our records");
                    return View(inModel);
                }
            }
            catch
            {
                throw new Exception("Change Password forgery");
            }
        }
        
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }

            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty");
                return View(inModel);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer");
                return View(inModel);
            }

            if (_ctx.UserProfiles.Where(m => m.UserName == inModel.UserName && m.Email == inModel.Email).Any())
            {
                var emailSent = SendPasswordToken(inModel.UserName);

                if (emailSent)
                {
                    return View("ForgotPasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The was a problem sending a reset email, please try again later");
                    return View(inModel);
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name and email do not match");
                return View(inModel);
            }
            
            
        }

        //[SessionExpireFilter]
        public ActionResult ResetPassword()
        {
            
            return View("ForgotPassword");
        }

 
        [HttpPost]
        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ForgotPasswordViewModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inModel);
            }

            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(inModel);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
                return View(inModel);
            }

            if (_ctx.UserProfiles.Where(m => m.UserName == inModel.UserName && m.Email == inModel.Email).Any())
            {
                var emailSent = SendPasswordToken(inModel.UserName);

                if (emailSent)
                {
                    return View("ForgotPasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The was a problem sending a reset email, please try again.");
                    return View("ForgotPassword", inModel);
                }
            }
            else
            {
                ModelState.AddModelError("", "The UserNmae and Email do not match.");
                return View("ForgotPassword", inModel);
            }
            
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            try
            {
                var isVerified = _ctx.UserProfiles.Where(m => m.UserName == model.UserName).SingleOrDefault().isVerified;
                if (Membership.ValidateUser(model.UserName, model.Password) && isVerified == false)
                {
                    ModelState.AddModelError("", "Please verify your account by clicking the link in the registration email");
                    return View(model);
                }
                if (Membership.ValidateUser(model.UserName, model.Password) && isVerified == true)
                {
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToLocal(returnUrl);
                }

                else
                {
                    ModelState.AddModelError("", "The user name and password do not match");
                    return View(model);
                }

            }
            catch
            {
                ModelState.AddModelError("", "The user name and password do not match or an account does not exist");
                return View(model);
            }
        }

        
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {

            var checkUserEmail = _ctx.UserProfiles.Where(m => m.Email == model.Email).Any();
            var checkUserName = _ctx.UserProfiles.Where(m => m.UserName == model.UserName).Any();
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (checkUserName)
            {
                ModelState.AddModelError("", "The User Name is taken");
                return View(model);
            }

            if (checkUserEmail)
            {
                if(checkUserEmail && _ctx.UserProfiles.Where(m => m.Email == model.Email).SingleOrDefault().isVerified == false)
                {
                    ModelState.AddModelError("", "This email address is awaiting verification");
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "That email address is already taken");
                    return View(model);
                }
            }
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(model);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
                return View(model);
            }
            
            try
            {
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password);

                var registrationCode = WebSecurity.GeneratePasswordResetToken(model.UserName, 1440);
                var newUser = _ctx.UserProfiles.Where(m => m.UserName == model.UserName).SingleOrDefault();
                newUser.Email = model.Email;
                newUser.isVerified = false;
                newUser.RegistrationCode = registrationCode;
                _ctx.SaveChanges();
                try
                {

                    var hosturl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                        "/Account/VerifyEmailCode/?token=" + registrationCode;


                    var bemail = new MailMessage("registration@tenantsvillage.com", model.Email.ToString(), "Registration Verification",
                        "Thank you for registering with TenantsVillge. Click the link below to complete your registration." + System.Environment.NewLine +
                        hosturl);

                    var smtpServer = new SmtpClient();
                    smtpServer.Send(bemail);
                }
                catch
                {
                    throw new Exception("Register email failure");

                }
                
                return View("VerifyAccount");
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", e.StatusCode.ToString());
                return View(model);
            }    
        }

        [AllowAnonymous]
        public ActionResult VerifyEmailCode(string token)
        {
            var userId = WebSecurity.GetUserIdFromPasswordResetToken(token);
            var user = _ctx.UserProfiles.Find(userId);

            if (user.isVerified == true)
            {
                return View("Error");
            }
            if (userId > 0)
            {

                var outModel = new VerifyEmailCodeViewModel
                {
                    UserId = userId,
                    Token = token
                };
                return View(outModel);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult VerifyEmailCode(VerifyEmailCodeViewModel inModel)
        {
            try
            {
                var user = _ctx.UserProfiles.Find(inModel.UserId);
                if (user.isVerified == true)
                {
                    ModelState.AddModelError("", "This account has already been verified");
                    return View(inModel);
                }
                if (Membership.ValidateUser(inModel.UserName, inModel.Password) && user.isVerified == false)
                {
                    user.isVerified = true;
                    _ctx.SaveChanges();
                    WebSecurity.Login(inModel.UserName, inModel.Password);
                    return RedirectToAction("Index", "Home");
                 }
                else
                {
                    ModelState.AddModelError("", "The user name and password do not match");
                    return View(inModel);
                }

            }
            catch
            {
                ModelState.AddModelError("", "The user name and password do not match  the account does not exist");
                return View(inModel);
            }
        }



        //[SessionExpireFilter]
        public ActionResult Disassociate()
        {

            var userName = HttpContext.User.Identity.Name;

            var user = _ctx.UserProfiles.Where(m => m.UserName == userName).SingleOrDefault();

            var outModel = new DisassociateUserViewModel
            {
                UserId = user.UserId
            };
            return View(outModel);
        }

        [HttpPost]
        //[SessionExpireFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(DisassociateUserViewModel inModel)
        {
            var user = _ctx.UserProfiles.Where(m => m.UserId == inModel.UserId).Where(m => m.Email == inModel.Email).
                Where(m => m.UserName == inModel.UserName).SingleOrDefault();

            var checkUserName = HttpContext.User.Identity.Name;

            if (user.UserName != checkUserName)
            {
                ModelState.AddModelError("", "There is a problem deleting your account.  Please double check your entries.");
                return View(inModel);
            }

            Membership.DeleteUser(inModel.UserName);
            return View("DeleteAccountSuccess");
        }
        
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (TVContext db = new TVContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        public ActionResult UserProfile()
        {
            var user = _ctx.UserProfiles.Where(u => u.UserName == HttpContext.User.Identity.Name).SingleOrDefault();
            var outModel = new ShowProfileViewModel
            {
                UserName = user.UserName,
                UserId = user.UserId
            };

            return View(outModel);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        
        #endregion
    }
}
