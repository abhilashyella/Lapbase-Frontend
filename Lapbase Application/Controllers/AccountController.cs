using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using Lapbase_Application.Models;
using System.Net.Mail;
using System.Net;




namespace Lapbase_Application.Controllers
{
    public class AccountController : Controller
    {
        test t1 = new test();
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();    
            
        }
        public ActionResult Login1()
        {
            return View();
        }
        public ActionResult Resetpassword()
        {
            return View();
        }
        public ActionResult resetSuccess()
        {
            return View();
        }
        public ActionResult BackToLogin()
        {
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AuthenticateUser(String username, String password)
        {
           
            string domainName = System.Configuration.ConfigurationManager.AppSettings["Domain Name"];
            string domainAndUsername = string.Format(@"{0}\{1}", domainName, username);
            string ldapPath = string.Format("LDAP://" + domainName);
            Boolean userMustChangePassword = false;
            Boolean userAccountIsExpired = false;
            bool authentic = false;
            
            try

            {
                DirectoryEntry entry = new DirectoryEntry(ldapPath, username, password);

                PrincipalContext context = new PrincipalContext(ContextType.Domain, domainName, "abhilash.y", "Lat@tm123");

                UserPrincipal p = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
                Session["username"] = username;
                if (p.AccountExpirationDate.HasValue)
                {
                    if (p.AccountExpirationDate < DateTime.Now)

                        userAccountIsExpired = true;

                }

                if (!p.LastPasswordSet.HasValue)
                {

                    if (!p.PasswordNeverExpires)

                        userMustChangePassword = true;
                }

                if (!userMustChangePassword & !userAccountIsExpired)
                {
                    object obj = entry.NativeObject;


                    authentic = true;

                }
                else
                {

                    authentic = false;

                }

                if (authentic)
                {
                    return RedirectToAction("Dashboard", "Account");
                }
                else
                {
                    Response.Write("<script> alert('Invalid password')</script>");
                }
            }
            catch (Exception ex)
            {
  
                return RedirectToAction("Login1", "Account");

            }
            return View(t1);
        }

    


    public ActionResult ResetPass(string username)
    {
        // if (ModelState.IsValid)
        {

            // if (WebSecurity.UserExists(UserEmail))
            //  {
            string To = username;

            //HTML Template for Send email  

            string subject = "Lapbase Account Reset Password";
            string body = "Please find the Password Reset Link below:";
            //Call send email methods.  
            EmailManager.SendEmail(subject, body, To);
            return RedirectToAction("resetSuccess", "Account");
            }

    }
    //  return View();




    public class EmailManager
    {

        public static void SendEmail(string Subject, string Body, string To)
        {
            string EmailID = System.Configuration.ConfigurationManager.AppSettings["EmailID"];
            string EmailPass = System.Configuration.ConfigurationManager.AppSettings["EmailPass"];
            string SMTPPort = System.Configuration.ConfigurationManager.AppSettings["SMTPPort"];
            string Host = System.Configuration.ConfigurationManager.AppSettings["Host"];
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(EmailID);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(EmailID, EmailPass);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            
            }
    }

}

}

