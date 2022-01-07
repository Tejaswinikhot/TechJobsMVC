using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            if (TempData["jobs"]!= null)
            {
                ViewBag.jobs = JsonConvert.DeserializeObject((string)TempData["jobs"]);
            }
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.
        ///search/results
        [HttpPost]
        [Route("search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            var jobs = new ListController().getJobs(searchType, searchTerm);
            TempData["Title"] = "Jobs with " + searchType + ": " + searchTerm;
            TempData["jobs"] = JsonConvert.SerializeObject(jobs);
            return RedirectToAction("Index");
        }
    }
}
