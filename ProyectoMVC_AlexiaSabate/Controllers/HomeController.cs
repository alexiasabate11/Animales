using Microsoft.AspNetCore.Mvc;
using ProyectoMVC_AlexiaSabate.DAL;
using ProyectoMVC_AlexiaSabate.Models;
using ProyectoMVC_AlexiaSabate.Models.ViewModels;
using System.Diagnostics;

namespace ProyectoMVC_AlexiaSabate.Controllers
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
            AnimalDAL dalAnimal = new AnimalDAL();
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();

            AnimalViewModel viewModel = new AnimalViewModel();
            viewModel.Animales = dalAnimal.GetAll();
            viewModel.TipoAnimales = dalTipoAnimal.GetAll();


            return View(viewModel);
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
        public ActionResult AnimalDetail(int id)
        {
            return RedirectToAction("Details", "Animal", new {id});
        }

        [HttpPost]
        public ActionResult AnimalInsert()
        {
            return RedirectToAction("Insert", "Animal");
        }
    }
}