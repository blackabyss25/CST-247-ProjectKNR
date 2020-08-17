using Login_Registration.Models;
using Login_Registration.Services.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Login_Registration.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool FindByUser(RegisterModel register)
        {
            return daoService.FindBUser(register);
        }

        public bool Create(RegisterModel register)
        {
            return daoService.Create(register);
        }

        public bool authenticate(UserModel user)
        {
            return daoService.authenticate(user);
        }
    }
}