using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace UniversityFront.Models
{
    public class StudentViewModel : PageModel
    {
        [Display(Name = "Apellidos:"), Required(ErrorMessage = "Ingresa un apellido valido.")]
        public required string lastName { get; set; }

        [Display(Name = "Nombre:"), Required(ErrorMessage = "Ingresa un nombre valido.")]
        public required string firstMidName { get; set; }

        [Display(Name = "Genero:"), Required]
        public required string genre { get; set; }

        [Display(Name = "Imagen"), BindProperty, Required(ErrorMessage = "Selecciona una imagen valida.")]
        public IFormFile img { get; set; }
    }
}
