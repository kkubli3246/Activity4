using Activity1part3.Models;
using Activity1part3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using System.Web.Script.Serialization;


namespace Activity1part3.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRules");

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user) 
        {
            logger.Info("Entering LoginController.Login()");

            //Validate the Form POST
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            SecurityService service = new SecurityService();
            logger.Info("Parameters are:" + new JavaScriptSerializer().Serialize(user));

            bool check = service.Authenticate(user);

            if (check)
            {
                logger.Info("Exiting LoginController.Login() Login Passed");
                return View("LoginPassed");
            }
            else
            {
                logger.Info("Exiting LoginController.Login() Login Failed");
                return View("LoginFailed");
            }
        }
    }
}