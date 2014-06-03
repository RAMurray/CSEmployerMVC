using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSEmployerMVC.Models;
using CSEmployerMVC.Classes;
using RazorPDF;
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
            UpdateImportStatus();
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
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FullName");
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

        public ActionResult Pdf(int id = 0)
        {
            Resume applicant = db.Resumes.FirstOrDefault(r => r.ApplicantID == id);
            if (applicant != null)
            {
                var pdfresult = new PdfResult(applicant, "Pdf");

                pdfresult.ViewBag.Title = "Resume";

                return pdfresult;
               
            }
            else
            {
                return null;
            }

        }

        //This method checks any of the fields of the Resume are blank or not. If any of the fields have content in it the Imported bool is set to true.
        protected void UpdateImportStatus()
        {
            foreach (var entry in db.Resumes)
            {
                //If either of the three fields are NOT empty set Imported bool is set to true.
                if (!String.IsNullOrEmpty(entry.SchoolName) || !String.IsNullOrEmpty(entry.PreviousJobDuties) || !String.IsNullOrEmpty(entry.ContentSkills))
                {
                    entry.Imported = true;
                }
                else
                    entry.Imported = false;
            }
        }

        /* [HttpPost] 
         public ActionResult Upload(HttpPostedFileBase file) 
         { 
             try 
             { 
                 if (file.ContentLength > 0) 
                 { 
                     var fileName = Path.GetFileName(file.FileName); 
                     var path = Path.Combine(Server.MapPath("~/App_Data/ResumeFiles"), fileName); 
                     file.SaveAs(path); 
                 } 
                 ViewBag.Message = "Upload successful"; 
                 return RedirectToAction("Index"); 
             } 
             catch 
             { 
                 ViewBag.Message = "Upload failed"; 
                 return RedirectToAction("Uploads"); 
             } 
         }  -Full code at: http://rachelappel.com/upload-and-download-files-using-asp.net-mvc */


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}