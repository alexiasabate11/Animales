namespace ProyectoMVC_AlexiaSabate.Models.ViewModels
{
    public class DetailAnimalViewModel
    {
        public Animal AnimalDetail { get; set; } = new Animal();

        public List<TipoAnimal> TipoAnimalesDetails { get; set; } = new List<TipoAnimal>();
    }
}
