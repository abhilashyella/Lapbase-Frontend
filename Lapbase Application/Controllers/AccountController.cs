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
    public class HomeController : Controller
    {
        public  ActionResult Index()
        {


            //#region public bool AuthenticateUser(string username, string password)
            //public bool AuthenticateUser(string username, string password)
            //{
            string domainName = System.Configuration.ConfigurationManager.AppSettings["Domain Name"];
            string username = System.Configuration.ConfigurationManager.AppSettings["User ID"];
            string password = System.Configuration.ConfigurationManager.AppSettings["User Password"];
            string domainAndUsername = string.Format(@"{0}\{1}", domainName, username);
            string ldapPath = string.Format("LDAP://" + domainName);
            test t1 = new test();

           Boolean userMustChangePassword = false;

           Boolean userAccountIsExpired = false;


            try

            {


                DirectoryEntry entry = new DirectoryEntry(ldapPath, username, password);

                PrincipalContext context = new PrincipalContext(ContextType.Domain,domainName,username,password);

                UserPrincipal p = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName,"test2");

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

                if(!userMustChangePassword & !userAccountIsExpired)
                {
                    object obj = entry.NativeObject;

                    t1.s = "valid";

                }
                else
                {
                    t1.s = "invalid";
                }


            }

                    catch (Exception ex)

                    {

               // throw ex;
                t1.s = ""+ex.Message;
                   
                    }

            return View(t1);

                }

                

            }
    }
