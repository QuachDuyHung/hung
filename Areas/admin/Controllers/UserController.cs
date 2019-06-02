using BTL_NET2.Models;
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
        Model1 data = new Model1();
        private object dangnhap;

        public ActionResult Index()
        {
            var user = (from i in data.accounts select i).ToList();
            ViewBag.user = user;
            return View();
        }

        //comment từ trang chủ chuyển sang----------
        public ActionResult Comment(int id)
        {
            //hiển thị cmt theo id account
            var cmt = (from cm in data.feedbacks where cm.accountid == id orderby cm.id descending select cm).ToList();
            ViewBag.cmt = cmt;
            return View();
        }

        public ActionResult XoaCmt(int idcmt)
        {
            feedback fe = data.feedbacks.SingleOrDefault(n => n.id == idcmt);
            if(fe == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.feedbacks.Remove(fe);
            data.SaveChanges();
            
            return RedirectToAction("Hien_cmt");
        }
        //----------------------------------------------

        public ActionResult Hien_cmt()
        {
            var SumCmt = (from i in data.accounts select i).ToList();
            ViewBag.SumCmt = SumCmt;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string TK = collection.Get("txtEmail").ToString();
            string MK = collection.Get("txtMatKhau").ToString();
            account dangnhap = data.accounts.SingleOrDefault(n => n.email == TK && n.password == MK && n.role==1);
            if (dangnhap != null)
            {

                Session["TaiKhoan"] = dangnhap;                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Sai Email hoặc mật khẩu. Vui lòng thử lại!");
                return Redirect("Login");
            }
        }

        //thông tin đăng nhập
        public ActionResult Info()
        {
            return View();
        }

        //thông tin các tài khoản
        public ActionResult User_info(int id)
        {
            account us = data.accounts.SingleOrDefault(n => n.id == id);
            var tk = (from i in data.accounts where i.id == id select i).ToList();
            ViewBag.tk = tk;
            return View(us);
        }
    }
}