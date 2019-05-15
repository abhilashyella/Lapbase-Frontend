using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;

namespace Lapbase_Application.Controllers
{
    public class HomeController : Controller
    {
        public  ActionResult Index(String username, String password)
        {


            //#region public bool AuthenticateUser(string username, string password)
            //public bool AuthenticateUser(string username, string password)
            //{
            string domainName = System.Configuration.ConfigurationManager.AppSettings["Domain Name"];
            string domainAndUsername = string.Format(@"{0}\{1}", domainName, username);
            string ldapPath = string.Format("LDAP://" + domainName);
            bool authentic = false;
            //this.usermustchangepassword = false;
            //this.useraccountisexpired = false;
            //txttest.value = "";

            try

            {

                DirectoryEntry entry = new DirectoryEntry(ldapPath, domainAndUsername, password);

                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domainName))

                {

                    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);

                    //if (userPrincipal.AccountExpirationDate.HasValue)

                    //    if (userPrincipal.AccountExpirationDate < DateTime.Now)

                    //        this.userAccountIsExpired = true;

                    //if (!userPrincipal.LastPasswordSet.HasValue)

                    //    if (!userPrincipal.PasswordNeverExpires)

                    //        this.userMustChangePassword = true;

                }

                // now authenitcate the user

                object obj = entry.NativeObject;

                authentic = true;

            }

            catch (Exception ex)

            {

                throw ex;

            }


            return View(authentic);
            //#endregion

        }
    }
}