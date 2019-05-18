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



namespace Lapbase_Application.Controllers
{
    public class AccountController : Controller
    {
        test t1 = new test();
        public ActionResult Login()
        {

            //bool b1 =
            t1.b = AuthenticateUser("test", "Dhru");
            return View(t1);


        }
        //#region public bool AuthenticateUser(string username, string password)
        public bool AuthenticateUser(string username, string password)
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

                PrincipalContext context = new PrincipalContext(ContextType.Domain, domainName);

                UserPrincipal p = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "test2");

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


            }

            catch (Exception ex)

            {

                // throw ex;
                t1.message = "" + ex.Message;

            }

            return authentic;

        }

    }
}
