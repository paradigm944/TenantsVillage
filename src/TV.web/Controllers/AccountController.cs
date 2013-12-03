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
        
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(ForgotPasswordViewModel inModel)
        {
            if (_ctx.UserProfiles.Where(m => m.UserName == inModel.UserName).Any())
            {
                var user = _ctx.UserProfiles.Where(m => m.UserName == inModel.UserName).SingleOrDefault();
                var checkEmail = user.Email;
                if (checkEmail == inModel.Email)
                {
                    var resetToken = WebSecurity.GeneratePasswordResetToken(inModel.UserName, 1440);

                    var bemail = new MailMessage("registration@tenantsvillage.com", inModel.Email.ToString(), "Password Reset Request",
                        "You have requested to have your password reset. This is your reset code:   " + resetToken + "  Copy it and return to tenantsvillage and use this code to reset your password.");
                    var smtpServer = new SmtpClient();
                    smtpServer.Send(bemail);
                    return View("ForgotPasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The UserNmae and Email do not match.");
                    return View(inModel);
                }
            }
            else
            {
                ModelState.AddModelError("", "There is a problem with the entered UserName");
                return View(inModel);
            }
  
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel inModel)
        {
            var userId = WebSecurity.GetUserIdFromPasswordResetToken(inModel.ResetToken);
            if (userId > 0)
            {
                var user = _ctx.UserProfiles.Where(m => m.UserId == userId).SingleOrDefault();
                WebSecurity.ResetPassword(inModel.ResetToken, inModel.Password);
                return View("ResetPasswordSuccess");
            }
            else
            {
                ModelState.AddModelError("", "There is a problem with the reset code.  Please check your entry...");
                return View(inModel);
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
            if (Membership.ValidateUser(model.UserName, model.Password))
            {
                var isVerified = _ctx.UserProfiles.Where(m => m.UserName == model.UserName).SingleOrDefault().isVerified;

                if ( isVerified == true)
                {
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToLocal(returnUrl);
                }
                if (isVerified == false || isVerified == null)
                {
                    ModelState.AddModelError("", "This account has not been verified.");
                }
            }
            else
            {

                ModelState.AddModelError("", "The user name or password provided is incorrect.");

            }
                
                
            
            return View(model);
        }

        //
        // POST: /Account/LogOff

        
        
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }


       
        public ActionResult ChangePassword()
        {

            var outModel = new LocalPasswordModel();
            return View(outModel);
        }


        [HttpPost]
        public ActionResult ChangePassword(LocalPasswordModel inModel)
        {
            var user = _ctx.UserProfiles.Where(m => m.UserName == User.Identity.Name).SingleOrDefault();

            if (!Membership.ValidateUser(User.Identity.Name, inModel.OldPassword))
            {
                ModelState.AddModelError("", "The current password is not correct.");
                return View(inModel);

            }
            else
            {
                try
                {
                    
                    WebSecurity.ChangePassword(user.UserName, inModel.OldPassword, inModel.NewPassword);
                    WebSecurity.Logout();
                    var bemail = new MailMessage("registration@tenantsvillage.com", user.Email.ToString(), "Registration Verification",
                        "The password for your account at tenantsvillage.com has been changed.  If you did not authorize this change please contact us immediately. ");
                    var smtpServer = new SmtpClient();
                    smtpServer.Send(bemail);
                    return View("Login");
                }
                catch
                {
                    ModelState.AddModelError("", "The current password is not correct.");
                    return View(inModel);
                }
            }
            
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_ctx.UserProfiles.Where(m => m.Email == model.Email).Where(m => m.isVerified == true).Any())
                {
                    ModelState.AddModelError("", "That Email is already taken.");
                    return View(model);
                }
                try
                {
                    //WebSecurity.Login(model.UserName, model.Password);

                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    var registrationCode = WebSecurity.GeneratePasswordResetToken(model.UserName, 1440);
                    var newUser = _ctx.UserProfiles.Where(m => m.UserName == model.UserName).SingleOrDefault();
                    newUser.Email = model.Email;
                    newUser.isVerified = false;
                    newUser.RegistrationCode = registrationCode;
                    var bemail = new MailMessage("registration@tenantsvillage.com", model.Email.ToString(), "Registration Verification", 
                        "Thank you for registering with TenantsVillge.  This is your verification code.  " + registrationCode + "  Copy it and go to the Verify-New-Account link on our homepage.  "  );

                    var smtpServer = new SmtpClient();
        
                    smtpServer.Send(bemail);
                    _ctx.SaveChanges();  
                    return View("VerifyAccount");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult VerifyEmailCode()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult VerifyEmailCode(VerifyEmailCodeViewModel inModel)
        {   
            var code = inModel.Code;

            var userId = WebSecurity.GetUserIdFromPasswordResetToken(code);

            if (WebSecurity.GetUserId(inModel.UserName) != userId)
            {
                ModelState.AddModelError("", "This is not the correct code for the user name provided");
                return View(inModel);
            }

            if (userId > 0)
            {

                var user = _ctx.UserProfiles.Where(m => m.UserId == userId).SingleOrDefault();
                user.isVerified = true;
                _ctx.SaveChanges();
                return View("VerifySuccessLogin");
            }


            return View("VerifyEmailCodeError");

            
        }




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
        //
        // POST: /Account/Disassociate

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Disassociate(string provider, string providerUserId)
        //{
        //    string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
        //    ManageMessageId? message = null;

        //    // Only disassociate the account if the currently logged in user is the owner
        //    if (ownerAccount == User.Identity.Name)
        //    {
        //        // Use a transaction to prevent the user from deleting their last login credential
        //        using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
        //        {
        //            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
        //            if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
        //            {
        //                OAuthWebSecurity.DeleteAccount(provider, providerUserId);
        //                scope.Complete();
        //                message = ManageMessageId.RemoveLoginSuccess;
        //            }
        //        }
        //    }

        //    return RedirectToAction("Manage", new { Message = message });
        //}

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
           

            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
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
