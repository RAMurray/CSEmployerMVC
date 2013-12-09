using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSEmployerMVC.Models;
using CSEmployerMVC.Classes;
using System.Text;
using System.IO;

namespace CSEmployerMVC.Controllers
{
    public class ResumeController : Controller
    {
        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /Resume/

        public ActionResult Index()
        {
            var resumes = db.Resumes.Include(r => r.Applicant);
            return View(resumes.ToList());
        }

        //
        // GET: /Resume/Details/5

        public ActionResult Details(int id = 0)
        {
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        //
        // GET: /Resume/Create

        public ActionResult Create()
        {
            //GenerateFile();
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FName");
            return View();
        }

        //
        // POST: /Resume/Create

        [HttpPost]
        public ActionResult Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Resumes.Add(resume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FName", resume.ApplicantID);
            return View(resume);
        }

        //
        // GET: /Resume/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FName", resume.ApplicantID);
            return View(resume);
        }

        //
        // POST: /Resume/Edit/5

        [HttpPost]
        public ActionResult Edit(Resume resume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FName", resume.ApplicantID);
            return View(resume);
        }

        //
        // GET: /Resume/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        //
        // POST: /Resume/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Resume resume = db.Resumes.Find(id);
            db.Resumes.Remove(resume);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


      /*  public FileStreamResult GenerateFile(int apID = 0, string resContent = null)
        {
           

            var ResQry = from ap in db.Resumes
                         where ap.ApplicantID == apID
                         select ap.Content;
           

            //todo: add some data from your database into that string:


            var byteArray = Encoding.ASCII.GetBytes(resContent);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", "your_file_name.txt"); 
        }*/


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}