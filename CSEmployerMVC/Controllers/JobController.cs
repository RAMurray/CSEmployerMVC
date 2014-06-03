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
using iTextSharp.text;

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
            ViewBag.PositionType = SelectPosition();
            return View();
        }

        //
        // POST: /Job/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            job.DatePosted = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName", job.EmployerID);
            ViewBag.PositionType = SelectPosition();
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
            ViewBag.PositionType = SelectPosition();
            return View(job);
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            //job.DatePosted = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "CompanyName", job.EmployerID);
            ViewBag.PositionType = SelectPosition();
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

        //Search
        public ActionResult Search(string sortOrder, int? sortNum, string searchString)
        {
            var jobs = db.Jobs.Include(e => e.Employer);

            ViewBag.CompSortParm = String.IsNullOrEmpty(sortOrder) ? "CName_desc" : "";
            ViewBag.JobSortParm = String.IsNullOrEmpty(sortOrder) ? "JName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.NumSortParm = sortNum >= 0 ? "Num_desc" : "Num";

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(j => j.JobTitle.ToUpper().Contains(searchString.ToUpper()) || j.Employer.CompanyName.ToUpper().Contains(searchString.ToUpper()));
            }

                switch (sortOrder)
                {
                    case "CName_desc":
                        jobs = jobs.OrderByDescending(e => e.Employer.CompanyName);
                        break;
                    case "JName_desc":
                        jobs = jobs.OrderByDescending(e => e.JobTitle);
                        break;
                    case "Money_desc":
                        jobs = jobs.OrderByDescending(j => j.Salary);
                        break;
                    case "Money":
                        jobs = jobs.OrderBy(j => j.Salary);
                        break;
                    case "Num":
                        jobs = jobs.OrderBy(j => j.HoursPerWeek);
                        break;
                    case "Num_desc":
                        jobs = jobs.OrderByDescending(j => j.HoursPerWeek);
                        break;
                    case "Date_desc":
                        jobs = jobs.OrderByDescending(j => j.DatePosted);
                        break;
                    case "Date":
                        jobs = jobs.OrderBy(j => j.DatePosted);
                        break;
                    default:
                        jobs = jobs.OrderBy(j => j.ID);
                        break;
                }
            
            return View(jobs.ToList());

        }

        public ActionResult Info(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }


       /* public ActionResult Manage(int id = 0)
        {
            Job viewModel = db.Jobs.Find(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        public ActionResult Manage(int id = 0, string btnType, string applicant)
        {

            //var applicants = db.Applicants.Include(a => a.Jobs);
            var job = db.Jobs;

            string Clist = (from j in db.Jobs
                           where j.ID == id
                           select j.Candidates).SingleOrDefault();

            List<string> candidateList = new List<string>();


            if (!String.IsNullOrEmpty(Clist))
            {
                candidateList = Clist.Split(new char[] { ',' }).ToList();

            }

            switch(btnType) {
                case "Add":
                    candidateList.Add(applicant);
                    StringBuilder builder = new StringBuilder();
                    foreach (string can in candidateList)
                    {
                        builder.Append(can).Append(",");
                    }
                    Clist = builder.ToString();
                    
                    db.Jobs.

                    break;

                case "Bad":

                    break;
            }
           

        }


        protected void Add(string name, Action<Job> action)
        {
            using (Job db = new Job())
            {
                var result = from j in db.Applicants
                             where j.FullName == name
                             select u
*/
       /* public ActionResult Manage(string password, string lastname)
        {
            var model = new List<Job>();

            var tempvar = from c in db.Jobs
                          where c.Employer.ePassword == password
                          select c.Candidates;

            var tempstring = tempvar.ToString();

            if (!String.IsNullOrEmpty(tempstring))
            {
                List<string> templist = tempstring.Split(new char[] { ' ' }).ToList();

               // templist.Add(lastname);

            }
            // populate your list

            return View(model);
        }

        [HttpPost]
        public ActionResult Manage()
        {
           // Job model = new Job();

            var model = db.Applicants.Include(a => a.Jobs);

            return View(model);
        }


        
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Add")]
        public ActionResult Add(string password, string lastname) 
        {
          
            //var applicants = db.Applicants.Include(a => a.Jobs);

            string NewCanList = null;

            var pword = from p in db.Employers
                            where p.ePassword == password
                            select p;

            var lname = from l in db.Applicants
                        where l.LName == lastname
                        select l;

            if (!String.IsNullOrEmpty(pword.ToString()) && !String.IsNullOrEmpty(lname.ToString()))
            {
                var tempvar = from c in db.Jobs
                              where c.Employer.ePassword == password
                              select c.Candidates;

                var tempstring = tempvar.ToString();

                if (!String.IsNullOrEmpty(tempstring))
                {
                    //Set Candidates to lastname
                    NewCanList = lastname;

                }
                else
                {
                    List<string> templist = tempstring.Split(new char[] { ' ' }).ToList();

                    templist.Add(lastname);

                    StringBuilder builder = new StringBuilder();
                    foreach (string candidate in templist)
                    {
                        builder.Append(templist).Append(" ");
                    }

                    NewCanList = builder.ToString();

                }

            }
            else
            {
                ViewBag.ConcurrencyErrorMessage = "Invalid Entry! Either Password or Last Name was wrong";
                return RedirectToAction("Manage");
            }


            return Content(NewCanList);

        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Remove")]
        public ActionResult Manage(string password, string lastname) 
        {
            string NewCanList = null;

            var pword = from p in db.Employers
                        where p.ePassword == password
                        select p;

            var lname = from l in db.Applicants
                        where l.LName == lastname
                        select l;

            if (!String.IsNullOrEmpty(pword.ToString()) && !String.IsNullOrEmpty(lname.ToString()))
            {
                var tempvar = from c in db.Jobs
                              where c.Employer.ePassword == password
                              select c.Candidates;

                var tempstring = tempvar.ToString();

                if (!String.IsNullOrEmpty(tempstring))
                {
                    ViewBag.ConcurrencyErrorMessage = "This list is already empty.";

                }
                else
                {
                    List<string> templist = tempstring.Split(new char[] { ' ' }).ToList();

                    templist.Remove(lastname);

                    StringBuilder builder = new StringBuilder();
                    foreach (string candidate in templist)
                    {
                        builder.Append(templist).Append(" ");
                    }

                    NewCanList = builder.ToString();

                }

            }
            else
            {
                ViewBag.ConcurrencyErrorMessage = "Invalid Entry! Either Password or Last Name was wrong";
                return RedirectToAction("Manage");
            }


            return Content(NewCanList);

        
        }*/
        



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

        /*[HttpPost]
        public ActionResult Manage(FormCollection form)
        {
            ViewBag.YouSelected = form["Applicants"];

            string selectedValues = form["Applicants"];

            ViewBag.CandidateList = GetApplicants(selectedValues.Split(','));

            return View();

        }



        private void PopulatePositionList(object selectedPosition = null)
        {
            List<string> positionList = new List<string>();

            positionList.Add("Part-Time");
            positionList.Add("Full-Time");
            positionList.Add("Internship");
            positionList.Add("Temporarily");

           // ViewBag.ApplicantList = db.Applicants.OrderBy(x => x.ID).ToList();

            ViewBag.PositionList = new SelectList(positionList, "PositionType", "PositionType", selectedPosition);
        }*/


        public List<SelectListItem> SelectPosition()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Full-Time", Value = "Full-Time" });
            items.Add(new SelectListItem { Text = "Part-Time", Value = "Part-Time" });
            items.Add(new SelectListItem { Text = "Temporarily", Value = "Temporarily" });
            items.Add(new SelectListItem { Text = "Internship", Value = "Internship" });

            //ViewBag.PositionTypes = items;
            //return items;

            return items;
        }
      


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}