using Microsoft.AspNetCore.Mvc;
using ProyectoMVC_AlexiaSabate.DAL;
using ProyectoMVC_AlexiaSabate.Models.ViewModels;

namespace ProyectoMVC_AlexiaSabate.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel viewModel = new DetailAnimalViewModel();  

            viewModel.AnimalDetail = dal.GetById(id);

            if(viewModel.AnimalDetail == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();
            InsertAnimalViewModel viewModel = new InsertAnimalViewModel();

            viewModel.TipoAnimales = dalTipoAnimal.GetAll();

            if (viewModel.TipoAnimales == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
