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
<<<<<<< HEAD
<<<<<<< HEAD
        public ActionResult Search(string searchString, string CLName, string Password)
        {
            var applicants = db.Applicants.Include( a => a.Jobs);

            ViewBag.ConcurrencyErrorMessage = "Test, please ignore.";
=======
        public ActionResult Search(string searchString)
        {
=======
        public ActionResult Search(string searchString)
        {
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
            var applicants = from m in db.Applicants
                             select m;
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2

            if (!String.IsNullOrEmpty(searchString))
            {
                applicants = applicants.Where(s => s.KnownPL1.Contains(searchString) || s.KnownPL2.Contains(searchString) || s.KnownPL3.Contains(searchString) || s.KnownPL4.Contains(searchString) || s.KnownPL5.Contains(searchString));
<<<<<<< HEAD
<<<<<<< HEAD

=======
               
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
=======
               
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
                switch (searchString)
                {
                    case "GED":
                        applicants = from a in db.Applicants
<<<<<<< HEAD
<<<<<<< HEAD
                                     where a.Degree == Degrees.GED
                                     select a;
=======
                                where a.Degree == Degrees.GED
                                select a;
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
=======
                                where a.Degree == Degrees.GED
                                select a;
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
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
<<<<<<< HEAD
<<<<<<< HEAD

             /*if (!String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(CLName))
             {
                addToCandidates(Password, CLName);
             }*/


=======
       
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
=======
       
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
            return View(applicants);

        }

<<<<<<< HEAD
<<<<<<< HEAD
      /*  private void addToCandidates(string Password = null, string CLName = null)
        {
            Applicant candidate = db.Applicants.Find(CLName);
            Employer epassword = db.Employers.Find(Password);

            var job = from j in db.Jobs
                      select j;

            List<Applicant> CandidateList = new List<Applicant>();

            if (candidate == null || epassword == null)
            {
                ViewBag.ConcurrencyErrorMessage = "Invalid entry. Either Password is incorrect or that Applicant doesn't exists.";
            }
            else
            {
                var CList = db.Jobs.Where(x => x.Employer.ePassword == Password).Select(x => x.CandidatesList);

                C

            }
        }*/

=======
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
=======
>>>>>>> c8e83b6cf0a323f064d598f6ad7414f46e46e9b2
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
