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
            var loai = (from i in data.categories select i).ToList();
            var loai1 = (from ca in data.categories
                         join pr in data.PRODUCTs on ca.id equals pr.catID
                         where ca.id == 1 select ca ).ToList();
            
            var prod = (from i in data.PRODUCTs select i).ToList();
            var bill = (from i in data.bills select i).ToList();
            var user = (from i in data.accounts select i).ToList();

            //comment
            var cmt = (from i in data.feedbacks orderby i.id descending select i).Take(10).ToList();
            //foreach(var im in cmt)
            //{
            //    ViewBag.id = im.id;
            //    //var cmt1 = (from i in data.feedbacks where i.accountid == im.id select i).Take(10).ToList();
               
            //}


            //hiển thị danh tổng số cmt theo user
            var SumCmt = (from i in data.accounts select i).ToList();

            ViewBag.loai = loai;
            ViewBag.dem = loai.Count();
            ViewBag.loai_1 = loai1.Count();
            ViewBag.demprod = prod.Count();
            ViewBag.dembill = bill.Count();
            ViewBag.demuser = user.Count();
            ViewBag.cmt = cmt;
           
            ViewBag.SumCmt = SumCmt;

            return View();
        }
    }
}