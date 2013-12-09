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
    public class JobController : Controller
    {
        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /Job/

        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Employer);
            return View(jobs.ToList());
        }

        //
        // GET: /Job/Details/5

        public ActionResult Details(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // GET: /Job/Create

        public ActionResult Create()
        {
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName");
            return View();
        }

        //
        // POST: /Job/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName", job.EmployerID);
            return View(job);
        }

        //
        // GET: /Job/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName", job.EmployerID);
            return View(job);
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName", job.EmployerID);
            return View(job);
        }

        //
        // GET: /Job/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Job/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       /* public ActionResult Manage()
        {
           var model = new Job
            {
                ApplicantList = new[]
                {
                    foreach( candidate in db.Applicants.All( s => s.FullName))
                    {
                        new Potential { PName = candidate }
                    }
                }.ToList()
            };

            //var model = db.Jobs.Include(db.Applicants);


            return View(model);
        }*/

        [HttpPost]
        public ActionResult Manage(FormCollection form)
        {
            ViewBag.YouSelected = form["Applicants"];

            string selectedValues = form["Applicants"];

            ViewBag.CandidateList = GetApplicants(selectedValues.Split(','));

            return View();

        }



        private MultiSelectList GetApplicants(string[] selectedValues){

          /*  Job MyJob = new Job();

            MyJob.ApplicantList = db.Applicants.OrderByDescending(x => x.LName).ToList();*/

            ViewBag.ApplicantList = db.Applicants.OrderBy(x => x.ID).ToList();

            return new MultiSelectList(ViewBag.ApplicantList, "ID", "LName", selectedValues);
        }

      


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}