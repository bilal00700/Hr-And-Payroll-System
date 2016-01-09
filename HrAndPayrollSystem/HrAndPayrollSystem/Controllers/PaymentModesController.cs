using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HrAndPayrollSystem.Models;

namespace HrAndPayrollSystem.Controllers
{
    [Authorize]
    [LayoutInjecter("_PublicLayout")]
    public class PaymentModesController : Controller
    {
        private HrAndPayroll db = new HrAndPayroll();

        // GET: PaymentModes
        public ActionResult Index()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            Session["PmCreate"] = (context.Session["PmCreate"]);
            Session["PmEdit"]   = (context.Session["PmEdit"]);
            Session["PmDetail"] = (context.Session["PmDetail"]);
            Session["PmDelete"] = (context.Session["PmDelete"]);
            
            return View(db.PaymentModes.Where(x => x.SystemCode == SysCode).ToList());
        }

        // GET: PaymentModes/Details/5
        public ActionResult Details(string SystemCode, string Code)
        {
           
            PaymentMode paymentMode = db.PaymentModes.Find(SystemCode, Code);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // GET: PaymentModes/Create
        public ActionResult Create()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            var code = (from c in db.PaymentModes where c.SystemCode.Contains(SysCode) select c)
                        .OrderByDescending(c => c.Code)
                        .Select(c => c.Code)
                        .FirstOrDefault();

            int PmCode = Convert.ToInt32(code);
            PmCode++;
            string Pcode = PmCode.ToString().PadLeft(4, '0');
            TempData["syscode"] = SysCode;
            TempData["code"] = Pcode;

            return View();
        }

        // POST: PaymentModes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SystemCode,Code,Title")] PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                db.PaymentModes.Add(paymentMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentMode);
        }

        // GET: PaymentModes/Edit/5
        public ActionResult Edit(string SystemCode, string Code)
        {
            
            PaymentMode paymentMode = db.PaymentModes.Find(SystemCode, Code);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // POST: PaymentModes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SystemCode,Code,Title")] PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentMode);
        }

        // GET: PaymentModes/Delete/5
        public ActionResult Delete(string SystemCode, string Code)
        {
           
            PaymentMode paymentMode = db.PaymentModes.Find(SystemCode, Code);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // POST: PaymentModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string SystemCode, string Code)
        {
            PaymentMode paymentMode = db.PaymentModes.Find(SystemCode,Code);
            db.PaymentModes.Remove(paymentMode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
