namespace ProyectoMVC_AlexiaSabate.Models.ViewModels
{
    public class InsertAnimalViewModel
    {
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public int RIdTipoAnimal { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
    }
}
