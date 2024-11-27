namespace ProyectoMVC_AlexiaSabate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

public class InsertAnimalViewModel
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string NombreAnimal { get; set; }

    [Required(ErrorMessage = "Debe señalar una raza.")]
    public string Raza { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un tipo de animal.")]
    public int RIdTipoAnimal { get; set; }

	[Required(ErrorMessage = "Debe seleccionar una fecha de nacimiento del animal.")]

	public DateTime? FechaNacimiento { get; set; }

	//Navegación a tipo animal
	public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
}