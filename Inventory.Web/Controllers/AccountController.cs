using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inventory.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = UserModel.ValidateUser(login.User, login.Password);   
            
            if (user != null)
            {
                var ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(
                    1, user.Name, DateTime.Now, DateTime.Now.AddHours(12), login.RememberMe, user.Id + "|" + user.RescueStringNameRoles()));
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
                Response.Cookies.Add(cookie);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                   return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login.");
            }

            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home"); 
        }

        [AllowAnonymous]
        public ActionResult ChangeUserPassword(ChangeUserPasswordViewModel model)
        {
            ViewBag.Message = null;

            if (HttpContext.Request.HttpMethod.ToUpper() == "POST")
            {
                var userlogged = (HttpContext.User as MainApplication);
                var alter = false;
                if (userlogged != null)
                {
                    if(!userlogged.Data.ValidateCurrentPassword(model.CurrentPassword))
                    {
                        ModelState.AddModelError("CurrentPassword", "Current Password doesn't match");
                    }
                    else
                    {
                        alter = userlogged.Data.ChangePassword(model.NewPassword);

                        if (alter)
                        {
                            ViewBag.Message = new string[] { "ok", "Password Changed!" };
                        }
                        else
                        {
                            ViewBag.Message = new string[] { "error", "Failed to update password" };
                        }
                    }
                }

                return View();
            }
            else
            {
                ModelState.Clear();
                return View();
            }
           
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            ViewBag.EmailSent = true;
            if (HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                ViewBag.EmailSent = false;
                ModelState.Clear();
            }
            else
            {
                var users = UserModel.RescueLogin(model.Login);
                if (users != null)
                {
                    SendEmailResetPassword(users);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(int id)
        {
            var users = UserModel.IdRescue(id);
            if (users == null)
            {
                id = -1;
            }

            var model = new NewPasswordViewModel() { Users = id };

            ViewBag.Message = null;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(NewPasswordViewModel model)
        {
            ViewBag.Message = null;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var users = UserModel.IdRescue(model.Users);
            if (users != null)
            {
                var ok = users.ChangePassword(model.Password);
                ViewBag.Message = ok ? "Success, password changed!" : "Was not possible to change the password.";
            }

            return View();
        }

        private void SendEmailResetPassword(UserModel users)
        {
            var callbackUrl = Url.Action("ResetPassword", "Account", new { id = users.Id }, protocol: Request.Url.Scheme);
            var client = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["EmailHost"],
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"]),
                EnableSsl = (ConfigurationManager.AppSettings["EmailSsl"] == "S"),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["EmailUsers"],
                    ConfigurationManager.AppSettings["EmailPassword"])
            };
            var message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"], "Inventory - Home Service Solutions");
            message.To.Add(users.Email);
            message.Subject = "Reset your Password";
            message.Body = string.Format("Reset your password <a href= '{0}'> here</a>", callbackUrl);
            message.IsBodyHtml = true;
            
            client.Send(message);
        }
    }
}