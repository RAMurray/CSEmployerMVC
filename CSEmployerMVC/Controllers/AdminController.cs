using CSEmployerMVC.Classes;
using CSEmployerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEmployerMVC.Controllers
{
    public class AdminController : Controller
    {

        private CSEDataContext db = new CSEDataContext();

        //
        // GET: /Admin/

        public ActionResult Index() 
        {
            Admin viewModel = new Admin();

            viewModel.Applicants = from a in db.Applicants
                                   select a;
            viewModel.Employers = from e in db.Employers
                                  select e;
            viewModel.Jobs = from j in db.Jobs
                             select j;
            viewModel.PGLanguages = from p in db.PGLanguages
                                    select p;
            viewModel.Resumes = from r in db.Resumes
                                select r;

            return View(viewModel);
        }

      /*  public ActionResult Manage(int id = 0, string password, string lastname)
        {
            Admin viewModel = new Admin();

            viewModel.Applicants = from a in db.Applicants
                                   select a;
            viewModel.Employers = from e in db.Employers
                                  select e;
            viewModel.Jobs = from j in db.Jobs
                             select j;


            return View(viewModel);
        }*/
        //Search
        public ActionResult Search(string searchString)
        {
            Admin viewModel = new Admin(); 
            viewModel.Applicants = from a in db.Applicants
                                    select a;


            ViewBag.ConcurrencyErrorMessage = "Test, please ignore.";

            if (!String.IsNullOrEmpty(searchString))
            {
                var applicants = viewModel.Applicants.Where(s => s.KnownPL1.Contains(searchString) || s.KnownPL2.Contains(searchString) || s.KnownPL3.Contains(searchString) || s.KnownPL4.Contains(searchString) || s.KnownPL5.Contains(searchString));

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


            return View(viewModel);

        }

    }
}
