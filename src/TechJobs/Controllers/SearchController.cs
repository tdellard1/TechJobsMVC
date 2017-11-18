using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchTerm, string searchType)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
                return View("Index");
            }

            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.columns = ListController.columnChoices;
            ViewBag.jobs = jobs;
            return View("Index");
        }

    }
}
