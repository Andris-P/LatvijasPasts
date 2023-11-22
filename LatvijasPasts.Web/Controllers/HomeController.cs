using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LatvijasPasts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<CurriculumVitae> _cvService;

        public HomeController(ILogger<HomeController> logger, IEntityService<CurriculumVitae> cvService)
        {
            _logger = logger;
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.Get();
            var cvList = new CvListViewModel();
            cvList.CvItems = cvs.Select(cv => new CvItemViewModel
            {
                Email = cv.Email,
                Id = cv.Id,
                Name = cv.FirstName,
                LastName = cv.LastName,
                PhoneNumber = cv.PhoneNumber,
                OtherName = cv.OtherName
            }).ToList();

            return View(cvList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cv = _cvService.GetById(id);
            if (cv != null)
            {
                _cvService.Delete(cv);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cv = _cvService.GetById(id);
            if (cv != null)
            {
                var model = new CvItemViewModel
                {
                    Name = cv.FirstName,
                    LastName = cv.LastName,
                    OtherName = cv.OtherName,
                    PhoneNumber = cv.PhoneNumber,
                    Email = cv.Email,
                    Id = cv.Id
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }
         
        [HttpPost]
        public IActionResult Edit(CvItemViewModel cv)
        {
            var existingCv = _cvService.GetById(cv.Id);
            if (existingCv != null)
            {
                existingCv.Email = cv.Email;
                existingCv.FirstName = cv.Name;
                existingCv.LastName = cv.LastName;
                existingCv.OtherName = cv.OtherName;
                existingCv.PhoneNumber = cv.PhoneNumber;
                _cvService.Update(existingCv);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CvItemViewModel cv)
        {
            _cvService.Create(new CurriculumVitae
            {
                Email = cv.Email,
                FirstName = cv.Name,
                LastName = cv.LastName,
                OtherName = cv.OtherName,
                PhoneNumber = cv.PhoneNumber
            });
            return RedirectToAction("Index");
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
    }
}