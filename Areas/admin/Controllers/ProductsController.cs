using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: admin/Products
        public ActionResult Index()
        {
            return View();
        }

    }
}