using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: admin/Category
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var theloai = data.categories.ToList();
            var loai = (from i in data.categories select i).ToList();
            ViewBag.loai = loai;
            return View();
        }

        public ActionResult DS_theloai(int idTheLoai)
        {
            var tl = (from cm in data.PRODUCTs where cm.catID == idTheLoai orderby cm.id descending select cm).ToList();
            var nameTL = from i in data.categories where i.id == idTheLoai select i;

            ViewBag.tl = tl;
            ViewBag.name = nameTL;
            return View();
        }

        [HttpGet]
        public ActionResult Them_TheLoai()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them_TheLoai(category theloai)
        {
            data.categories.Add(theloai);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Sua_sanpham(int id)
        {
            var sua = data.PRODUCTs.First(n => n.id == id);
            return View(sua);
        }

        [HttpPost]
        public ActionResult Sua_sanpham(int id, FormCollection collection)
        {
            var sua = data.PRODUCTs.First(n => n.id == id);
            string sTen = collection["name"];
            string sNguoinhap = collection["author"];
            int sGia = int.Parse(collection["price"]);
            byte sGiamgia = Byte.Parse(collection["discount"]);
            string sHang = collection["producer.name"];
            string sLoai = collection["category.name"];
            string sMota = collection["description"];
            byte sStatus = Byte.Parse(collection["status"]);

            sua.id = id;
            sua.name = sTen;
            sua.author = sNguoinhap;
            sua.price = sGia;
            sua.discount = sGiamgia;
            sua.producer.name = sHang;
            sua.category.name = sLoai;
            sua.description = sMota;
            sua.status = sStatus;
            sua.created_at = DateTime.Today;

            UpdateModel(sua);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Xoa_theloai(int idTheLoai)
        {
            category cate = data.categories.SingleOrDefault(n => n.id == idTheLoai);
            if(cate == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.categories.Remove(cate);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Xoa_sanpham(int idSP)
        {
            PRODUCT pro = data.PRODUCTs.SingleOrDefault(n => n.id == idSP);
            if (pro == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCTs.Remove(pro);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}