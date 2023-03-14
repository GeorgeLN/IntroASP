using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IntroASP.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required] //Permite hacer que el campo en el formulario sea obligatorio.
        [Display(Name = "Nombre")] //Permite cambiar el nombre del campo a manera de información extra.
        public string Name { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }
    }
}
