using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSEmployerMVC.Models;
using CSEmployerMVC.Classes;
using System.IO;

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
            //List<string> listOfDegrees = new List<string>() { "G.E.D", "Certificate", "Bachelor's", "Master's", "P.H.D" };

            //ViewBag.ListofDegrees = listOfDegrees;
            ViewBag.KnownPL1 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName");
            ViewBag.KnownPL2 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName");
            ViewBag.KnownPL3 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName");
            ViewBag.KnownPL4 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName");
            ViewBag.KnownPL5 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName");
            return View();
        }

        //
        // POST: /Applicant/Create

        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index", applicant.ID);
            }
            ViewBag.KnownPL1 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL1);
            ViewBag.KnownPL2 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL2);
            ViewBag.KnownPL3 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL3);
            ViewBag.KnownPL4 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL4);
            ViewBag.KnownPL5 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL5);

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
            ViewBag.KnownPL1 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL1);
            ViewBag.KnownPL2 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL2);
            ViewBag.KnownPL3 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL3);
            ViewBag.KnownPL4 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL4);
            ViewBag.KnownPL5 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL5);
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
            ViewBag.KnownPL1 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL1);
            ViewBag.KnownPL2 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL2);
            ViewBag.KnownPL3 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL3);
            ViewBag.KnownPL4 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL4);
            ViewBag.KnownPL5 = new SelectList(db.PGLanguages, "LanguageName", "LanguageName", applicant.KnownPL5);
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
            var applicants = db.Applicants.Include(a => a.Jobs);

            ViewBag.ConcurrencyErrorMessage = "Test, please ignore.";

            if (!String.IsNullOrEmpty(searchString))
            {
                applicants = applicants.Where(s => s.KnownPL1.Contains(searchString) || s.KnownPL2.Contains(searchString) || s.KnownPL3.Contains(searchString) || s.KnownPL4.Contains(searchString) || s.KnownPL5.Contains(searchString));

                switch (searchString)
                {
                    case "GED":
                        applicants = from a in db.Applicants
                                     where a.Degree == Degrees.GED
                                     select a;
                        break;
                    case "Certificate":
                        applicants = from a in db.Applicants
                                     where a.Degree == Degrees.Certificate
                                     select a;
                        break;
                    case "Bachelors":
                        applicants = from a in db.Applicants
                                     where a.Degree == Degrees.Bachelors
                                     select a;
                        break;
                    case "Masters":
                        applicants = from a in db.Applicants
                                     where a.Degree == Degrees.Masters
                                     select a;
                        break;
                    case "PHD":
                        applicants = from a in db.Applicants
                                     where a.Degree == Degrees.PHD
                                     select a;
                        break;
                }
            }

            /*if (!String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(CLName))
            {
               addToCandidates(Password, CLName);
            }*/


            return View(applicants);

        }

        // HttpPostedFileBase parameter name must be the lower case of the parameter used in the call from
        // the view
       /* public ActionResult Upload(int id = 0)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload([Bind(Exclude = "userfile")] Applicant applicant, HttpPostedFileBase userfile)
        {
            if (ModelState.IsValid)
            {
                if (userfile != null)
                {
                    applicant.FileMimeType = userfile.ContentType;
                    applicant.Resume = new byte[userfile.ContentLength];
                    userfile.InputStream.Read(applicant.Resume, 0, userfile.ContentLength);
                }

                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }*

        [HttpPost]
        public ActionResult Upload(Applicant applicant, HttpPostedFileBase userfile)
        {
          

            if (ModelState.IsValid)
            {
                using (var ms = new MemoryStream())
                {
                    userfile.InputStream.CopyTo(ms);
                    applicant.Resume = ms.ToArray();
                }

                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }



        public FileContentResult GetFile(int id)
        {
            Applicant applicant = db.Applicants.FirstOrDefault(a => a.ID == id);
            if (applicant != null)
            {
                return File(applicant.Resume, applicant.FileMimeType);
            }
            else
            {
                return null;
            }
        }*/

     
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
