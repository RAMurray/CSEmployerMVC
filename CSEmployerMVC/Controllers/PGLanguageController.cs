using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSEmployerMVC.Models;
using CSEmployerMVC.Classes;

namespace CSEmployerMVC.Controllers
{
    public class PGLanguageController : Controller
    {
        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /PGLanguage/

        public ActionResult Index()
        {
            return View(db.PGLanguages.ToList());
        }

        //
        // GET: /PGLanguage/Details/5

        public ActionResult Details(int id = 0)
        {
            PGLanguage pglanguage = db.PGLanguages.Find(id);
            if (pglanguage == null)
            {
                return HttpNotFound();
            }
            return View(pglanguage);
        }

        //
        // GET: /PGLanguage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PGLanguage/Create

        [HttpPost]
        public ActionResult Create(PGLanguage pglanguage)
        {
            if (ModelState.IsValid)
            {
                db.PGLanguages.Add(pglanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pglanguage);
        }

        //
        // GET: /PGLanguage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PGLanguage pglanguage = db.PGLanguages.Find(id);
            if (pglanguage == null)
            {
                return HttpNotFound();
            }
            return View(pglanguage);
        }

        //
        // POST: /PGLanguage/Edit/5

        [HttpPost]
        public ActionResult Edit(PGLanguage pglanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pglanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pglanguage);
        }

        //
        // GET: /PGLanguage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PGLanguage pglanguage = db.PGLanguages.Find(id);
            if (pglanguage == null)
            {
                return HttpNotFound();
            }
            return View(pglanguage);
        }

        //
        // POST: /PGLanguage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PGLanguage pglanguage = db.PGLanguages.Find(id);
            db.PGLanguages.Remove(pglanguage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}