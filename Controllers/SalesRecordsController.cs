using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordsServices _salesRecordsServices;

        public SalesRecordsController(SalesRecordsServices salesRecordsServices)
        {
            _salesRecordsServices = salesRecordsServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearchAsync(DateTime? minDate, DateTime? maxDate)
        {
            ViewData["minDate"] = minDate.Value.ToString("yyyy,MM,dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy,MM,dd");
            var result = await _salesRecordsServices.FindbyDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearchAsync(DateTime? minDate, DateTime? maxDate)
        {
            ViewData["minDate"] = minDate.Value.ToString("yyyy,MM,dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy,MM,dd");
            var result = await _salesRecordsServices.FindbyDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
 
    }
}