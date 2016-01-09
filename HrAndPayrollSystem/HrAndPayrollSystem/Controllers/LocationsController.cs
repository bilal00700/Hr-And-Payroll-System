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
    public class LocationsController : Controller
    {
        private HrAndPayroll db = new HrAndPayroll();
    
        public ActionResult Index()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            Session["LcCreate"] = (context.Session["LcCreate"]);
            Session["LcEdit"]   = (context.Session["LcEdit"]);
            Session["LcDetail"] = (context.Session["LcDetail"]);
            Session["LcDelete"] = (context.Session["LcDelete"]);
         
            return View(db.Locations.Where(x => x.SystemCode == SysCode).ToList());   
        }

       
        public ActionResult Details(string SystemCode, string Code)
        {
            
            Location location = db.Locations.Find(SystemCode, Code);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        
        public ActionResult Create()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string SysCode = (string)(context.Session["syscode"]);

            var code = (from c in db.Locations where c.SystemCode.Contains(SysCode) select c)
                        .OrderByDescending(b => b.Code)
                        .Select(a => a.Code)
                        .FirstOrDefault();

            int LocCode = Convert.ToInt32(code);
            LocCode++;
            string Lccode = LocCode.ToString().PadLeft(4, '0');
            TempData["syscode"] = SysCode;
            TempData["code"] = Lccode;

            ViewBag.PvCode = new SelectList(db.Prvnces, "ProvinceTitle", "ProvinceTitle");

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SystemCode,Code,Title,PvCode")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

       
        public ActionResult Edit(string SystemCode, string Code)
        {

            Location location = db.Locations.Find(SystemCode, Code);
            if (location == null)
            {
                return HttpNotFound();
            }

            string prv = (from c in db.Locations where c.SystemCode.Contains(SystemCode) && c.Code.Contains(Code) select c)
                        .Select(a => a.PvCode)
                        .Single().ToString();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Prvnces p in db.Prvnces)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = p.ProvinceTitle.ToString(),
                    Value = p.ProvinceTitle.ToString(),
                    Selected = p.ProvinceTitle == prv,
                };

                selectListItems.Add(selectListItem);
            }

            ViewBag.PvCode = selectListItems;


            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SystemCode,Code,Title,PvCode")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

       
        public ActionResult Delete(string SystemCode, string Code)
        {
            
            Location location = db.Locations.Find(SystemCode,Code);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string SystemCode, string Code)
        {
            Location location = db.Locations.Find(SystemCode,Code);
            db.Locations.Remove(location);
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
