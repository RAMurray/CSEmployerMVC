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
            viewModel.PGLanguages = from p in db.ProLanguage
                                    select p;
            viewModel.Resumes = from r in db.Resumes
                                select r;

            return View(viewModel);
        }

    }
}
