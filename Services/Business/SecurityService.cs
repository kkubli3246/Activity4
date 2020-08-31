using Activity1part3.Models;
using Activity1part3.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace Activity1part3.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO security = new SecurityDAO();

            return security.FindByUser(user);
        }
    }
}