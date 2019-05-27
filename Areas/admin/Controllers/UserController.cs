using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class UserController : Controller
    {
        // GET: admin/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ChangePass()
        {
            return View();
        }

        public ActionResult RegisterPass()
        {
            return View();
        }

        public ActionResult ForgotPass()
        {
            return View();
        }

    }
}