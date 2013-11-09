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
    public class ApplicantController : Controller
    {
        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /Applicant/

        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        //
        // GET: /Applicant/Details/5

        public ActionResult Details(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // GET: /Applicant/Create

        public ActionResult Create()
        {
            List<string> listOfDegrees = new List<string>() { "G.E.D", "Certificate", "Bachelor's", "Master's", "P.H.D" };

            ViewBag.ListofDegrees = listOfDegrees;
            return View();
        }

        //
        // POST: /Applicant/Create

        [HttpPost]
        public ActionResult Create(Applicant applicant, string knownLangauges)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        //
        // GET: /Applicant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // POST: /Applicant/Edit/5

        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        //
        // GET: /Applicant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        //
        // POST: /Applicant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Search
        public ActionResult Search(string searchString)
        {
            /*
            var DegreeLst = new List<string>();

            var DegreeQry = from d in db.Applicants
                            orderby d.Degree
                            select d.Degree;*/

            //DegreeLst.AddRange(DQ.Distinct());

           // ViewBag.appDegree = new SelectList(DegreeLst);

            var applicants = from m in db.Applicants
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                applicants = applicants.Where(s => s.KnownPL1.Contains(searchString) || s.KnownPL2.Contains(searchString) || s.KnownPL3.Contains(searchString) || s.KnownPL4.Contains(searchString) ||  s.KnownPL5.Contains(searchString));
            }


            /*if (appDegree.Equals(0))
                return View(applicants.Where(x => x.Degree.Equals(appDegree)));
            else
            {
                return View(applicants.Where(x => x.Degree.Equals(appDegree)));
            } */
       
            return View(applicants);

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
