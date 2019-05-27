using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Default
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var loai = data.categories.ToList();
            ViewBag.loai = loai;
            return View();
        }
    }
}