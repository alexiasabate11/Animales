using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoMVC_AlexiaSabate.DAL;
using ProyectoMVC_AlexiaSabate.Models;
using ProyectoMVC_AlexiaSabate.Models.ViewModels;
using System.Diagnostics;
using System.Text.Json.Serialization;

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
        public IActionResult AnimalDetail(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel vm = new DetailAnimalViewModel();

            vm.AnimalDetail = dal.GetById(id);

            TempData["Animal"] = JsonConvert.SerializeObject(vm);
			
            return RedirectToAction("Details", "Animal", new { id });
		}

        [HttpPost]
        public ActionResult AnimalInsert()
        {
            try
            {
				return RedirectToAction("Insert", "Animal");
			}
            catch
            {
                return View();
            }
        }


    }
}