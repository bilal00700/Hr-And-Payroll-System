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
    public class DesignationsController : Controller
    {
        private HrAndPayroll db = new HrAndPayroll();

        // GET: Designations
        public ActionResult Index()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            Session["DgCreate"] = (context.Session["DgCreate"]);
            Session["DgEdit"]   = (context.Session["DgEdit"]);
            Session["DgDetail"] = (context.Session["DgDetail"]);
            Session["DgDelete"] = (context.Session["DgDelete"]);

            return View(db.Designations.Where(x => x.SystemCode == SysCode).ToList());     
        }

        // GET: Designations/Details/5
        public ActionResult Details(string SystemCode, string Code)
        {
            
            Designation designation = db.Designations.Find(SystemCode,Code);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {

            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            var code = (from c in db.Designations where c.SystemCode.Contains(SysCode) select c)
                        .OrderByDescending(b => b.Code)
                        .Select(a => a.Code)
                        .FirstOrDefault();

            int DesgCode = Convert.ToInt32(code);
            DesgCode++;
            string Dgcode = DesgCode.ToString().PadLeft(4, '0');
            TempData["syscode"] = SysCode;
            TempData["code"] = Dgcode;

            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SystemCode,Code,Title")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(string SystemCode, string Code)
        {
            Designation designation = db.Designations.Find(SystemCode,Code);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SystemCode,Code,Title")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(string SystemCode, string Code)
        {
            
            Designation designation = db.Designations.Find(SystemCode, Code);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string SystemCode, string Code)
        {
            Designation designation = db.Designations.Find(SystemCode, Code);
            db.Designations.Remove(designation);
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
