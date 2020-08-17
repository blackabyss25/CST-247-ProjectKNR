using Login_Registration.Services.Business;
using Login_Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Registration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            //Call the Security Business Service create and findUserByEmail method from the Register() method
            SecurityService securityService = new SecurityService();

            // If satetement check for data validation
            if (ModelState.IsValid)
            {
                // the results of findByUserByEmail method call is saved in local method exist
                Boolean exist = securityService.FindByUser(register);
                if (!exist)
                {
                    // the results of create method call is saved in local method sucess
                    Boolean success = securityService.Create(register);

                    if (success)
                    {
                        //if the success variable returns true, navigate to RegisterSuccess View
                        return View("RegisterSuccess");
                    }
                    else
                    {
                        //if the success variable returns true, navigate to RegisterFailed View
                        return View("RegisterFailed");
                    }
                }
                else
                {
                    //if the exist variable returns true, navigate to RegisterExisted View
                    return View("RegisterExisted");
                }
            }
            return View("Register");
        }
    }
}