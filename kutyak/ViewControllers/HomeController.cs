using kutyak.Models;
using kutyak.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kutyak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kutyak()
        {
            return View(KutyaService.GetKutyak());
        }
        public IActionResult KutyakDTO()
        {
            return View(KutyaService.GetKutyakDTO());
        }
        public IActionResult KutyaKep(int id)
        {
            return View(KutyaService.GetKutyaGumi(id));
        }
        public void KutyaTorol(int id)
        {
            //return Redirect("/Home/KutyakDTO");
            KutyaService.KutyaTorol(id);
        }
        public IActionResult KutyaKozmetika(int id)
        {
            ViewBag.Kutya = KutyaService.GetKutya(id);
            ViewBag.Gazdak = GazdaService.GetGazdak();
            ViewBag.Fajtak = FajtaService.GetFajtak();
            return View(ViewBag);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
