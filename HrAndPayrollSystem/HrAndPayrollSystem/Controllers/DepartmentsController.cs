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
    public class DepartmentsController : Controller
    {

        private HrAndPayroll db = new HrAndPayroll();

        // GET: Departments
        public ActionResult Index()
        {
            HttpContext context = System.Web.HttpContext.Current;

            string SysCode = (string)(context.Session["syscode"]);
            Session["DpCreate"] = (context.Session["DpCreate"]);
            Session["DpEdit"]   = (context.Session["DpEdit"]);
            Session["DpDetail"] = (context.Session["DpDetail"]);
            Session["DpDelete"] = (context.Session["DpDelete"]);
               
            return View(db.Departments.Where(x => x.SystemCode == SysCode).ToList());     
        }

        // GET: Departments/Details/5
        public ActionResult Details(string SystemCode, string Code)
        {

            Department department = db.Departments.Find(SystemCode,Code);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            var code = (from c in db.Departments where c.SystemCode.Contains(SysCode) select c)
                        .OrderByDescending(c => c.Code)
                        .Select(c => c.Code)
                        .FirstOrDefault();

            int DeptCode = Convert.ToInt32(code);
            DeptCode++;
            string Dcode = DeptCode.ToString().PadLeft(4, '0');
            TempData["syscode"] = SysCode;
            TempData["code"] = Dcode;

            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SystemCode,Code,Title,GroupCode,GroupTitle,ContactPerson,Address,ContactNumber")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(string SystemCode, string Code)
        {

            Department department = db.Departments.Find(SystemCode,Code);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SystemCode,Code,Title,GroupCode,GroupTitle,ContactPerson,Address,ContactNumber")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(string SystemCode, string Code)
        {
       
            Department department = db.Departments.Find(SystemCode,Code);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string SystemCode, string Code)
        {
            Department department = db.Departments.Find(SystemCode,Code);
            db.Departments.Remove(department);
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
