using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC_AlexiaSabate.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		public string NombreAnimal { get; set; }

		[Required(ErrorMessage = "Debe señalar una raza.")]
		public string Raza { get; set; }

		[Required(ErrorMessage = "Debe seleccionar un tipo de animal.")]
		public int RIdTipoAnimal { get; set; }

		[Required(ErrorMessage = "Debe seleccionar una fecha de nacimiento del animal.")]
		public DateTime? FechaNacimiento { get; set; }

        //Navegación a tipo animal
        public TipoAnimal TipoDeAnimal { get; set; }
    }
}
