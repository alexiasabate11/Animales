using Microsoft.AspNetCore.Mvc;
using ProyectoMVC_AlexiaSabate.DAL;
using ProyectoMVC_AlexiaSabate.Models.ViewModels;
using ProyectoMVC_AlexiaSabate.Models;
using Newtonsoft.Json;

namespace ProyectoMVC_AlexiaSabate.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            if (TempData["Animal"] != null)
            {
                var json = TempData["Animal"] as string;
                var vm = JsonConvert.DeserializeObject<DetailAnimalViewModel>(json);
				
                return View(vm);
			}
            

            return RedirectToAction("Index","Home");
        }

        public IActionResult Insert()
        {
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();
            InsertAnimalViewModel viewModel = new InsertAnimalViewModel();
            viewModel.TipoAnimales = dalTipoAnimal.GetAll();
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Insert(InsertAnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AnimalDAL dal = new AnimalDAL();

                    Animal nuevoAnimal = new Animal
                    {
                        NombreAnimal = model.NombreAnimal,
                        Raza = model.Raza,
                        FechaNacimiento = model.FechaNacimiento,
                        RIdTipoAnimal = model.RIdTipoAnimal
                    };

                    dal.Insert(nuevoAnimal);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Hubo un error al insertar el animal: " + ex.Message);
                }
            }

            // Si hay errores, recarga los datos necesarios y vuelve a mostrar la vista
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();
            model.TipoAnimales = dalTipoAnimal.GetAll();

            return View(model);
        }

    }
}
