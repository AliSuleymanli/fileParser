using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parser.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Parser.Helper;
using Parser.Services;
using Parser.ViewModels;

namespace Parser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        IFileUploadService fileUploadService;
        IParser helper;

        public HomeController(ILogger<HomeController> _logger, IFileUploadService _fileUploadService,IParser _helper)
        {
            logger = _logger;
            fileUploadService = _fileUploadService;
            helper = _helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot","files",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return View("Index", path);
        }

        public async Task<IActionResult> UploadFile()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendFileInfoToDatabase(string path)
        {

            var result =helper.readFromFileToList(path);

            await fileUploadService.insert(result);

            return View("Report", result);
        }

        public async Task<IActionResult> SendFileInfoToDatabase()
        {
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Report()
        {
            return RedirectToAction("Index");
        }

    }
}
