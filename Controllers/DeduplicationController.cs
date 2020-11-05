using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeduplicationDemo.Models;
using Microsoft.AspNetCore.Http;
using DeduplicationDemo.Services;

namespace DeduplicationDemo.Controllers
{
    public class DeduplicationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DeduplicationController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(IFormCollection collection)
        {
            var risFile = RisFileParser.ParseRisFile(collection.Files.FirstOrDefault());

            var risList = new List<Document>();

            var count = 0;

            foreach (var item in risFile.Docs)
            {
                count++;
                risList.Add(new Document(item, count));
            }

            var deduplicationResult = new Dictionary<string, List<KeyValuePair<string, double>>>();

            if (risList.Any())
            {
                deduplicationResult = DeduplicationService.DeduplicateRecords(risList);
            }

            return View(new DeduplicationViewModel(risList, deduplicationResult));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
