using BTL_NET2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_NET2.Areas.admin.Controllers
{
    public class BillController : Controller
    {
        // GET: admin/Bill
        Model1 data = new Model1();
        public ActionResult Index()
        {
            var hoadon = (from i in data.bills select i).ToList();
            ViewBag.hoadon = hoadon;
            return View();
        }

        public ActionResult DS_Bill(int idBill)
        {            
            var bil = (from cm in data.billdetails where cm.billID == idBill select cm).ToList();
            var nameBill = from i in data.bills where i.id == idBill select i;

            ViewBag.bil = bil;
            ViewBag.nameBill = nameBill;

            return View();
        }

        public ActionResult Xoa_bill(int idBill)
        {
            bill bi = data.bills.SingleOrDefault(n => n.id == idBill);
            //billdetail bill = data.billdetails.SingleOrDefault(n => n.billID == idBill);
            if (bi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.bills.Remove(bi);
            //data.billdetails.Remove(bill);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Xoa_billdetail(int idBilldetail)
        {
            billdetail bi = data.billdetails.SingleOrDefault(n => n.id == idBilldetail);
            if (bi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.billdetails.Remove(bi);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}