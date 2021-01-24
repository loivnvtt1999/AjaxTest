using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoAjaxSearch.Models;

namespace DemoAjaxSearch.Controllers
{
    public class CauThusController : Controller
    {
        private QuanLyDoiBongEntities db = new QuanLyDoiBongEntities();

        // GET: CauThus
        public ActionResult Index()
        {
            return View(db.CauThus.ToList());
        }
        public JsonResult GetSearchData(string SearchBy, string SearchValue)
        {
            List<CauThu> lstCauThu = new List<CauThu>();
            if(SearchBy== "maCT")
            {
                lstCauThu = db.CauThus.Where(x => x.macauthu == SearchValue).ToList();
                return Json(lstCauThu, JsonRequestBehavior.AllowGet);
            }
            else
            {
                lstCauThu = db.CauThus.Where(x => x.tencauthu.Contains(SearchValue) || SearchValue==null).ToList();
                return Json(lstCauThu, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: CauThus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauThu cauThu = db.CauThus.Find(id);
            if (cauThu == null)
            {
                return HttpNotFound();
            }
            return View(cauThu);
        }

        // GET: CauThus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CauThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "macauthu,tencauthu,email,sodt,madoibong")] CauThu cauThu)
        {
            if (ModelState.IsValid)
            {
                db.CauThus.Add(cauThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cauThu);
        }

        // GET: CauThus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauThu cauThu = db.CauThus.Find(id);
            if (cauThu == null)
            {
                return HttpNotFound();
            }
            return View(cauThu);
        }

        // POST: CauThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "macauthu,tencauthu,email,sodt,madoibong")] CauThu cauThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cauThu);
        }

        // GET: CauThus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauThu cauThu = db.CauThus.Find(id);
            if (cauThu == null)
            {
                return HttpNotFound();
            }
            return View(cauThu);
        }

        // POST: CauThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CauThu cauThu = db.CauThus.Find(id);
            db.CauThus.Remove(cauThu);
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
    // Pham Duc Loi
    //Huhuhu
<<<<<<< HEAD
    //Hello
=======
    //Hahhaha
>>>>>>> 10c7d7dd5cf4a9b6ffa3f48b7f84b6fb8eb2e89e
    
}
