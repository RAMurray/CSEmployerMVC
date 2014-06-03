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
    public class EmployerController : Controller
    {
        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /Employer/

        
        public ActionResult Index()
        {
            return View(db.Employers.ToList());
        }

        //
        // GET: /Employer/Details/5
        public ActionResult Details(int id = 0)
        {
            Employer employer = db.Employers.Find(id);
            
           /* var jobs = db.Jobs.Where(x => x.EmployerID == id)
                .Include(j => j.JobTitle)
                .Include(j => j.Location)
                .Include(j => j.Recruiter);*/

      
            
            if (employer == null)
            {
                return HttpNotFound();
            }

            return View(employer);
        }

        //
        // GET: /Employer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employer/Create

        [HttpPost]
        public ActionResult Create(Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Employers.Add(employer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
       

            return View(employer);
        }

        //
        // GET: /Employer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //
        // POST: /Employer/Edit/5

        [HttpPost]
        public ActionResult Edit(Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        //
        // GET: /Employer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employer employer = db.Employers.Find(id);

            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //
        // POST: /Employer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer = db.Employers.Find(id);
            db.Employers.Remove(employer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*
        public ActionResult SignIn()
        {
            return View();
        }
         * 
         * 
        [HttpPost]
        public ActionResult SignIn(string input)
        {
            var password = from e in db.Employers
                      select e.ePassword;

            if (password.Equals(input))
            {
                var edi = from e in db.Employers
                          where e.ePassword == input
                          select e.ID;
                            
                Session["myApp-Authentication"] = "123";
                return RedirectToAction("Details", new { id = edi });
            }
            return View();
        }*/

        public ActionResult Login(Employer employer)
        {
            return View(employer);
        }


        [HttpPost]
        public ActionResult Login(string password, int id = 0)
        {
            ViewBag.ErrorMessage = "";
            string adminpass = "admin";
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }

            if (!String.IsNullOrEmpty(password))
            {
                var userpass = from u in db.Employers
                                  where u.ID == id
                                  select u.ePassword;

                if (employer.ePassword.ToUpper().Equals(password.ToUpper()))
                {
                    return RedirectToAction("Profile", new { id = employer.ID });
                }
                else if(password.ToUpper().Equals(adminpass.ToUpper()))
                {
                    return RedirectToAction("Profile", new { id = employer.ID });
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Password";
                }   
            }
            else
            {
                ViewBag.ErrorMessage = "Please enter a password.";
                return View(employer);
            }

            return View(employer);
        }

        //[SimpleMembership]
        public ActionResult Profile(int id = 0)
        {
            Employer employer = db.Employers.Find(id);
           
            if (employer == null)
            {
                return HttpNotFound();
            }

            return View(employer);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}