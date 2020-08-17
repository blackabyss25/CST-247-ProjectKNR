using Login_Registration.Models;
using Login_Registration.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Login_Registration.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View ("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {

            //Call the Security Business Service authenticate method from the Login() method

            SecurityService securityService = new SecurityService();

            // If satetement check for data validation
            if (ModelState.IsValid)
            {
                // the results of the method call is saved in local method sucess
                Boolean success = securityService.authenticate(user);

                if (success)
                {
                    //if the success variable returns true, navigate to LoginSuccess View
                    return View("LoginSuccess", user);

                }
                else
                {
                    //if the success variable returns false, navigate to LoginFailed View
                    return View("LoginFailed");
                }
            }
            else
            {
                return View("Login");
            }

        }
    }
}