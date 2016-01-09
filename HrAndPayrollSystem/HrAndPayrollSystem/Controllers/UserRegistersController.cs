using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HrAndPayrollSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace HrAndPayrollSystem.Controllers
{

    [Authorize]
    [LayoutInjecter("_PublicLayout")]
    public class UserRegistersController : Controller
    {
        private HrAndPayroll db = new HrAndPayroll();

        // GET: UserRegisters
        public ActionResult Index()
        {
            return View(db.UserRegisters.ToList());
        }

        // GET: UserRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegister userRegister = db.UserRegisters.Find(id);
            if (userRegister == null)
            {
                return HttpNotFound();
            }
            return View(userRegister);
        }

        // GET: UserRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,SystemCode,UserCategory,DpCreate,DpEdit,DpDetail,DpDelete,DgCreate,DgEdit,DgDetail,DgDelete,PmCreate,PmEdit,PmDetail,PmDelete,LcCreate,LcEdit,LcDetail,LcDelete")] UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                userRegister.Password = GetMD5(userRegister.Password);
                db.UserRegisters.Add(userRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRegister);
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        // GET: UserRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegister userRegister = db.UserRegisters.Find(id);
            if (userRegister == null)
            {
                return HttpNotFound();
            }
            return View(userRegister);
        }

        // POST: UserRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,SystemCode,UserCategory,DpCreate,DpEdit,DpDetail,DpDelete,DgCreate,DgEdit,DgDetail,DgDelete,PmCreate,PmEdit,PmDetail,PmDelete,LcCreate,LcEdit,LcDetail,LcDelete")] UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegister);
        }

        // GET: UserRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegister userRegister = db.UserRegisters.Find(id);
            if (userRegister == null)
            {
                return HttpNotFound();
            }
            return View(userRegister);
        }

        // POST: UserRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRegister userRegister = db.UserRegisters.Find(id);
            db.UserRegisters.Remove(userRegister);
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
