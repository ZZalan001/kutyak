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
        public async Task<IActionResult> KutyaKozmetika(int id)
        {
            await Task.Delay(500);
            Kutya kutya = KutyaService.GetKutya(id);
            if (kutya == null) 
            { 
                ViewBag.Kutya = new Kutya { Id = 0, IndexKep = new byte[0], Kep = new byte[0] };
            }
            else
            {
                ViewBag.Kutya = kutya;
            }
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
